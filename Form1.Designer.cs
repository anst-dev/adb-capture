namespace adb_tool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Stop and dispose timers
                if (autoCaptureTimer != null)
                {
                    autoCaptureTimer.Stop();
                    autoCaptureTimer.Dispose();
                }
                
                if (countdownTimer != null)
                {
                    countdownTimer.Stop();
                    countdownTimer.Dispose();
                }
                
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            autoCaptureModeToolStripMenuItem = new ToolStripMenuItem();
            enableAutoCaptureModeToolStripMenuItem = new ToolStripMenuItem();
            disableAutoCaptureModeToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            autoCaptureIntervalToolStripMenuItem = new ToolStripMenuItem();
            interval3sToolStripMenuItem = new ToolStripMenuItem();
            interval5sToolStripMenuItem = new ToolStripMenuItem();
            interval10sToolStripMenuItem = new ToolStripMenuItem();
            autoCaptureProgressBar = new ProgressBar();
            autoCaptureStatusLabel = new Label();
            deviceScreenPanel = new Panel();
            deviceScreenPictureBox = new PictureBox();
            rightPanel = new Panel();
            deviceComboBox = new ComboBox();
            reloadDevicesButton = new Button();
            captureGroupBox = new GroupBox();
            cropImageButton = new Button();
            connectNoxButton = new Button();
            captureButton = new Button();
            screenResolutionGroupBox = new GroupBox();
            widthLabel = new Label();
            widthValueLabel = new Label();
            heightLabel = new Label();
            heightValueLabel = new Label();
            coordinatesGroupBox = new GroupBox();
            xLabel = new Label();
            xValueLabel = new Label();
            yLabel = new Label();
            yValueLabel = new Label();
            clickPositionButton = new Button();
            coordinatesTextBox = new TextBox();
            percentGroupBox = new GroupBox();
            xPercentLabel = new Label();
            xPercentValueLabel = new Label();
            yPercentLabel = new Label();
            yPercentValueLabel = new Label();
            clickPercentButton = new Button();
            percentTextBox = new TextBox();
            menuStrip1.SuspendLayout();
            deviceScreenPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)deviceScreenPictureBox).BeginInit();
            rightPanel.SuspendLayout();
            captureGroupBox.SuspendLayout();
            screenResolutionGroupBox.SuspendLayout();
            coordinatesGroupBox.SuspendLayout();
            percentGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(950, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { autoCaptureModeToolStripMenuItem, toolStripSeparator1, autoCaptureIntervalToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // autoCaptureModeToolStripMenuItem
            // 
            autoCaptureModeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { enableAutoCaptureModeToolStripMenuItem, disableAutoCaptureModeToolStripMenuItem });
            autoCaptureModeToolStripMenuItem.Name = "autoCaptureModeToolStripMenuItem";
            autoCaptureModeToolStripMenuItem.Size = new Size(180, 22);
            autoCaptureModeToolStripMenuItem.Text = "Auto Capture Mode";
            // 
            // enableAutoCaptureModeToolStripMenuItem
            // 
            enableAutoCaptureModeToolStripMenuItem.Name = "enableAutoCaptureModeToolStripMenuItem";
            enableAutoCaptureModeToolStripMenuItem.Size = new Size(180, 22);
            enableAutoCaptureModeToolStripMenuItem.Text = "✅ Enable Auto Capture";
            enableAutoCaptureModeToolStripMenuItem.Click += enableAutoCaptureModeToolStripMenuItem_Click;
            // 
            // disableAutoCaptureModeToolStripMenuItem
            // 
            disableAutoCaptureModeToolStripMenuItem.Name = "disableAutoCaptureModeToolStripMenuItem";
            disableAutoCaptureModeToolStripMenuItem.Size = new Size(180, 22);
            disableAutoCaptureModeToolStripMenuItem.Text = "❌ Disable Auto Capture";
            disableAutoCaptureModeToolStripMenuItem.Click += disableAutoCaptureModeToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // autoCaptureIntervalToolStripMenuItem
            // 
            autoCaptureIntervalToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { interval3sToolStripMenuItem, interval5sToolStripMenuItem, interval10sToolStripMenuItem });
            autoCaptureIntervalToolStripMenuItem.Name = "autoCaptureIntervalToolStripMenuItem";
            autoCaptureIntervalToolStripMenuItem.Size = new Size(180, 22);
            autoCaptureIntervalToolStripMenuItem.Text = "Auto Capture Interval";
            // 
            // interval3sToolStripMenuItem
            // 
            interval3sToolStripMenuItem.Name = "interval3sToolStripMenuItem";
            interval3sToolStripMenuItem.Size = new Size(180, 22);
            interval3sToolStripMenuItem.Text = "3 seconds";
            interval3sToolStripMenuItem.Click += interval3sToolStripMenuItem_Click;
            // 
            // interval5sToolStripMenuItem
            // 
            interval5sToolStripMenuItem.Name = "interval5sToolStripMenuItem";
            interval5sToolStripMenuItem.Size = new Size(180, 22);
            interval5sToolStripMenuItem.Text = "5 seconds ✓";
            interval5sToolStripMenuItem.Click += interval5sToolStripMenuItem_Click;
            // 
            // interval10sToolStripMenuItem
            // 
            interval10sToolStripMenuItem.Name = "interval10sToolStripMenuItem";
            interval10sToolStripMenuItem.Size = new Size(180, 22);
            interval10sToolStripMenuItem.Text = "10 seconds";
            interval10sToolStripMenuItem.Click += interval10sToolStripMenuItem_Click;
            // 
            // autoCaptureProgressBar
            // 
            autoCaptureProgressBar.Location = new Point(12, 790);
            autoCaptureProgressBar.Name = "autoCaptureProgressBar";
            autoCaptureProgressBar.Size = new Size(918, 20);
            autoCaptureProgressBar.TabIndex = 6;
            autoCaptureProgressBar.Visible = false;
            // 
            // autoCaptureStatusLabel
            // 
            autoCaptureStatusLabel.BackColor = Color.Transparent;
            autoCaptureStatusLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            autoCaptureStatusLabel.ForeColor = Color.White;
            autoCaptureStatusLabel.Location = new Point(12, 815);
            autoCaptureStatusLabel.Name = "autoCaptureStatusLabel";
            autoCaptureStatusLabel.Size = new Size(918, 20);
            autoCaptureStatusLabel.TabIndex = 7;
            autoCaptureStatusLabel.Text = "Auto Capture: Disabled";
            autoCaptureStatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // deviceScreenPanel
            // 
            deviceScreenPanel.BackColor = Color.White;
            deviceScreenPanel.BorderStyle = BorderStyle.FixedSingle;
            deviceScreenPanel.Controls.Add(deviceScreenPictureBox);
            deviceScreenPanel.Location = new Point(12, 35);
            deviceScreenPanel.Name = "deviceScreenPanel";
            deviceScreenPanel.Size = new Size(500, 750);
            deviceScreenPanel.TabIndex = 1;
            // 
            // deviceScreenPictureBox
            // 
            deviceScreenPictureBox.BackColor = Color.LightGray;
            deviceScreenPictureBox.Location = new Point(10, 10);
            deviceScreenPictureBox.Name = "deviceScreenPictureBox";
            deviceScreenPictureBox.Size = new Size(480, 730);
            deviceScreenPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            deviceScreenPictureBox.TabIndex = 0;
            deviceScreenPictureBox.TabStop = false;
            deviceScreenPictureBox.MouseClick += deviceScreenPictureBox_MouseClick;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(deviceComboBox);
            rightPanel.Controls.Add(reloadDevicesButton);
            rightPanel.Controls.Add(captureGroupBox);
            rightPanel.Controls.Add(screenResolutionGroupBox);
            rightPanel.Controls.Add(coordinatesGroupBox);
            rightPanel.Controls.Add(percentGroupBox);
            rightPanel.Location = new Point(530, 35);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(400, 750);
            rightPanel.TabIndex = 2;
            // 
            // deviceComboBox
            // 
            deviceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            deviceComboBox.Font = new Font("Microsoft Sans Serif", 10F);
            deviceComboBox.FormattingEnabled = true;
            deviceComboBox.Items.AddRange(new object[] { "192.168.1.12:5555" });
            deviceComboBox.Location = new Point(15, 15);
            deviceComboBox.Name = "deviceComboBox";
            deviceComboBox.Size = new Size(250, 24);
            deviceComboBox.TabIndex = 0;
            // 
            // reloadDevicesButton
            // 
            reloadDevicesButton.BackColor = Color.RoyalBlue;
            reloadDevicesButton.FlatStyle = FlatStyle.Flat;
            reloadDevicesButton.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            reloadDevicesButton.ForeColor = Color.White;
            reloadDevicesButton.Location = new Point(280, 15);
            reloadDevicesButton.Name = "reloadDevicesButton";
            reloadDevicesButton.Size = new Size(110, 24);
            reloadDevicesButton.TabIndex = 1;
            reloadDevicesButton.Text = "Reload devices";
            reloadDevicesButton.UseVisualStyleBackColor = false;
            // 
            // captureGroupBox
            // 
            captureGroupBox.Controls.Add(cropImageButton);
            captureGroupBox.Controls.Add(connectNoxButton);
            captureGroupBox.Controls.Add(captureButton);
            captureGroupBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            captureGroupBox.ForeColor = Color.RoyalBlue;
            captureGroupBox.Location = new Point(15, 60);
            captureGroupBox.Name = "captureGroupBox";
            captureGroupBox.Size = new Size(375, 150);
            captureGroupBox.TabIndex = 2;
            captureGroupBox.TabStop = false;
            captureGroupBox.Text = "Capture";
            // 
            // cropImageButton
            // 
            cropImageButton.BackColor = Color.RoyalBlue;
            cropImageButton.FlatStyle = FlatStyle.Flat;
            cropImageButton.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            cropImageButton.ForeColor = Color.White;
            cropImageButton.Location = new Point(20, 100);
            cropImageButton.Name = "cropImageButton";
            cropImageButton.Size = new Size(100, 30);
            cropImageButton.TabIndex = 2;
            cropImageButton.Text = "Crop image";
            cropImageButton.UseVisualStyleBackColor = false;
            // 
            // connectNoxButton
            // 
            connectNoxButton.BackColor = Color.RoyalBlue;
            connectNoxButton.FlatStyle = FlatStyle.Flat;
            connectNoxButton.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            connectNoxButton.ForeColor = Color.White;
            connectNoxButton.Location = new Point(140, 100);
            connectNoxButton.Name = "connectNoxButton";
            connectNoxButton.Size = new Size(100, 30);
            connectNoxButton.TabIndex = 1;
            connectNoxButton.Text = "Connect Nox";
            connectNoxButton.UseVisualStyleBackColor = false;
            // 
            // captureButton
            // 
            captureButton.BackColor = Color.RoyalBlue;
            captureButton.FlatStyle = FlatStyle.Flat;
            captureButton.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            captureButton.ForeColor = Color.White;
            captureButton.Location = new Point(130, 30);
            captureButton.Name = "captureButton";
            captureButton.Size = new Size(120, 50);
            captureButton.TabIndex = 0;
            captureButton.Text = "📷\nCapture";
            captureButton.UseVisualStyleBackColor = false;
            captureButton.Click += captureButton_Click;
            // 
            // screenResolutionGroupBox
            // 
            screenResolutionGroupBox.Controls.Add(widthLabel);
            screenResolutionGroupBox.Controls.Add(widthValueLabel);
            screenResolutionGroupBox.Controls.Add(heightLabel);
            screenResolutionGroupBox.Controls.Add(heightValueLabel);
            screenResolutionGroupBox.Font = new Font("Microsoft Sans Serif", 10F);
            screenResolutionGroupBox.ForeColor = Color.Gray;
            screenResolutionGroupBox.Location = new Point(15, 230);
            screenResolutionGroupBox.Name = "screenResolutionGroupBox";
            screenResolutionGroupBox.Size = new Size(375, 80);
            screenResolutionGroupBox.TabIndex = 3;
            screenResolutionGroupBox.TabStop = false;
            screenResolutionGroupBox.Text = "Screen resolution";
            // 
            // widthLabel
            // 
            widthLabel.AutoSize = true;
            widthLabel.Font = new Font("Microsoft Sans Serif", 9F);
            widthLabel.ForeColor = Color.Black;
            widthLabel.Location = new Point(20, 30);
            widthLabel.Name = "widthLabel";
            widthLabel.Size = new Size(41, 15);
            widthLabel.TabIndex = 0;
            widthLabel.Text = "Width:";
            // 
            // widthValueLabel
            // 
            widthValueLabel.AutoSize = true;
            widthValueLabel.Font = new Font("Microsoft Sans Serif", 9F);
            widthValueLabel.ForeColor = Color.RoyalBlue;
            widthValueLabel.Location = new Point(80, 30);
            widthValueLabel.Name = "widthValueLabel";
            widthValueLabel.Size = new Size(51, 15);
            widthValueLabel.TabIndex = 1;
            widthValueLabel.Text = "1220 px";
            // 
            // heightLabel
            // 
            heightLabel.AutoSize = true;
            heightLabel.Font = new Font("Microsoft Sans Serif", 9F);
            heightLabel.ForeColor = Color.Black;
            heightLabel.Location = new Point(20, 50);
            heightLabel.Name = "heightLabel";
            heightLabel.Size = new Size(46, 15);
            heightLabel.TabIndex = 2;
            heightLabel.Text = "Height:";
            // 
            // heightValueLabel
            // 
            heightValueLabel.AutoSize = true;
            heightValueLabel.Font = new Font("Microsoft Sans Serif", 9F);
            heightValueLabel.ForeColor = Color.RoyalBlue;
            heightValueLabel.Location = new Point(80, 50);
            heightValueLabel.Name = "heightValueLabel";
            heightValueLabel.Size = new Size(51, 15);
            heightValueLabel.TabIndex = 3;
            heightValueLabel.Text = "2712 px";
            // 
            // coordinatesGroupBox
            // 
            coordinatesGroupBox.Controls.Add(xLabel);
            coordinatesGroupBox.Controls.Add(xValueLabel);
            coordinatesGroupBox.Controls.Add(yLabel);
            coordinatesGroupBox.Controls.Add(yValueLabel);
            coordinatesGroupBox.Controls.Add(clickPositionButton);
            coordinatesGroupBox.Controls.Add(coordinatesTextBox);
            coordinatesGroupBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            coordinatesGroupBox.ForeColor = Color.RoyalBlue;
            coordinatesGroupBox.Location = new Point(15, 330);
            coordinatesGroupBox.Name = "coordinatesGroupBox";
            coordinatesGroupBox.Size = new Size(375, 180);
            coordinatesGroupBox.TabIndex = 4;
            coordinatesGroupBox.TabStop = false;
            coordinatesGroupBox.Text = "Coordinates";
            // 
            // xLabel
            // 
            xLabel.AutoSize = true;
            xLabel.Font = new Font("Microsoft Sans Serif", 9F);
            xLabel.ForeColor = Color.Black;
            xLabel.Location = new Point(20, 30);
            xLabel.Name = "xLabel";
            xLabel.Size = new Size(18, 15);
            xLabel.TabIndex = 0;
            xLabel.Text = "X:";
            // 
            // xValueLabel
            // 
            xValueLabel.AutoSize = true;
            xValueLabel.Font = new Font("Microsoft Sans Serif", 9F);
            xValueLabel.ForeColor = Color.RoyalBlue;
            xValueLabel.Location = new Point(50, 30);
            xValueLabel.Name = "xValueLabel";
            xValueLabel.Size = new Size(38, 15);
            xValueLabel.TabIndex = 1;
            xValueLabel.Text = "743.2";
            // 
            // yLabel
            // 
            yLabel.AutoSize = true;
            yLabel.Font = new Font("Microsoft Sans Serif", 9F);
            yLabel.ForeColor = Color.Black;
            yLabel.Location = new Point(200, 30);
            yLabel.Name = "yLabel";
            yLabel.Size = new Size(17, 15);
            yLabel.TabIndex = 2;
            yLabel.Text = "Y:";
            // 
            // yValueLabel
            // 
            yValueLabel.AutoSize = true;
            yValueLabel.Font = new Font("Microsoft Sans Serif", 9F);
            yValueLabel.ForeColor = Color.RoyalBlue;
            yValueLabel.Location = new Point(230, 30);
            yValueLabel.Name = "yValueLabel";
            yValueLabel.Size = new Size(45, 15);
            yValueLabel.TabIndex = 3;
            yValueLabel.Text = "1178.7";
            // 
            // clickPositionButton
            // 
            clickPositionButton.BackColor = Color.RoyalBlue;
            clickPositionButton.FlatStyle = FlatStyle.Flat;
            clickPositionButton.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            clickPositionButton.ForeColor = Color.White;
            clickPositionButton.Location = new Point(250, 60);
            clickPositionButton.Name = "clickPositionButton";
            clickPositionButton.Size = new Size(100, 30);
            clickPositionButton.TabIndex = 4;
            clickPositionButton.Text = "Click Position";
            clickPositionButton.UseVisualStyleBackColor = false;
            // 
            // coordinatesTextBox
            // 
            coordinatesTextBox.BackColor = Color.LightBlue;
            coordinatesTextBox.Font = new Font("Microsoft Sans Serif", 8F);
            coordinatesTextBox.Location = new Point(20, 100);
            coordinatesTextBox.Multiline = true;
            coordinatesTextBox.Name = "coordinatesTextBox";
            coordinatesTextBox.ReadOnly = true;
            coordinatesTextBox.Size = new Size(330, 60);
            coordinatesTextBox.TabIndex = 5;
            coordinatesTextBox.Text = "KAutoHelper.ADBHelper.Tap(deviceID, 743.2,1178.7);";
            // 
            // percentGroupBox
            // 
            percentGroupBox.Controls.Add(xPercentLabel);
            percentGroupBox.Controls.Add(xPercentValueLabel);
            percentGroupBox.Controls.Add(yPercentLabel);
            percentGroupBox.Controls.Add(yPercentValueLabel);
            percentGroupBox.Controls.Add(clickPercentButton);
            percentGroupBox.Controls.Add(percentTextBox);
            percentGroupBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            percentGroupBox.ForeColor = Color.RoyalBlue;
            percentGroupBox.Location = new Point(15, 530);
            percentGroupBox.Name = "percentGroupBox";
            percentGroupBox.Size = new Size(375, 180);
            percentGroupBox.TabIndex = 5;
            percentGroupBox.TabStop = false;
            percentGroupBox.Text = "Percent";
            // 
            // xPercentLabel
            // 
            xPercentLabel.AutoSize = true;
            xPercentLabel.Font = new Font("Microsoft Sans Serif", 9F);
            xPercentLabel.ForeColor = Color.Black;
            xPercentLabel.Location = new Point(20, 30);
            xPercentLabel.Name = "xPercentLabel";
            xPercentLabel.Size = new Size(29, 15);
            xPercentLabel.TabIndex = 0;
            xPercentLabel.Text = "X%:";
            // 
            // xPercentValueLabel
            // 
            xPercentValueLabel.AutoSize = true;
            xPercentValueLabel.Font = new Font("Microsoft Sans Serif", 9F);
            xPercentValueLabel.ForeColor = Color.RoyalBlue;
            xPercentValueLabel.Location = new Point(60, 30);
            xPercentValueLabel.Name = "xPercentValueLabel";
            xPercentValueLabel.Size = new Size(31, 15);
            xPercentValueLabel.TabIndex = 1;
            xPercentValueLabel.Text = "60.9";
            // 
            // yPercentLabel
            // 
            yPercentLabel.AutoSize = true;
            yPercentLabel.Font = new Font("Microsoft Sans Serif", 9F);
            yPercentLabel.ForeColor = Color.Black;
            yPercentLabel.Location = new Point(200, 30);
            yPercentLabel.Name = "yPercentLabel";
            yPercentLabel.Size = new Size(28, 15);
            yPercentLabel.TabIndex = 2;
            yPercentLabel.Text = "Y%:";
            // 
            // yPercentValueLabel
            // 
            yPercentValueLabel.AutoSize = true;
            yPercentValueLabel.Font = new Font("Microsoft Sans Serif", 9F);
            yPercentValueLabel.ForeColor = Color.RoyalBlue;
            yPercentValueLabel.Location = new Point(240, 30);
            yPercentValueLabel.Name = "yPercentValueLabel";
            yPercentValueLabel.Size = new Size(31, 15);
            yPercentValueLabel.TabIndex = 3;
            yPercentValueLabel.Text = "43.5";
            // 
            // clickPercentButton
            // 
            clickPercentButton.BackColor = Color.RoyalBlue;
            clickPercentButton.FlatStyle = FlatStyle.Flat;
            clickPercentButton.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            clickPercentButton.ForeColor = Color.White;
            clickPercentButton.Location = new Point(250, 60);
            clickPercentButton.Name = "clickPercentButton";
            clickPercentButton.Size = new Size(100, 30);
            clickPercentButton.TabIndex = 4;
            clickPercentButton.Text = "Click Percent";
            clickPercentButton.UseVisualStyleBackColor = false;
            // 
            // percentTextBox
            // 
            percentTextBox.BackColor = Color.LightBlue;
            percentTextBox.Font = new Font("Microsoft Sans Serif", 8F);
            percentTextBox.Location = new Point(20, 100);
            percentTextBox.Multiline = true;
            percentTextBox.Name = "percentTextBox";
            percentTextBox.ReadOnly = true;
            percentTextBox.Size = new Size(330, 60);
            percentTextBox.TabIndex = 5;
            percentTextBox.Text = "KAutoHelper.ADBHelper.TapByPercent(deviceID, 60.9,43.5);";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 66, 135);
            ClientSize = new Size(950, 850);
            Controls.Add(autoCaptureStatusLabel);
            Controls.Add(autoCaptureProgressBar);
            Controls.Add(rightPanel);
            Controls.Add(deviceScreenPanel);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ADB Capture - Created by K9 from Kteam";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            deviceScreenPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)deviceScreenPictureBox).EndInit();
            rightPanel.ResumeLayout(false);
            captureGroupBox.ResumeLayout(false);
            screenResolutionGroupBox.ResumeLayout(false);
            screenResolutionGroupBox.PerformLayout();
            coordinatesGroupBox.ResumeLayout(false);
            coordinatesGroupBox.PerformLayout();
            percentGroupBox.ResumeLayout(false);
            percentGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel deviceScreenPanel;
        private System.Windows.Forms.PictureBox deviceScreenPictureBox;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.ComboBox deviceComboBox;
        private System.Windows.Forms.Button reloadDevicesButton;
        private System.Windows.Forms.GroupBox captureGroupBox;
        private System.Windows.Forms.Button cropImageButton;
        private System.Windows.Forms.Button connectNoxButton;
        private System.Windows.Forms.Button captureButton;
        private System.Windows.Forms.GroupBox screenResolutionGroupBox;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label widthValueLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label heightValueLabel;
        private System.Windows.Forms.GroupBox coordinatesGroupBox;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label xValueLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label yValueLabel;
        private System.Windows.Forms.Button clickPositionButton;
        private System.Windows.Forms.TextBox coordinatesTextBox;
        private System.Windows.Forms.GroupBox percentGroupBox;
        private System.Windows.Forms.Label xPercentLabel;
        private System.Windows.Forms.Label xPercentValueLabel;
        private System.Windows.Forms.Label yPercentLabel;
        private System.Windows.Forms.Label yPercentValueLabel;
        private System.Windows.Forms.Button clickPercentButton;
        private System.Windows.Forms.TextBox percentTextBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem autoCaptureModeToolStripMenuItem;
        private ToolStripMenuItem enableAutoCaptureModeToolStripMenuItem;
        private ToolStripMenuItem disableAutoCaptureModeToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem autoCaptureIntervalToolStripMenuItem;
        private ToolStripMenuItem interval3sToolStripMenuItem;
        private ToolStripMenuItem interval5sToolStripMenuItem;
        private ToolStripMenuItem interval10sToolStripMenuItem;
        private ProgressBar autoCaptureProgressBar;
        private Label autoCaptureStatusLabel;
        private System.Windows.Forms.Timer autoCaptureTimer;
        private System.Windows.Forms.Timer countdownTimer;
    }
}
