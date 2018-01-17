namespace Smart_Shutdown
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel_Left = new System.Windows.Forms.Panel();
            this.bAbort = new System.Windows.Forms.Button();
            this.bPause = new System.Windows.Forms.Button();
            this.bShutdown = new System.Windows.Forms.Button();
            this.l_Settings = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.l_Warning = new System.Windows.Forms.Label();
            this.bMinimize = new System.Windows.Forms.Button();
            this.l_DLSpeed = new System.Windows.Forms.Label();
            this.panel_Timer = new System.Windows.Forms.Panel();
            this.bHourInc = new System.Windows.Forms.Button();
            this.l_Timer = new System.Windows.Forms.Label();
            this.bSecDec = new System.Windows.Forms.Button();
            this.bMinInc = new System.Windows.Forms.Button();
            this.bMinDec = new System.Windows.Forms.Button();
            this.bSecInc = new System.Windows.Forms.Button();
            this.bHourDec = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.panel_Advanced = new System.Windows.Forms.Panel();
            this.ch_ForceShutdown = new System.Windows.Forms.CheckBox();
            this.ch_DLFinished = new System.Windows.Forms.CheckBox();
            this.ch_UseWindowsClose = new System.Windows.Forms.CheckBox();
            this.l_Advanced = new System.Windows.Forms.Label();
            this.l_Title = new System.Windows.Forms.Label();
            this.myNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel_Left.SuspendLayout();
            this.panel_Main.SuspendLayout();
            this.panel_Timer.SuspendLayout();
            this.panel_Advanced.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Left
            // 
            this.panel_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(52)))));
            this.panel_Left.Controls.Add(this.bAbort);
            this.panel_Left.Controls.Add(this.bPause);
            this.panel_Left.Controls.Add(this.bShutdown);
            this.panel_Left.Controls.Add(this.l_Settings);
            this.panel_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Left.Location = new System.Drawing.Point(0, 0);
            this.panel_Left.Name = "panel_Left";
            this.panel_Left.Size = new System.Drawing.Size(200, 465);
            this.panel_Left.TabIndex = 0;
            // 
            // bAbort
            // 
            this.bAbort.BackColor = System.Drawing.Color.Transparent;
            this.bAbort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAbort.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bAbort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bAbort.Location = new System.Drawing.Point(55, 275);
            this.bAbort.Name = "bAbort";
            this.bAbort.Size = new System.Drawing.Size(99, 99);
            this.bAbort.TabIndex = 4;
            this.bAbort.Text = "ABORT";
            this.bAbort.UseVisualStyleBackColor = false;
            this.bAbort.Click += new System.EventHandler(this.bAbort_Click);
            // 
            // bPause
            // 
            this.bPause.BackColor = System.Drawing.Color.Transparent;
            this.bPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPause.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bPause.ForeColor = System.Drawing.Color.Goldenrod;
            this.bPause.Location = new System.Drawing.Point(55, 170);
            this.bPause.Name = "bPause";
            this.bPause.Size = new System.Drawing.Size(99, 99);
            this.bPause.TabIndex = 4;
            this.bPause.Text = "PAUSE";
            this.bPause.UseVisualStyleBackColor = false;
            this.bPause.Click += new System.EventHandler(this.bPause_Click);
            // 
            // bShutdown
            // 
            this.bShutdown.BackColor = System.Drawing.Color.Transparent;
            this.bShutdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bShutdown.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bShutdown.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.bShutdown.Location = new System.Drawing.Point(55, 65);
            this.bShutdown.Name = "bShutdown";
            this.bShutdown.Size = new System.Drawing.Size(99, 99);
            this.bShutdown.TabIndex = 4;
            this.bShutdown.Text = "SHUTDOWN";
            this.bShutdown.UseVisualStyleBackColor = false;
            this.bShutdown.Click += new System.EventHandler(this.bShutdown_Click);
            // 
            // l_Settings
            // 
            this.l_Settings.AutoSize = true;
            this.l_Settings.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_Settings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.l_Settings.Location = new System.Drawing.Point(50, 9);
            this.l_Settings.Name = "l_Settings";
            this.l_Settings.Size = new System.Drawing.Size(104, 30);
            this.l_Settings.TabIndex = 3;
            this.l_Settings.Text = "Settings";
            this.l_Settings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(28)))), ((int)(((byte)(37)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(11, 465);
            this.panel2.TabIndex = 1;
            // 
            // panel_Main
            // 
            this.panel_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(52)))));
            this.panel_Main.Controls.Add(this.l_Warning);
            this.panel_Main.Controls.Add(this.bMinimize);
            this.panel_Main.Controls.Add(this.l_DLSpeed);
            this.panel_Main.Controls.Add(this.panel_Timer);
            this.panel_Main.Controls.Add(this.bClose);
            this.panel_Main.Controls.Add(this.panel_Advanced);
            this.panel_Main.Controls.Add(this.l_Title);
            this.panel_Main.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Main.Location = new System.Drawing.Point(211, 0);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(736, 465);
            this.panel_Main.TabIndex = 3;
            // 
            // l_Warning
            // 
            this.l_Warning.AutoSize = true;
            this.l_Warning.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_Warning.ForeColor = System.Drawing.Color.DarkOrange;
            this.l_Warning.Location = new System.Drawing.Point(16, 65);
            this.l_Warning.Name = "l_Warning";
            this.l_Warning.Size = new System.Drawing.Size(0, 21);
            this.l_Warning.TabIndex = 9;
            // 
            // bMinimize
            // 
            this.bMinimize.BackColor = System.Drawing.Color.Transparent;
            this.bMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMinimize.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bMinimize.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.bMinimize.Location = new System.Drawing.Point(658, 9);
            this.bMinimize.Name = "bMinimize";
            this.bMinimize.Size = new System.Drawing.Size(30, 30);
            this.bMinimize.TabIndex = 8;
            this.bMinimize.Text = "_";
            this.bMinimize.UseVisualStyleBackColor = false;
            this.bMinimize.Click += new System.EventHandler(this.bMinimize_Click);
            // 
            // l_DLSpeed
            // 
            this.l_DLSpeed.AutoSize = true;
            this.l_DLSpeed.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_DLSpeed.ForeColor = System.Drawing.Color.CadetBlue;
            this.l_DLSpeed.Location = new System.Drawing.Point(16, 170);
            this.l_DLSpeed.Name = "l_DLSpeed";
            this.l_DLSpeed.Size = new System.Drawing.Size(145, 21);
            this.l_DLSpeed.TabIndex = 5;
            this.l_DLSpeed.Text = "Download Speed";
            // 
            // panel_Timer
            // 
            this.panel_Timer.Controls.Add(this.bHourInc);
            this.panel_Timer.Controls.Add(this.l_Timer);
            this.panel_Timer.Controls.Add(this.bSecDec);
            this.panel_Timer.Controls.Add(this.bMinInc);
            this.panel_Timer.Controls.Add(this.bMinDec);
            this.panel_Timer.Controls.Add(this.bSecInc);
            this.panel_Timer.Controls.Add(this.bHourDec);
            this.panel_Timer.Location = new System.Drawing.Point(233, 107);
            this.panel_Timer.Name = "panel_Timer";
            this.panel_Timer.Size = new System.Drawing.Size(286, 162);
            this.panel_Timer.TabIndex = 7;
            // 
            // bHourInc
            // 
            this.bHourInc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bHourInc.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bHourInc.ForeColor = System.Drawing.Color.CadetBlue;
            this.bHourInc.Location = new System.Drawing.Point(3, 3);
            this.bHourInc.Name = "bHourInc";
            this.bHourInc.Size = new System.Drawing.Size(88, 32);
            this.bHourInc.TabIndex = 5;
            this.bHourInc.Text = "▲";
            this.bHourInc.UseVisualStyleBackColor = true;
            this.bHourInc.Click += new System.EventHandler(this.bHourInc_Click);
            // 
            // l_Timer
            // 
            this.l_Timer.AutoSize = true;
            this.l_Timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.l_Timer.ForeColor = System.Drawing.Color.SteelBlue;
            this.l_Timer.Location = new System.Drawing.Point(0, 38);
            this.l_Timer.Name = "l_Timer";
            this.l_Timer.Size = new System.Drawing.Size(278, 84);
            this.l_Timer.TabIndex = 2;
            this.l_Timer.Text = "22:12:39";
            this.l_Timer.UseCompatibleTextRendering = true;
            // 
            // bSecDec
            // 
            this.bSecDec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSecDec.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSecDec.ForeColor = System.Drawing.Color.CadetBlue;
            this.bSecDec.Location = new System.Drawing.Point(191, 125);
            this.bSecDec.Name = "bSecDec";
            this.bSecDec.Size = new System.Drawing.Size(88, 30);
            this.bSecDec.TabIndex = 5;
            this.bSecDec.Text = "▼";
            this.bSecDec.UseVisualStyleBackColor = true;
            this.bSecDec.Click += new System.EventHandler(this.bSecDec_Click);
            // 
            // bMinInc
            // 
            this.bMinInc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMinInc.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bMinInc.ForeColor = System.Drawing.Color.CadetBlue;
            this.bMinInc.Location = new System.Drawing.Point(97, 3);
            this.bMinInc.Name = "bMinInc";
            this.bMinInc.Size = new System.Drawing.Size(88, 32);
            this.bMinInc.TabIndex = 5;
            this.bMinInc.Text = "▲";
            this.bMinInc.UseVisualStyleBackColor = true;
            this.bMinInc.Click += new System.EventHandler(this.bMinInc_Click);
            // 
            // bMinDec
            // 
            this.bMinDec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMinDec.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bMinDec.ForeColor = System.Drawing.Color.CadetBlue;
            this.bMinDec.Location = new System.Drawing.Point(97, 125);
            this.bMinDec.Name = "bMinDec";
            this.bMinDec.Size = new System.Drawing.Size(88, 30);
            this.bMinDec.TabIndex = 5;
            this.bMinDec.Text = "▼";
            this.bMinDec.UseVisualStyleBackColor = true;
            this.bMinDec.Click += new System.EventHandler(this.bMinDec_Click);
            // 
            // bSecInc
            // 
            this.bSecInc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSecInc.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSecInc.ForeColor = System.Drawing.Color.CadetBlue;
            this.bSecInc.Location = new System.Drawing.Point(191, 3);
            this.bSecInc.Name = "bSecInc";
            this.bSecInc.Size = new System.Drawing.Size(88, 32);
            this.bSecInc.TabIndex = 5;
            this.bSecInc.Text = "▲";
            this.bSecInc.UseVisualStyleBackColor = true;
            this.bSecInc.Click += new System.EventHandler(this.bSecInc_Click);
            // 
            // bHourDec
            // 
            this.bHourDec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bHourDec.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bHourDec.ForeColor = System.Drawing.Color.CadetBlue;
            this.bHourDec.Location = new System.Drawing.Point(3, 125);
            this.bHourDec.Name = "bHourDec";
            this.bHourDec.Size = new System.Drawing.Size(88, 30);
            this.bHourDec.TabIndex = 5;
            this.bHourDec.Text = "▼";
            this.bHourDec.UseVisualStyleBackColor = true;
            this.bHourDec.Click += new System.EventHandler(this.bHourDec_Click);
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.Transparent;
            this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClose.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.bClose.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.bClose.Location = new System.Drawing.Point(694, 9);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(30, 30);
            this.bClose.TabIndex = 6;
            this.bClose.Text = "X";
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // panel_Advanced
            // 
            this.panel_Advanced.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel_Advanced.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Advanced.Controls.Add(this.ch_ForceShutdown);
            this.panel_Advanced.Controls.Add(this.ch_DLFinished);
            this.panel_Advanced.Controls.Add(this.ch_UseWindowsClose);
            this.panel_Advanced.Controls.Add(this.l_Advanced);
            this.panel_Advanced.Location = new System.Drawing.Point(6, 275);
            this.panel_Advanced.Name = "panel_Advanced";
            this.panel_Advanced.Size = new System.Drawing.Size(718, 178);
            this.panel_Advanced.TabIndex = 4;
            // 
            // ch_ForceShutdown
            // 
            this.ch_ForceShutdown.AutoSize = true;
            this.ch_ForceShutdown.BackColor = System.Drawing.Color.Transparent;
            this.ch_ForceShutdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ch_ForceShutdown.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.ch_ForceShutdown.ForeColor = System.Drawing.Color.CadetBlue;
            this.ch_ForceShutdown.Location = new System.Drawing.Point(13, 100);
            this.ch_ForceShutdown.Name = "ch_ForceShutdown";
            this.ch_ForceShutdown.Size = new System.Drawing.Size(324, 25);
            this.ch_ForceShutdown.TabIndex = 7;
            this.ch_ForceShutdown.Text = "Force shutdown, time has to be > 0sec";
            this.ch_ForceShutdown.UseVisualStyleBackColor = false;
            // 
            // ch_DLFinished
            // 
            this.ch_DLFinished.AutoSize = true;
            this.ch_DLFinished.BackColor = System.Drawing.Color.Transparent;
            this.ch_DLFinished.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ch_DLFinished.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.ch_DLFinished.ForeColor = System.Drawing.Color.CadetBlue;
            this.ch_DLFinished.Location = new System.Drawing.Point(13, 69);
            this.ch_DLFinished.Name = "ch_DLFinished";
            this.ch_DLFinished.Size = new System.Drawing.Size(441, 25);
            this.ch_DLFinished.TabIndex = 6;
            this.ch_DLFinished.Text = "Shutdown when network usage is low < 1KB/s for 3min";
            this.ch_DLFinished.UseVisualStyleBackColor = false;
            this.ch_DLFinished.CheckedChanged += new System.EventHandler(this.ch_DLFinished_CheckedChanged);
            // 
            // ch_UseWindowsClose
            // 
            this.ch_UseWindowsClose.AutoSize = true;
            this.ch_UseWindowsClose.BackColor = System.Drawing.Color.Transparent;
            this.ch_UseWindowsClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ch_UseWindowsClose.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.ch_UseWindowsClose.ForeColor = System.Drawing.Color.CadetBlue;
            this.ch_UseWindowsClose.Location = new System.Drawing.Point(13, 38);
            this.ch_UseWindowsClose.Name = "ch_UseWindowsClose";
            this.ch_UseWindowsClose.Size = new System.Drawing.Size(248, 25);
            this.ch_UseWindowsClose.TabIndex = 4;
            this.ch_UseWindowsClose.Text = "Use windows closing window";
            this.ch_UseWindowsClose.UseVisualStyleBackColor = false;
            this.ch_UseWindowsClose.CheckedChanged += new System.EventHandler(this.ch_UseWindowsClose_CheckedChanged);
            // 
            // l_Advanced
            // 
            this.l_Advanced.AutoSize = true;
            this.l_Advanced.Dock = System.Windows.Forms.DockStyle.Left;
            this.l_Advanced.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.l_Advanced.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.l_Advanced.Location = new System.Drawing.Point(0, 0);
            this.l_Advanced.Name = "l_Advanced";
            this.l_Advanced.Size = new System.Drawing.Size(186, 22);
            this.l_Advanced.TabIndex = 3;
            this.l_Advanced.Text = "Advanced settings";
            // 
            // l_Title
            // 
            this.l_Title.AutoSize = true;
            this.l_Title.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.l_Title.Location = new System.Drawing.Point(6, 9);
            this.l_Title.Name = "l_Title";
            this.l_Title.Size = new System.Drawing.Size(202, 30);
            this.l_Title.TabIndex = 3;
            this.l_Title.Text = "Smart shutdown";
            // 
            // myNotifyIcon
            // 
            this.myNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.myNotifyIcon.BalloonTipText = "Application running in the background";
            this.myNotifyIcon.BalloonTipTitle = "Smart shutdown";
            this.myNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("myNotifyIcon.Icon")));
            this.myNotifyIcon.Text = "Application running in the background";
            this.myNotifyIcon.Visible = true;
            this.myNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.myNotifyIcon_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 465);
            this.Controls.Add(this.panel_Main);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_Left);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel_Left.ResumeLayout(false);
            this.panel_Left.PerformLayout();
            this.panel_Main.ResumeLayout(false);
            this.panel_Main.PerformLayout();
            this.panel_Timer.ResumeLayout(false);
            this.panel_Timer.PerformLayout();
            this.panel_Advanced.ResumeLayout(false);
            this.panel_Advanced.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Left;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel_Main;
        private System.Windows.Forms.Label l_Settings;
        private System.Windows.Forms.Label l_Title;
        private System.Windows.Forms.Button bShutdown;
        private System.Windows.Forms.Button bAbort;
        private System.Windows.Forms.Button bPause;
        private System.Windows.Forms.Label l_Advanced;
        private System.Windows.Forms.Panel panel_Advanced;
        private System.Windows.Forms.Button bHourInc;
        private System.Windows.Forms.Button bHourDec;
        private System.Windows.Forms.Button bSecDec;
        private System.Windows.Forms.Button bMinDec;
        private System.Windows.Forms.Button bSecInc;
        private System.Windows.Forms.Button bMinInc;
        private System.Windows.Forms.Label l_Timer;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.CheckBox ch_UseWindowsClose;
        private System.Windows.Forms.Panel panel_Timer;
        private System.Windows.Forms.Button bMinimize;
        private System.Windows.Forms.CheckBox ch_DLFinished;
        private System.Windows.Forms.Label l_DLSpeed;
        private System.Windows.Forms.Label l_Warning;
        private System.Windows.Forms.CheckBox ch_ForceShutdown;
        private System.Windows.Forms.NotifyIcon myNotifyIcon;
    }
}

