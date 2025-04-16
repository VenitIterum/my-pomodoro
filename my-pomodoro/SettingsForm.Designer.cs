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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.CloseSettingsButton = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ProductVersionLabel = new System.Windows.Forms.Label();
            this.Verson = new System.Windows.Forms.Label();
            this.textBoxWork = new System.Windows.Forms.TextBox();
            this.textBoxRest = new System.Windows.Forms.TextBox();
            this.labelWork = new System.Windows.Forms.Label();
            this.labelFree = new System.Windows.Forms.Label();
            this.labelMinWork = new System.Windows.Forms.Label();
            this.labelMinFree = new System.Windows.Forms.Label();
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
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Настройки";
            // 
            // ProductVersionLabel
            // 
            this.ProductVersionLabel.AutoSize = true;
            this.ProductVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.ProductVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductVersionLabel.ForeColor = System.Drawing.Color.White;
            this.ProductVersionLabel.Location = new System.Drawing.Point(90, 224);
            this.ProductVersionLabel.Name = "ProductVersionLabel";
            this.ProductVersionLabel.Size = new System.Drawing.Size(57, 20);
            this.ProductVersionLabel.TabIndex = 2;
            this.ProductVersionLabel.Text = "0.0.0.0";
            // 
            // Verson
            // 
            this.Verson.AutoSize = true;
            this.Verson.BackColor = System.Drawing.Color.Transparent;
            this.Verson.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Verson.ForeColor = System.Drawing.Color.White;
            this.Verson.Location = new System.Drawing.Point(14, 224);
            this.Verson.Name = "Verson";
            this.Verson.Size = new System.Drawing.Size(75, 20);
            this.Verson.TabIndex = 3;
            this.Verson.Text = "Версия:";
            // 
            // textBoxWork
            // 
            this.textBoxWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxWork.Location = new System.Drawing.Point(109, 69);
            this.textBoxWork.Name = "textBoxWork";
            this.textBoxWork.Size = new System.Drawing.Size(71, 30);
            this.textBoxWork.TabIndex = 4;
            this.textBoxWork.Text = "55";
            // 
            // textBoxRest
            // 
            this.textBoxRest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRest.Location = new System.Drawing.Point(109, 114);
            this.textBoxRest.Name = "textBoxRest";
            this.textBoxRest.Size = new System.Drawing.Size(71, 30);
            this.textBoxRest.TabIndex = 5;
            this.textBoxRest.Text = "5";
            // 
            // labelWork
            // 
            this.labelWork.AutoSize = true;
            this.labelWork.BackColor = System.Drawing.Color.Transparent;
            this.labelWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWork.ForeColor = System.Drawing.Color.White;
            this.labelWork.Location = new System.Drawing.Point(25, 72);
            this.labelWork.Name = "labelWork";
            this.labelWork.Size = new System.Drawing.Size(78, 25);
            this.labelWork.TabIndex = 6;
            this.labelWork.Text = "Работа";
            // 
            // labelFree
            // 
            this.labelFree.AutoSize = true;
            this.labelFree.BackColor = System.Drawing.Color.Transparent;
            this.labelFree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFree.ForeColor = System.Drawing.Color.White;
            this.labelFree.Location = new System.Drawing.Point(25, 114);
            this.labelFree.Name = "labelFree";
            this.labelFree.Size = new System.Drawing.Size(75, 25);
            this.labelFree.TabIndex = 7;
            this.labelFree.Text = "Отдых";
            // 
            // labelMinWork
            // 
            this.labelMinWork.AutoSize = true;
            this.labelMinWork.BackColor = System.Drawing.Color.Transparent;
            this.labelMinWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMinWork.ForeColor = System.Drawing.Color.White;
            this.labelMinWork.Location = new System.Drawing.Point(186, 72);
            this.labelMinWork.Name = "labelMinWork";
            this.labelMinWork.Size = new System.Drawing.Size(56, 25);
            this.labelMinWork.TabIndex = 8;
            this.labelMinWork.Text = "мин.";
            // 
            // labelMinFree
            // 
            this.labelMinFree.AutoSize = true;
            this.labelMinFree.BackColor = System.Drawing.Color.Transparent;
            this.labelMinFree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMinFree.ForeColor = System.Drawing.Color.White;
            this.labelMinFree.Location = new System.Drawing.Point(186, 114);
            this.labelMinFree.Name = "labelMinFree";
            this.labelMinFree.Size = new System.Drawing.Size(56, 25);
            this.labelMinFree.TabIndex = 9;
            this.labelMinFree.Text = "мин.";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.labelMinFree);
            this.Controls.Add(this.labelMinWork);
            this.Controls.Add(this.labelFree);
            this.Controls.Add(this.labelWork);
            this.Controls.Add(this.textBoxRest);
            this.Controls.Add(this.textBoxWork);
            this.Controls.Add(this.Verson);
            this.Controls.Add(this.ProductVersionLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CloseSettingsButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SettingsForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SettingsForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.CloseSettingsButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CloseSettingsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ProductVersionLabel;
        private System.Windows.Forms.Label Verson;
        private System.Windows.Forms.TextBox textBoxWork;
        private System.Windows.Forms.TextBox textBoxRest;
        private System.Windows.Forms.Label labelWork;
        private System.Windows.Forms.Label labelFree;
        private System.Windows.Forms.Label labelMinWork;
        private System.Windows.Forms.Label labelMinFree;
    }
}