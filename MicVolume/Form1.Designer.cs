namespace MicVolume
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
            this.setVolumeTimer = new System.Windows.Forms.Timer(this.components);
            this.volumeSlider = new System.Windows.Forms.TrackBar();
            this.speedTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.deviceComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.volumeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // setVolumeTimer
            // 
            this.setVolumeTimer.Enabled = true;
            this.setVolumeTimer.Tick += new System.EventHandler(this.setVolumeTimer_Tick);
            // 
            // volumeSlider
            // 
            this.volumeSlider.Location = new System.Drawing.Point(12, 12);
            this.volumeSlider.Maximum = 100;
            this.volumeSlider.Name = "volumeSlider";
            this.volumeSlider.Size = new System.Drawing.Size(260, 45);
            this.volumeSlider.TabIndex = 0;
            this.volumeSlider.Value = 50;
            this.volumeSlider.Scroll += new System.EventHandler(this.volumeSlider_Scroll);
            // 
            // speedTextBox
            // 
            this.speedTextBox.Location = new System.Drawing.Point(12, 63);
            this.speedTextBox.Name = "speedTextBox";
            this.speedTextBox.Size = new System.Drawing.Size(61, 20);
            this.speedTextBox.TabIndex = 1;
            this.speedTextBox.Text = "500";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Update Speed (ms)";
            // 
            // trayIcon
            // 
            this.trayIcon.Text = "SVA";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // deviceComboBox
            // 
            this.deviceComboBox.FormattingEnabled = true;
            this.deviceComboBox.Location = new System.Drawing.Point(132, 62);
            this.deviceComboBox.Name = "deviceComboBox";
            this.deviceComboBox.Size = new System.Drawing.Size(187, 21);
            this.deviceComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Device";
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(279, 13);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(27, 13);
            this.volumeLabel.TabIndex = 5;
            this.volumeLabel.Text = "50%";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 89);
            this.Controls.Add(this.volumeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deviceComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speedTextBox);
            this.Controls.Add(this.volumeSlider);
            this.Name = "Form1";
            this.Text = "Simple Volume Adjust";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer setVolumeTimer;
        private System.Windows.Forms.TrackBar volumeSlider;
        private System.Windows.Forms.TextBox speedTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ComboBox deviceComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label volumeLabel;
    }
}

