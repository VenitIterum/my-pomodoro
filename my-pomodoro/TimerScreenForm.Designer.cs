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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimerScreenForm));
            this.Timer = new System.Windows.Forms.Label();
            this.ActualTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.ActualTimeLabel = new System.Windows.Forms.Label();
            this.SwapButton = new System.Windows.Forms.PictureBox();
            this.SettingsButton = new System.Windows.Forms.PictureBox();
            this.ReplayButton = new System.Windows.Forms.PictureBox();
            this.PlayButton = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.EndTime = new System.Windows.Forms.Label();
            this.objectForMoveForm = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SwapButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReplayButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectForMoveForm)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.AutoSize = true;
            this.Timer.BackColor = System.Drawing.Color.Transparent;
            this.Timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Timer.ForeColor = System.Drawing.Color.White;
            this.Timer.Location = new System.Drawing.Point(0, 15);
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
            this.ActualTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ActualTime.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ActualTime.Location = new System.Drawing.Point(255, 50);
            this.ActualTime.Name = "ActualTime";
            this.ActualTime.Size = new System.Drawing.Size(91, 36);
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
            this.ActualTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ActualTimeLabel.ForeColor = System.Drawing.Color.White;
            this.ActualTimeLabel.Location = new System.Drawing.Point(255, 30);
            this.ActualTimeLabel.Name = "ActualTimeLabel";
            this.ActualTimeLabel.Size = new System.Drawing.Size(114, 18);
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
            this.SwapButton.Location = new System.Drawing.Point(135, 113);
            this.SwapButton.Name = "SwapButton";
            this.SwapButton.Size = new System.Drawing.Size(30, 30);
            this.SwapButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SwapButton.TabIndex = 12;
            this.SwapButton.TabStop = false;
            this.SwapButton.Click += new System.EventHandler(this.SwapButton_Click);
            this.SwapButton.MouseEnter += new System.EventHandler(this.SwapButton_MouseEnter);
            this.SwapButton.MouseLeave += new System.EventHandler(this.SwapButton_MouseLeave);
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SettingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SettingsButton.Image = global::my_pomodoro.Properties.Resources.settings_active;
            this.SettingsButton.Location = new System.Drawing.Point(3, 3);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(15, 15);
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
            this.ReplayButton.Location = new System.Drawing.Point(84, 113);
            this.ReplayButton.Name = "ReplayButton";
            this.ReplayButton.Size = new System.Drawing.Size(30, 30);
            this.ReplayButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ReplayButton.TabIndex = 9;
            this.ReplayButton.TabStop = false;
            this.ReplayButton.Click += new System.EventHandler(this.ReplayButton_Click);
            this.ReplayButton.MouseEnter += new System.EventHandler(this.ReplayButton_MouseEnter);
            this.ReplayButton.MouseLeave += new System.EventHandler(this.ReplayButton_MouseLeave);
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.Color.Salmon;
            this.PlayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PlayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayButton.Image = global::my_pomodoro.Properties.Resources.play_button_arrowhead;
            this.PlayButton.InitialImage = null;
            this.PlayButton.Location = new System.Drawing.Point(405, 20);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(135, 135);
            this.PlayButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PlayButton.TabIndex = 7;
            this.PlayButton.TabStop = false;
            this.PlayButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PlayButton_MouseClick);
            this.PlayButton.MouseEnter += new System.EventHandler(this.PlayButton_MouseEnter);
            this.PlayButton.MouseLeave += new System.EventHandler(this.PlayButton_MouseLeave);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Image = global::my_pomodoro.Properties.Resources.close_active;
            this.closeButton.InitialImage = null;
            this.closeButton.Location = new System.Drawing.Point(520, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(15, 15);
            this.closeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeButton.TabIndex = 6;
            this.closeButton.TabStop = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "My POMODORO";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(255, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Время окончания";
            // 
            // EndTime
            // 
            this.EndTime.AutoSize = true;
            this.EndTime.BackColor = System.Drawing.Color.Transparent;
            this.EndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EndTime.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.EndTime.Location = new System.Drawing.Point(255, 110);
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(91, 36);
            this.EndTime.TabIndex = 13;
            this.EndTime.Text = "00:00";
            // 
            // objectForMoveForm
            // 
            this.objectForMoveForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.objectForMoveForm.Location = new System.Drawing.Point(0, 0);
            this.objectForMoveForm.Name = "objectForMoveForm";
            this.objectForMoveForm.Size = new System.Drawing.Size(540, 20);
            this.objectForMoveForm.TabIndex = 15;
            this.objectForMoveForm.TabStop = false;
            this.objectForMoveForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.objectForMoveForm_MouseDown);
            this.objectForMoveForm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.objectForMoveForm_MouseMove);
            // 
            // TimerScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(540, 155);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.objectForMoveForm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EndTime);
            this.Controls.Add(this.SwapButton);
            this.Controls.Add(this.ActualTimeLabel);
            this.Controls.Add(this.ReplayButton);
            this.Controls.Add(this.ActualTime);
            this.Controls.Add(this.Timer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TimerScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TimerScreenForm";
            this.Load += new System.EventHandler(this.TimerScreenForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TimerScreenForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.SwapButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReplayButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectForMoveForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Timer;
        private System.Windows.Forms.Label ActualTime;
        private System.Windows.Forms.PictureBox closeButton;
        private System.Windows.Forms.PictureBox PlayButton;
        private System.Windows.Forms.PictureBox ReplayButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label ActualTimeLabel;
        private System.Windows.Forms.PictureBox SettingsButton;
        private System.Windows.Forms.PictureBox SwapButton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label EndTime;
        private System.Windows.Forms.PictureBox objectForMoveForm;
    }
}