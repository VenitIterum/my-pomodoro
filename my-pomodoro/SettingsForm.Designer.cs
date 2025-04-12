namespace my_pomodoro
{
    partial class SettingsForm
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
            this.CloseSettingsButton = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CloseSettingsButton)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseSettingsButton
            // 
            this.CloseSettingsButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseSettingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseSettingsButton.Image = global::my_pomodoro.Properties.Resources.close;
            this.CloseSettingsButton.Location = new System.Drawing.Point(240, 12);
            this.CloseSettingsButton.Name = "CloseSettingsButton";
            this.CloseSettingsButton.Size = new System.Drawing.Size(30, 30);
            this.CloseSettingsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseSettingsButton.TabIndex = 0;
            this.CloseSettingsButton.TabStop = false;
            this.CloseSettingsButton.Click += new System.EventHandler(this.CloseSettingsButton_Click);
            this.CloseSettingsButton.MouseEnter += new System.EventHandler(this.CloseSettingsButton_MouseEnter);
            this.CloseSettingsButton.MouseLeave += new System.EventHandler(this.CloseSettingsButton_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Настройки";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CloseSettingsButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SettingsForm_MouseDown);
            this.MouseEnter += new System.EventHandler(this.SettingsForm_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.SettingsForm_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SettingsForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.CloseSettingsButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CloseSettingsButton;
        private System.Windows.Forms.Label label1;
    }
}