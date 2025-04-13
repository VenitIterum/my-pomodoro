namespace my_pomodoro
{
    partial class TimerScreenForm
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
            this.Timer = new System.Windows.Forms.Label();
            this.ActualTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.ActualTimeLabel = new System.Windows.Forms.Label();
            this.SwapButton = new System.Windows.Forms.PictureBox();
            this.SettingsButton = new System.Windows.Forms.PictureBox();
            this.ReplayButton = new System.Windows.Forms.PictureBox();
            this.PauseButton = new System.Windows.Forms.PictureBox();
            this.PlayButton = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SwapButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReplayButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PauseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.AutoSize = true;
            this.Timer.BackColor = System.Drawing.Color.Transparent;
            this.Timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Timer.ForeColor = System.Drawing.Color.White;
            this.Timer.Location = new System.Drawing.Point(32, 9);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(251, 95);
            this.Timer.TabIndex = 0;
            this.Timer.Text = "00:00";
            this.Timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ActualTime
            // 
            this.ActualTime.AutoSize = true;
            this.ActualTime.BackColor = System.Drawing.Color.Transparent;
            this.ActualTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ActualTime.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ActualTime.Location = new System.Drawing.Point(316, 118);
            this.ActualTime.Name = "ActualTime";
            this.ActualTime.Size = new System.Drawing.Size(102, 39);
            this.ActualTime.TabIndex = 2;
            this.ActualTime.Text = "00:00";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // ActualTimeLabel
            // 
            this.ActualTimeLabel.AutoSize = true;
            this.ActualTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.ActualTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ActualTimeLabel.ForeColor = System.Drawing.Color.White;
            this.ActualTimeLabel.Location = new System.Drawing.Point(319, 98);
            this.ActualTimeLabel.Name = "ActualTimeLabel";
            this.ActualTimeLabel.Size = new System.Drawing.Size(137, 20);
            this.ActualTimeLabel.TabIndex = 10;
            this.ActualTimeLabel.Text = "Текущее время";
            // 
            // SwapButton
            // 
            this.SwapButton.BackColor = System.Drawing.Color.White;
            this.SwapButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SwapButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SwapButton.Image = global::my_pomodoro.Properties.Resources.swap_button;
            this.SwapButton.InitialImage = null;
            this.SwapButton.Location = new System.Drawing.Point(243, 108);
            this.SwapButton.Name = "SwapButton";
            this.SwapButton.Size = new System.Drawing.Size(50, 50);
            this.SwapButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SwapButton.TabIndex = 12;
            this.SwapButton.TabStop = false;
            this.SwapButton.Click += new System.EventHandler(this.SwapButton_Click);
            this.SwapButton.MouseEnter += new System.EventHandler(this.SwapButton_MouseEnter);
            this.SwapButton.MouseLeave += new System.EventHandler(this.SwapButton_MouseLeave);
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.Transparent;
            this.SettingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SettingsButton.Image = global::my_pomodoro.Properties.Resources.settings;
            this.SettingsButton.Location = new System.Drawing.Point(508, 127);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(30, 30);
            this.SettingsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SettingsButton.TabIndex = 11;
            this.SettingsButton.TabStop = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            this.SettingsButton.MouseEnter += new System.EventHandler(this.SettingsButton_MouseEnter);
            this.SettingsButton.MouseLeave += new System.EventHandler(this.SettingsButton_MouseLeave);
            // 
            // ReplayButton
            // 
            this.ReplayButton.BackColor = System.Drawing.Color.White;
            this.ReplayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ReplayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReplayButton.Image = global::my_pomodoro.Properties.Resources.replay;
            this.ReplayButton.InitialImage = null;
            this.ReplayButton.Location = new System.Drawing.Point(170, 108);
            this.ReplayButton.Name = "ReplayButton";
            this.ReplayButton.Size = new System.Drawing.Size(50, 50);
            this.ReplayButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ReplayButton.TabIndex = 9;
            this.ReplayButton.TabStop = false;
            this.ReplayButton.Click += new System.EventHandler(this.ReplayButton_Click);
            this.ReplayButton.MouseEnter += new System.EventHandler(this.ReplayButton_MouseEnter);
            this.ReplayButton.MouseLeave += new System.EventHandler(this.ReplayButton_MouseLeave);
            // 
            // PauseButton
            // 
            this.PauseButton.BackColor = System.Drawing.Color.White;
            this.PauseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PauseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PauseButton.Image = global::my_pomodoro.Properties.Resources.pause;
            this.PauseButton.InitialImage = null;
            this.PauseButton.Location = new System.Drawing.Point(98, 107);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(50, 50);
            this.PauseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PauseButton.TabIndex = 8;
            this.PauseButton.TabStop = false;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            this.PauseButton.MouseEnter += new System.EventHandler(this.PauseButton_MouseEnter);
            this.PauseButton.MouseLeave += new System.EventHandler(this.PauseButton_MouseLeave);
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.Color.White;
            this.PlayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PlayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayButton.Image = global::my_pomodoro.Properties.Resources.play_button_arrowhead;
            this.PlayButton.InitialImage = null;
            this.PlayButton.Location = new System.Drawing.Point(28, 107);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(50, 50);
            this.PlayButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PlayButton.TabIndex = 7;
            this.PlayButton.TabStop = false;
            this.PlayButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PlayButton_MouseClick);
            this.PlayButton.MouseEnter += new System.EventHandler(this.PlayButton_MouseEnter);
            this.PlayButton.MouseLeave += new System.EventHandler(this.PlayButton_MouseLeave);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Image = global::my_pomodoro.Properties.Resources.close;
            this.closeButton.InitialImage = null;
            this.closeButton.Location = new System.Drawing.Point(508, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(30, 30);
            this.closeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeButton.TabIndex = 6;
            this.closeButton.TabStop = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // TimerScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(550, 170);
            this.Controls.Add(this.SwapButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.ActualTimeLabel);
            this.Controls.Add(this.ReplayButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.ActualTime);
            this.Controls.Add(this.Timer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TimerScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TimerScreenForm";
            this.Load += new System.EventHandler(this.TimerScreenForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TimerScreenForm_MouseDown);
            this.MouseEnter += new System.EventHandler(this.TimerScreenForm_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.TimerScreenForm_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TimerScreenForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.SwapButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReplayButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PauseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Timer;
        private System.Windows.Forms.Label ActualTime;
        private System.Windows.Forms.PictureBox closeButton;
        private System.Windows.Forms.PictureBox PlayButton;
        private System.Windows.Forms.PictureBox PauseButton;
        private System.Windows.Forms.PictureBox ReplayButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label ActualTimeLabel;
        private System.Windows.Forms.PictureBox SettingsButton;
        private System.Windows.Forms.PictureBox SwapButton;
    }
}