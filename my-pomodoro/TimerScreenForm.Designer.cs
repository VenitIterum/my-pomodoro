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
            this.ReplayButton = new System.Windows.Forms.PictureBox();
            this.PauseButton = new System.Windows.Forms.PictureBox();
            this.PlayButton = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ReplayButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PauseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.AutoSize = true;
            this.Timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Timer.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Timer.Location = new System.Drawing.Point(12, 24);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(251, 95);
            this.Timer.TabIndex = 0;
            this.Timer.Text = "00:00";
            // 
            // ActualTime
            // 
            this.ActualTime.AutoSize = true;
            this.ActualTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ActualTime.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ActualTime.Location = new System.Drawing.Point(269, 24);
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
            // ReplayButton
            // 
            this.ReplayButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ReplayButton.BackgroundImage = global::my_pomodoro.Properties.Resources.replay;
            this.ReplayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ReplayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReplayButton.InitialImage = null;
            this.ReplayButton.Location = new System.Drawing.Point(439, 82);
            this.ReplayButton.Name = "ReplayButton";
            this.ReplayButton.Size = new System.Drawing.Size(50, 50);
            this.ReplayButton.TabIndex = 9;
            this.ReplayButton.TabStop = false;
            this.ReplayButton.Click += new System.EventHandler(this.ReplayButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PauseButton.BackgroundImage = global::my_pomodoro.Properties.Resources.pause;
            this.PauseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PauseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PauseButton.InitialImage = null;
            this.PauseButton.Location = new System.Drawing.Point(354, 82);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(50, 50);
            this.PauseButton.TabIndex = 8;
            this.PauseButton.TabStop = false;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PlayButton.BackgroundImage = global::my_pomodoro.Properties.Resources.play_button_arrowhead;
            this.PlayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PlayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayButton.InitialImage = null;
            this.PlayButton.Location = new System.Drawing.Point(269, 82);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(50, 50);
            this.PlayButton.TabIndex = 7;
            this.PlayButton.TabStop = false;
            this.PlayButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PlayButton_MouseClick);
            // 
            // closeButton
            // 
            this.closeButton.BackgroundImage = global::my_pomodoro.Properties.Resources.close;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.InitialImage = null;
            this.closeButton.Location = new System.Drawing.Point(508, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(30, 30);
            this.closeButton.TabIndex = 6;
            this.closeButton.TabStop = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // TimerScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(550, 144);
            this.Controls.Add(this.ReplayButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.ActualTime);
            this.Controls.Add(this.Timer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TimerScreenForm";
            this.Text = "TimerScreenForm";
            this.Load += new System.EventHandler(this.TimerScreenForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TimerScreenForm_MouseDown);
            this.MouseEnter += new System.EventHandler(this.TimerScreenForm_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.TimerScreenForm_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TimerScreenForm_MouseMove);
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
    }
}