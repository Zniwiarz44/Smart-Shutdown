using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Shutdown
{
    public partial class Form1 : Form
    {
        private int[] timerArr = { 0, 1, 0 };                   // Sample time for the timer to display
        private Timer t1 = new Timer();
        private int networkInactive = netInactiveTime;          // 180sec as default inactive time, if time goes to 0 shutdown
        private bool appRunning = false;
        private const int netInactiveTime = 180;
        // Holds network interfaces
        private List<PerformanceCounter> instancesList = new List<PerformanceCounter>();
        private Dictionary<string, bool> activeButtonState = new Dictionary<string, bool>();

        public Form1()
        {
            InitializeComponent();
            InitializeAdvancedButtons();
            //InitCustomLabelFont();                    // Custom font causes memory violation
            // Timer initialization and event handling
            t1.Tick += new EventHandler(timerTick);     // Everytime timer ticks, timer_Tick will be called
            t1.Interval = 1000;                         // 1000ms = 1 sec
            t1.Enabled = false;
            TextTime();
            l_DLSpeed.Text = "Time to shutdown";

            // Network Utilization (in Bytes/Sec)
            PerformanceCounterCategory category = new PerformanceCounterCategory("Network Interface");
            String[] instanceName = category.GetInstanceNames();
            foreach (string name in instanceName)
            {
                instancesList.Add(new PerformanceCounter("Network Interface", "Bytes Received/sec", name));
            }
        }

        private void timerTick(object sender, EventArgs e)
        {
            if (ch_DLFinished.Checked)
            {
                networkInactive--;
                foreach (PerformanceCounter counter in instancesList)
                {
                    // Value returned in bytes
                    // May throw AccessViolationException, in .NET Corrupted State Exceptions (CSE) are not allowed to be caught by your standard managed code.
                    double speedInBytes = counter.NextValue();
                    l_Warning.Text = "";
                    if (speedInBytes < 1024)
                    {
                        l_Timer.Text = Math.Round(speedInBytes / 1024) + " bytes/s";                        
                        if (networkInactive < 60)
                        {
                            l_Warning.Text = "Warning, network inactive\nSystem will shutdown in: " + networkInactive + " sec";
                        }
                        if (networkInactive == 0)
                        {
                            ZeroOutTimer();
                            t1.Stop();
                            WindowsShutdown();
                        }
                    }
                    else if (speedInBytes > 1024 && speedInBytes < 820000)
                    {
                        l_Timer.Text = Math.Round(speedInBytes / 1024) + " KB/s";
                        networkInactive = netInactiveTime;
                    }
                    else if (speedInBytes > 820000 && speedInBytes < 838860800)
                    {
                        l_Timer.Text = Math.Round(speedInBytes / 1024 / 1024, 2) + " MB/s";
                        networkInactive = netInactiveTime;
                    }
                    else
                    {
                        l_Timer.Text = Math.Round(speedInBytes / 1024 / 1024 / 1024, 2) + " GB/s";
                        networkInactive = netInactiveTime;
                    }
                }
            }
            else
            {
                // Shutdown windows when the timer reaches 0, using the application
                if (timerArr[0] == 0 && timerArr[1] == 0 && timerArr[2] == 0)
                {
                    t1.Stop();
                    WindowsShutdown();
                }
                else
                {
                    tickSecondDec();
                }
            }
        }

        private void WindowsShutdown()
        {
            // Converts Hours and mins to seconds
            int timeToShutdown = (timerArr[0] * (60 * 60)) + (timerArr[1] * 60) + timerArr[2];       // Hours Minutes Seconds

            if (!ch_ForceShutdown.Checked)
            {
                Process.Start("shutdown", "/s /t " + timeToShutdown);
            }
            else
            {
                Process.Start("shutdown", "/s /f /t " + timeToShutdown);
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

        #region Time buttons functions
        private void tickSecondInc()
        {
            timerArr[2]++;
            if (timerArr[2] > 59)
            {
                timerArr[2] = 0;
                timerArr[1]++;
                if (timerArr[1] > 59)
                {
                    timerArr[1] = 0;
                    timerArr[0]++;
                    if (timerArr[0] > 59)
                    {
                        timerArr[0] = 0;
                    }
                }
            }
            TextTime();
        }

        private void tickSecondDec()
        {
            timerArr[2]--;
            if (timerArr[2] < 0)
            {
                timerArr[2] = 59;
                timerArr[1]--;
                if (timerArr[1] < 0)
                {
                    timerArr[1] = 59;
                    timerArr[0]--;
                    if (timerArr[0] < 0)
                    {
                        timerArr[0] = 59;
                    }
                }
            }
            TextTime();
        }

        private void tickMinuteInc()
        {
            timerArr[1]++;
            if (timerArr[1] > 59)
            {
                timerArr[1] = 0;
                timerArr[0]++;
                if (timerArr[0] > 59)
                {
                    timerArr[0] = 0;
                }
            }
            TextTime();
        }
        private void tickMinuteDec()
        {
            timerArr[1]--;
            if (timerArr[1] < 0)
            {
                timerArr[1] = 59;
                timerArr[0]--;
                if (timerArr[0] < 0)
                {
                    timerArr[0] = 59;
                }
            }
            TextTime();
        }

        private void tickHourInc()
        {
            timerArr[0]++;
            if (timerArr[0] > 59)
            {
                timerArr[0] = 0;
            }
            TextTime();
        }
        private void tickHourDec()
        {
            timerArr[0]--;
            if (timerArr[0] < 0)
            {
                timerArr[0] = 59;
            }
            TextTime();
        }
        #endregion

        #region Time buttons
        private void bSecInc_Click(object sender, EventArgs e)
        {
            tickSecondInc();
        }

        private void bSecDec_Click(object sender, EventArgs e)
        {
            tickSecondDec();
        }

        private void bMinInc_Click(object sender, EventArgs e)
        {
            tickMinuteInc();
        }

        private void bMinDec_Click(object sender, EventArgs e)
        {
            tickMinuteDec();
        }

        private void bHourInc_Click(object sender, EventArgs e)
        {
            tickHourInc();
        }

        private void bHourDec_Click(object sender, EventArgs e)
        {
            tickHourDec();
        }
        #endregion

        #region Timer options
        private void TextTime()
        {
            l_Timer.Text = timerArr[0].ToString("00") + ":" + timerArr[1].ToString("00") + ":" + timerArr[2].ToString("00");
        }
        private void ZeroOutTimer()
        {
            timerArr[0] = 0;
            timerArr[1] = 0;
            timerArr[2] = 0;
        }
        private void ResetTimer()
        {
            timerArr[0] = 0;
            timerArr[1] = 1;
            timerArr[2] = 0;
            // Update the display
            TextTime();
        }
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

            if (ch_ForceShutdown.Checked && (timerArr[0] <= 0 && timerArr[1] <= 0 && timerArr[2] <= 0))
            {
                if (ch_DLFinished.Checked)
                {
                    timerArr[2] = 1;
                }
                else
                {
                    l_Warning.Text = "Shutdown aborted!\nTime has to be > 1sec";
                }
            }
            else
            {
                l_Warning.Text = "";
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
                    t1.Start();
                    l_DLSpeed.Text = "Network Usage\n(Received):";
                }
                else
                {
                    t1.Start();
                    l_DLSpeed.Text = "Time to shutdown";
                }
                bShutdown.Enabled = false;
            }
        }
        private void bPause_Click(object sender, EventArgs e)
        {
            t1.Stop();
            bShutdown.Enabled = true;
            appRunning = true;
        }
        private void bAbort_Click(object sender, EventArgs e)
        {
            t1.Stop();
            ResetTimer();
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
                t1.Stop();
                ResetTimer();
                ch_UseWindowsClose.Enabled = true;
                EnableTimeButtons(true);               // Enable buttons to change time
            }
            else
            {
                ch_UseWindowsClose.Enabled = false;
                EnableTimeButtons(false);              // Disable buttons to change time
            }
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
            t1.Stop();
            t1.Dispose();
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
    }
}
