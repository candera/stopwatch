using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace StopWatch
{
    /// <summary>
    /// Summary description for GetTimeDlg.
    /// </summary>
    public class GetTimeDlg : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button OK;

        private TimeSpan timerTime = TimeSpan.Zero;
        private System.Windows.Forms.ErrorProvider timeErrorProvider;
        private IContainer components;

        public TimeSpan TimerTime
        {
            get { return timerTime; }
            set 
            { 
                timerTime = value;
                textBox1.Text = value.ToString(); 
            }
        }

        public GetTimeDlg()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.timeErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.timeErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(140, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 41);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "00:00:00";
            this.textBox1.Validated += new System.EventHandler(this.textBox1_Validated);
            // 
            // OK
            // 
            this.OK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(147, 57);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(94, 44);
            this.OK.TabIndex = 2;
            this.OK.Text = "OK";
            // 
            // timeErrorProvider
            // 
            this.timeErrorProvider.ContainerControl = this;
            // 
            // GetTimeDlg
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleBaseSize = new System.Drawing.Size(15, 34);
            this.ClientSize = new System.Drawing.Size(395, 106);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1250, 146);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(0, 146);
            this.Name = "GetTimeDlg";
            this.Text = "GetTimeDlg";
            ((System.ComponentModel.ISupportInitialize)(this.timeErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void textBox1_Validated(object sender, System.EventArgs e)
        {
            if (IsTimeValid())
            {
                timeErrorProvider.SetError(textBox1, "");
                this.TimerTime = TimeSpan.Parse(textBox1.Text);
            }
            else
            {
                timeErrorProvider.SetError(textBox1, "Time must be HH:MM:SS");
            }
        }

        private bool IsTimeValid()
        {
            try
            {
                TimeSpan.Parse(textBox1.Text);
            }
            catch
            {
                return false;
            }

            return true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (IsTimeValid())
            {
                TimeSpan time = TimeSpan.Parse(textBox1.Text); 
                if (msg.Msg == 0x100)
                {
                    if (msg.WParam.ToInt32() == 0xbd)
                    {
                        time -= TimeSpan.FromMinutes(1);
                        if (time < TimeSpan.Zero)
                        {
                            time = TimeSpan.Zero;
                        }
                        textBox1.Text = time.ToString(); 
                        return true; 
                    }
                    else if (msg.WParam.ToInt32() == 187)
                    {
                        time += TimeSpan.FromMinutes(1);

                        textBox1.Text = time.ToString(); 
                        return true; 
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);

        }
    }
}

