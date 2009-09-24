using System;
using System.Drawing;
using System.Windows.Forms; 

namespace StopWatch
{
    public partial class App
    {
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbTime;
        private System.Timers.Timer timer1;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.Button bReset;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTime = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bReset = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Timers.Timer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bCountdownSet = new System.Windows.Forms.Button();
            this.bDecreaseCountdown = new System.Windows.Forms.Button();
            this.bIncreaseCountdown = new System.Windows.Forms.Button();
            this.lbTimer = new System.Windows.Forms.Label();
            this.cbAudibleAlarm = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 100);
            this.panel1.TabIndex = 0;
            // 
            // lbTime
            // 
            this.lbTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTime.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.Location = new System.Drawing.Point(0, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(451, 100);
            this.lbTime.TabIndex = 0;
            this.lbTime.Text = "label1";
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bReset);
            this.panel2.Controls.Add(this.bStart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(451, 59);
            this.panel2.TabIndex = 2;
            // 
            // bReset
            // 
            this.bReset.Location = new System.Drawing.Point(224, 14);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(75, 23);
            this.bReset.TabIndex = 2;
            this.bReset.Text = "&Reset";
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(92, 14);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "&Start";
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 250;
            this.timer1.SynchronizingObject = this;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbAudibleAlarm);
            this.panel3.Controls.Add(this.bCountdownSet);
            this.panel3.Controls.Add(this.bDecreaseCountdown);
            this.panel3.Controls.Add(this.bIncreaseCountdown);
            this.panel3.Controls.Add(this.lbTimer);
            this.panel3.Location = new System.Drawing.Point(0, 173);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(376, 77);
            this.panel3.TabIndex = 4;
            // 
            // bCountdownSet
            // 
            this.bCountdownSet.Location = new System.Drawing.Point(318, 29);
            this.bCountdownSet.Name = "bCountdownSet";
            this.bCountdownSet.Size = new System.Drawing.Size(46, 24);
            this.bCountdownSet.TabIndex = 4;
            this.bCountdownSet.Text = "S&et...";
            this.bCountdownSet.UseVisualStyleBackColor = true;
            this.bCountdownSet.Click += new System.EventHandler(this.bCountdownSet_Click);
            // 
            // bDecreaseCountdown
            // 
            this.bDecreaseCountdown.Location = new System.Drawing.Point(294, 44);
            this.bDecreaseCountdown.Name = "bDecreaseCountdown";
            this.bDecreaseCountdown.Size = new System.Drawing.Size(19, 20);
            this.bDecreaseCountdown.TabIndex = 3;
            this.bDecreaseCountdown.Text = "-";
            this.bDecreaseCountdown.UseVisualStyleBackColor = true;
            this.bDecreaseCountdown.Click += new System.EventHandler(this.bDecreaseCountdown_Click);
            // 
            // bIncreaseCountdown
            // 
            this.bIncreaseCountdown.Location = new System.Drawing.Point(294, 19);
            this.bIncreaseCountdown.Name = "bIncreaseCountdown";
            this.bIncreaseCountdown.Size = new System.Drawing.Size(19, 20);
            this.bIncreaseCountdown.TabIndex = 2;
            this.bIncreaseCountdown.Text = "+";
            this.bIncreaseCountdown.UseVisualStyleBackColor = true;
            this.bIncreaseCountdown.Click += new System.EventHandler(this.bIncreaseCountdown_Click);
            // 
            // lbTimer
            // 
            this.lbTimer.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimer.Location = new System.Drawing.Point(0, -11);
            this.lbTimer.Name = "lbTimer";
            this.lbTimer.Size = new System.Drawing.Size(376, 96);
            this.lbTimer.TabIndex = 1;
            this.lbTimer.Text = "+00:00:00.00";
            this.lbTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbAudibleAlarm
            // 
            this.cbAudibleAlarm.AutoSize = true;
            this.cbAudibleAlarm.Checked = true;
            this.cbAudibleAlarm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAudibleAlarm.Location = new System.Drawing.Point(151, 60);
            this.cbAudibleAlarm.Name = "cbAudibleAlarm";
            this.cbAudibleAlarm.Size = new System.Drawing.Size(90, 17);
            this.cbAudibleAlarm.TabIndex = 5;
            this.cbAudibleAlarm.Text = "&Audible Alarm";
            this.cbAudibleAlarm.UseVisualStyleBackColor = true;
            // 
            // App
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(451, 291);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "App";
            this.Text = "StopWatch";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button bIncreaseCountdown;
        private Button bDecreaseCountdown;
        private Button bCountdownSet;
        private CheckBox cbAudibleAlarm;

    }
}
