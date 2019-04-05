using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ShutdownLogic;
using System.ComponentModel;

namespace Smart_Shutdown
{
    public partial class Form1 : Form
    {
        // Mouse movement controls
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        // Mouse movement controls

        private int networkInactive = netInactiveTime;          // 180sec as default inactive time, if time goes to 0 shutdown
        private bool appRunning = false;
        private const int netInactiveTime = 180;
        private int unitOfDataIndex = 4;
        private string activeDataUnitType, timerText;
        private bool clearWarning = false;

        // Holds network interfaces
        private List<PerformanceCounter> instancesList = new List<PerformanceCounter>();
        private Dictionary<string, bool> activeButtonState = new Dictionary<string, bool>();

        delegate void SetCallback();

        ShutdownTimer st = new ShutdownTimer(1000, false);
        NetworkStats ns = new NetworkStats();
        public Form1()
        {
            InitializeComponent();
            InitializeAdvancedButtons();

            SpeedDataType.SelectedIndex = unitOfDataIndex;
            activeDataUnitType = SpeedDataType.Text;
            TextTime();
            l_DLSpeed.Text = "Time to shutdown";

            // Network Utilization (in Bytes/Sec)
            PerformanceCounterCategory category = new PerformanceCounterCategory("Network Interface");
            String[] instanceName = category.GetInstanceNames();
            foreach (string name in instanceName)
            {
                instancesList.Add(new PerformanceCounter("Network Interface", "Bytes Received/sec", name));
            }
            st.timeTickEvent += timerTick;
        }
        
        private void timerTick()
        {
            float speed = 0;
            float.TryParse(tMinSpeed.Text, out speed);
            ns.CurrentSpeedInBytes();
            SpeedDataTypeSelection();

            if (ch_DLFinished.Checked)
            {
                networkInactive--;

                // If speed is less than the threshold then begin counting down to shutdown
                if (ns.SpeedBelowTreshold(speed, (UnitOfData)unitOfDataIndex))
                {
                    TextTime();
                    WarningLabel();
                    if (networkInactive == 0)
                    {
                        st.ResetTimer();
                        st.StopTimer();
                        WindowsShutdown();
                    }
                }
                else
                {
                    clearWarning = true;
                    WarningLabel();
                    clearWarning = false;
                    networkInactive = netInactiveTime;
                }
            }
            else
            {
                // Shutdown windows when the timer reaches 0, using the application
                if (st.Hours == 0 && st.Minutes == 0 && st.Seconds == 0)
                {
                    st.StopTimer();
                    WindowsShutdown();
                }
            }
            TextTime();
        }
        private void WindowsShutdown()
        {
            if (!ch_ForceShutdown.Checked)
            {
                Process.Start("shutdown", "/s /t " + st.TimeToSeconds());
            }
            else
            {
                Process.Start("shutdown", "/s /f /t " + st.TimeToSeconds());
            }
        }
        // Initializes custom 'Digital' font
        private void InitCustomLabelFont()
        {
            //Create your private font collection object.
            PrivateFontCollection pfc = new PrivateFontCollection();

            //Select your font from the resources.
            //My font here is "Open24DisplaySt.ttf"
            int fontLength = Properties.Resources.Open24DisplaySt.Length;

            // create a buffer to read in to
            byte[] fontdata = Properties.Resources.Open24DisplaySt;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);

            l_Timer.Font = new Font(pfc.Families[0], l_Timer.Font.Size);
        }

        // Thread safe calls
        #region Threads
        private void TextTime()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.l_Timer.InvokeRequired)
            {
                SetCallback d = new SetCallback(TextTime);
                this.Invoke(d, new object[] { });
            }
            else
            {
                if (ch_DLFinished.Checked)
                {
                    UnitOfData dataType;
                    // Depending on user's preference convert speed to bits or bytes
                    if (SpeedDataType.SelectedIndex % 2 == 0)
                    {
                        timerText = ns.CurrentSpeedFromBits(out dataType) + " " + ns.GetUnitStringRepresentation(dataType);
                    }
                    else
                    {
                        timerText = ns.CurrentSpeedFromBytes(out dataType) + " " + ns.GetUnitStringRepresentation(dataType);
                    }
                }
                else
                {
                    timerText = st.Hours.ToString("00") + ":" + st.Minutes.ToString("00") + ":" + st.Seconds.ToString("00");
                }
                l_Timer.Text = timerText;
            }
        }
        private void SpeedDataTypeSelection()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.SpeedDataType.InvokeRequired)
            {
                SetCallback d = new SetCallback(SpeedDataTypeSelection);
                this.Invoke(d, new object[] { });
                return;
            }
            else
            {
                activeDataUnitType = SpeedDataType.Text;
                unitOfDataIndex = SpeedDataType.SelectedIndex;
            }
        }
        private void WarningLabel()
        {
            if (this.SpeedDataType.InvokeRequired)
            {
                SetCallback d = new SetCallback(WarningLabel);
                this.Invoke(d, new object[] { });
                return;
            }
            else
            {
                if (networkInactive < 60)
                {
                    l_Warning.Text = "Warning, network inactive\nSystem will shutdown in: " + networkInactive + " sec";
                }
                if (clearWarning)
                {
                    l_Warning.Text = "";
                }
            }
        }
        #endregion

        #region Time buttons
        private void bSecInc_Click(object sender, EventArgs e)
        {
            st.TickSecondInc(true);
            TextTime();
        }

        private void bSecDec_Click(object sender, EventArgs e)
        {
            st.TickSecondDec(true);
            TextTime();
        }

        private void bMinInc_Click(object sender, EventArgs e)
        {
            st.TickMinuteInc(true);
            TextTime();
        }

        private void bMinDec_Click(object sender, EventArgs e)
        {
            st.TickMinuteDec(true);
            TextTime();
        }

        private void bHourInc_Click(object sender, EventArgs e)
        {
            st.TickHourInc();
            TextTime();
        }

        private void bHourDec_Click(object sender, EventArgs e)
        {
            st.TickHourDec();
            TextTime();
        }
        #endregion

        #region Timer options
        private void EnableTimeButtons(bool disableButtons)
        {
            bHourInc.Enabled = disableButtons;
            bHourDec.Enabled = disableButtons;
            bMinInc.Enabled = disableButtons;
            bMinDec.Enabled = disableButtons;
            bSecInc.Enabled = disableButtons;
            bSecDec.Enabled = disableButtons;
        }
        #endregion

        #region Settings
        private void bShutdown_Click(object sender, EventArgs e)
        {
            if (ch_ForceShutdown.Checked && (st.Hours == 0 && st.Minutes == 0 && st.Seconds == 0))
            {
                if (ch_DLFinished.Checked)
                {
                   st.TickSecondInc();
                }
                else
                {
                    l_Warning.Text = "Shutdown aborted!\nTime has to be > 1sec";
                }
            }
            else
            {
                clearWarning = true;
                WarningLabel();
                clearWarning = false;
                // Ensures that advanced options enable states remain original
                if (!appRunning)
                {
                    EnableAdvancedButtons(false);
                }
                // If using windows window to shutdown don't engage the rest of the application
                if (ch_UseWindowsClose.Checked)
                {
                    WindowsShutdown();
                }
                else if (ch_DLFinished.Checked)
                {
                    st.StartTimer();
                    l_DLSpeed.Text = "Network Usage\n(Received):";
                }
                else
                {
                    st.StartTimer();
                    l_DLSpeed.Text = "Time to shutdown";
                }
                bShutdown.Enabled = false;
            }
        }
        private void bPause_Click(object sender, EventArgs e)
        {
            st.StopTimer();
            bShutdown.Enabled = true;
            appRunning = true;
        }
        private void bAbort_Click(object sender, EventArgs e)
        {
            st.StopTimer();
            st.ResetTimer();
            TextTime();
            l_Warning.Text = "";
            Process.Start("shutdown", "/a");
            EnableAdvancedButtons(true);
            bShutdown.Enabled = true;
            appRunning = false;
        }
        #endregion

        #region Advanced options
        private void ch_DLFinished_CheckedChanged(object sender, EventArgs e)
        {
            if (!ch_DLFinished.Checked)
            {
                st.StopTimer();
                st.ResetTimer();
                ch_UseWindowsClose.Enabled = true;
                EnableTimeButtons(true);               // Enable buttons to change time
            }
            else
            {
                ch_UseWindowsClose.Enabled = false;
                EnableTimeButtons(false);              // Disable buttons to change time
            }
            TextTime();
        }

        private void ch_UseWindowsClose_CheckedChanged(object sender, EventArgs e)
        {
            if (!ch_UseWindowsClose.Checked)
            {
                ch_DLFinished.Enabled = true;
            }
            else
            {
                ch_DLFinished.Enabled = false;
            }
        }

        /// <summary>
        /// Note: If adding additional buttons they also have to be added in InitializeAdvancedButtons() function
        /// </summary>
        /// <param name="disableButtons"></param>
        private void EnableAdvancedButtons(bool disableButtons)
        {
            if (disableButtons)
            {
                // Enable buttons with their saved states
                bool state = false;

                activeButtonState.TryGetValue(ch_DLFinished.Name, out state);
                ch_DLFinished.Enabled = state;
                activeButtonState.TryGetValue(ch_UseWindowsClose.Name, out state);
                ch_UseWindowsClose.Enabled = state;
                activeButtonState.TryGetValue(ch_ForceShutdown.Name, out state);
                ch_ForceShutdown.Enabled = state;
            }
            else
            {
                // Disable buttons, but save their states
                activeButtonState[ch_DLFinished.Name] = ch_DLFinished.Enabled;
                activeButtonState[ch_UseWindowsClose.Name] = ch_UseWindowsClose.Enabled;
                activeButtonState[ch_ForceShutdown.Name] = ch_ForceShutdown.Enabled;

                ch_DLFinished.Enabled = disableButtons;
                ch_UseWindowsClose.Enabled = disableButtons;
                ch_ForceShutdown.Enabled = disableButtons;
            }
        }
        /// <summary>
        /// Note: If adding additional buttons they also have to be added in EnableAdvancedButtons() function
        /// </summary>
        private void InitializeAdvancedButtons()
        {
            // By default all buttons are enabled
            activeButtonState.Add(ch_DLFinished.Name, true);
            activeButtonState.Add(ch_UseWindowsClose.Name, true);
            activeButtonState.Add(ch_ForceShutdown.Name, true);
        }

        #endregion

        #region Window options
        private void bClose_Click(object sender, EventArgs e)
        {
            st.StopTimer();
            st.DisposeTimer();
            myNotifyIcon.Icon = null;
            myNotifyIcon.Dispose();
            Application.Exit();
        }

        private void bMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            if (FormWindowState.Minimized == this.WindowState)
            {
                myNotifyIcon.Visible = true;
                myNotifyIcon.ShowBalloonTip(100);
                this.Hide();
            }
        }
        private void myNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
            myNotifyIcon.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }
        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel_Advanced_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_Main_Paint(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
