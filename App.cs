using System;

using System.Drawing;

using System.Collections;

using System.ComponentModel;

using System.Windows.Forms;

using System.Data;

using System.Runtime.InteropServices;


namespace StopWatch
{
    /// <summary>

    /// Summary description for Form1.

    /// </summary>

    public partial class App : System.Windows.Forms.Form
    {
        private enum TimerMode
        {
            Countup,
            Countdown
        } ;

        [DllImport("user32.dll")]
        static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

        [DllImport("user32.dll")]
        static extern bool MessageBeep(uint uType);

        private TimeSpan _accumulated;
        private int _blinkCount;
        private TimeSpan _countdownTime;
        private bool _counting;
        private TimeSpan _elapsed;
        private GetTimeDlg _getTimeDialog = new GetTimeDlg();
        private TimeSpan _lastBeep = TimeSpan.MinValue; 
        private DateTime _startTime;


        public App()
        {

            //

            // Required for Windows Form Designer support

            //

            InitializeComponent();



            //

            // TODO: Add any constructor code after InitializeComponent call

            //

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



        /// <summary>

        /// The main entry point for the application.

        /// </summary>

        [STAThread]
        static void Main()
        {

            Application.Run(new App());

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool needsUpdate = false;
            if (msg.Msg == 0x100)
            {
                System.Diagnostics.Debug.WriteLine(msg.WParam);
                if (msg.WParam.ToInt32() == 0xbd || msg.WParam.ToInt32() == (int) Keys.Subtract)
                {
                    _countdownTime -= TimeSpan.FromMinutes(1);
                    needsUpdate = true;
                }
                else if (msg.WParam.ToInt32() == 187 || msg.WParam.ToInt32() == (int) Keys.Add)
                {
                    _countdownTime += TimeSpan.FromMinutes(1);
                    needsUpdate = true;
                }
            }

            if (needsUpdate)
            {
                CalculateElapsed();
                UpdateTimerLabel();
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BlinkFrame()
        {
            ++_blinkCount;

            if ((_blinkCount % 2) == 0)
            {
                FlashWindow(this.Handle, true);
            }
        }
        private void CalculateElapsed()
        {
            if (_counting)
            {
                _elapsed = DateTime.Now - _startTime + _accumulated - _countdownTime;
            }
            else
            {
                _elapsed = _accumulated - _countdownTime;
            }
        }
        private void UpdateTimerLabel()
        {
            TimeSpan elapsed = TimeSpan.FromTicks(Math.Abs(_elapsed.Ticks));

            if (this.WindowState != FormWindowState.Minimized)
            {
                lbTimer.Text = string.Format("{4}{0:00}:{1:00}:{2:00}.{3:00}",
                    elapsed.Hours,
                    elapsed.Minutes,
                    elapsed.Seconds,
                    elapsed.Milliseconds / 10,
                    _elapsed >= TimeSpan.Zero ? "+" : "-");
            }
            this.Text = string.Format("T{3}{0:00}:{1:00}:{2:00}",
                elapsed.Hours,
                elapsed.Minutes,
                elapsed.Seconds,
                _elapsed >= TimeSpan.Zero ? "+" : "-");
        }

        private void bCountdownSet_Click(object sender, EventArgs e)
        {
            _getTimeDialog.TimerTime = _countdownTime;
            _getTimeDialog.ShowDialog();
            _countdownTime = _getTimeDialog.TimerTime;
            _accumulated = TimeSpan.Zero;

            CalculateElapsed();
            UpdateTimerLabel();
        }
        private void bDecreaseCountdown_Click(object sender, EventArgs e)
        {
            _countdownTime -= TimeSpan.FromMinutes(1);
            CalculateElapsed();
            UpdateTimerLabel();
        }
        private void bIncreaseCountdown_Click(object sender, EventArgs e)
        {
            _countdownTime += TimeSpan.FromMinutes(1);
            CalculateElapsed();
            UpdateTimerLabel();
        }
        private void bReset_Click(object sender, System.EventArgs e)
        {
            _startTime = DateTime.Now;

            if (_accumulated == TimeSpan.Zero)
            {
                _countdownTime = TimeSpan.Zero;
            }

            _accumulated = TimeSpan.Zero;
            CalculateElapsed();
            UpdateTimerLabel();
        }
        private void bStart_Click(object sender, System.EventArgs e)
        {
            if (bStart.Text == "&Start")
            {
                bStart.Text = "&Stop";
                _startTime = DateTime.Now;
                _counting = true;
            }
            else
            {
                bStart.Text = "&Start";
                _counting = false;
                _accumulated = _accumulated + (DateTime.Now - _startTime);
            }
        }
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CalculateElapsed();

            if (_elapsed > TimeSpan.Zero && _countdownTime > TimeSpan.Zero)
            {
                if (_counting)
                {
                    BlinkFrame();
                    AlarmAudibly(); 
                }
            }

            if (this.WindowState != FormWindowState.Minimized)
            {
                lbTime.Text = DateTime.Now.ToLongTimeString();
            }

            if (_counting)
            {
                UpdateTimerLabel();
            }
        }

        private void AlarmAudibly()
        {
            if ((_lastBeep == TimeSpan.MinValue)
                || (_elapsed - _lastBeep > TimeSpan.FromSeconds(30)))
            {
                if (cbAudibleAlarm.Checked)
                {
                    MessageBeep(0);
                    _lastBeep = _elapsed;
                }
            }
        }

    }
}

