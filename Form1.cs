using System.Diagnostics;

namespace adb_tool
{
    public partial class Form1 : Form
    {
        private double currentX = 0;
        private double currentY = 0;
        private int screenWidth = 1220;
        private int screenHeight = 2712;

        public Form1()
        {
            InitializeComponent();
            InitializeEvents();
            LoadSampleImage();
        }

        private void InitializeEvents()
        {
            // Gán sự kiện cho các nút
            reloadDevicesButton.Click += ReloadDevicesButton_Click;
            connectNoxButton.Click += ConnectNoxButton_Click;
            cropImageButton.Click += CropImageButton_Click;
            clickPositionButton.Click += ClickPositionButton_Click;
            clickPercentButton.Click += ClickPercentButton_Click;
        }

        private void LoadSampleImage()
        {
            // Tạo một hình ảnh mẫu để hiển thị
            try
            {
                // Tạo bitmap mẫu với màu gradient
                Bitmap sampleImage = new Bitmap(400, 700);
                using (Graphics g = Graphics.FromImage(sampleImage))
                {
                    // Tạo gradient từ xanh đến trắng
                    using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                        new Rectangle(0, 0, 400, 700),
                        Color.FromArgb(45, 66, 135),
                        Color.White,
                        System.Drawing.Drawing2D.LinearGradientMode.Vertical))
                    {
                        g.FillRectangle(brush, 0, 0, 400, 700);
                    }
                    
                    // Vẽ text hướng dẫn
                    using (var font = new Font("Arial", 14, FontStyle.Bold))
                    using (var textBrush = new SolidBrush(Color.White))
                    {
                        var text = "📱 Device Screen\n\n🔴 Nhấn 'Capture' để chụp màn hình\n\n👆 Click vào màn hình để chọn tọa độ\n\n📋 Code sẽ tự động tạo bên phải";
                        var textSize = g.MeasureString(text, font);
                        g.DrawString(text, font, textBrush, 
                            (400 - textSize.Width) / 2, 
                            (700 - textSize.Height) / 2);
                    }
                    
                    // Vẽ viền đứt nét
                    using (var pen = new Pen(Color.White, 2))
                    {
                        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        g.DrawRectangle(pen, 20, 20, 360, 660);
                    }
                }
                deviceScreenPictureBox.Image = sampleImage;
                
                // Cập nhật kích thước mẫu
                screenWidth = 400;
                screenHeight = 700;
                widthValueLabel.Text = $"{screenWidth} px";
                heightValueLabel.Text = $"{screenHeight} px";
            }
            catch
            {
                // Nếu không tạo được hình, để trống
            }
        }

        private void captureButton_Click(object sender, EventArgs e)
        {
            string selectedDevice = deviceComboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedDevice))
            {
                MessageBox.Show("Vui lòng chọn thiết bị ADB trước khi chụp màn hình!", "Chưa chọn thiết bị", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Disable nút capture để tránh click nhiều lần
            captureButton.Enabled = false;
            captureButton.Text = "📷\nĐang chụp...";
            
            try
            {
                // Capture màn hình thiết bị ADB
                CaptureScreen();
                MessageBox.Show($"Đã chụp màn hình thiết bị thành công!\nThiết bị: {selectedDevice}\nĐộ phân giải: {screenWidth}x{screenHeight}", 
                    "Chụp màn hình thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chụp màn hình thiết bị ADB:\n{ex.Message}", "Lỗi chụp màn hình", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Enable lại nút capture
                captureButton.Enabled = true;
                captureButton.Text = "📷\nCapture";
            }
        }

        private void CaptureScreen()
        {
            string selectedDevice = deviceComboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedDevice))
            {
                MessageBox.Show("Vui lòng chọn thiết bị trước!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tạo tên file tạm thời
                string tempFileName = Path.Combine(Path.GetTempPath(), "adb_screenshot.png");
                
                // Xóa file cũ nếu có
                if (File.Exists(tempFileName))
                    File.Delete(tempFileName);

                bool captureSuccess = false;

                // Phương pháp 1: Sử dụng exec-out (nhanh hơn, không cần lưu file trên thiết bị)
                try
                {
                    var processInfo = new System.Diagnostics.ProcessStartInfo("adb ", $"-s {selectedDevice} exec-out screencap -p")
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process = System.Diagnostics.Process.Start(processInfo))
                    {
                        using (var output = process.StandardOutput.BaseStream)
                        using (var fileStream = File.Create(tempFileName))
                        {
                            output.CopyTo(fileStream);
                        }
                        
                        process.WaitForExit(10000);
                        
                        if (process.ExitCode == 0 && File.Exists(tempFileName) && new FileInfo(tempFileName).Length > 0)
                        {
                            captureSuccess = true;
                        }
                    }
                }
                catch
                {
                    // Nếu phương pháp 1 thất bại, thử phương pháp 2
                }

                // Phương pháp 2: Sử dụng shell screencap + pull (backup method)
                if (!captureSuccess)
                {
                    // Xóa file cũ nếu có
                    if (File.Exists(tempFileName))
                        File.Delete(tempFileName);

                    // Chụp màn hình và lưu trên thiết bị
                    var processInfo1 = new ProcessStartInfo("adb", $"-s {selectedDevice} shell screencap -p /sdcard/screenshot.png")
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process1 = Process.Start(processInfo1))
                    {
                        process1.WaitForExit(10000);
                        if (process1.ExitCode != 0)
                        {
                            string error = process1.StandardError.ReadToEnd();
                            throw new Exception($"Screencap failed: {error}");
                        }
                    }

                    // Kéo file từ thiết bị về máy tính
                    var processInfo2 = new ProcessStartInfo("adb", $"-s {selectedDevice} pull /sdcard/screenshot.png \"{tempFileName}\"")
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (var process2 = Process.Start(processInfo2))
                    {
                        process2.WaitForExit(10000);
                        if (process2.ExitCode != 0)
                        {
                            string error = process2.StandardError.ReadToEnd();
                            throw new Exception($"Pull file failed: {error}");
                        }
                    }

                    // Xóa file trên thiết bị
                    var processInfo3 = new ProcessStartInfo("adb", $"-s {selectedDevice} shell rm /sdcard/screenshot.png")
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false
                    };
                    
                    using (var process3 = Process.Start(processInfo3))
                    {
                        process3.WaitForExit(5000);
                    }
                }

                // Kiểm tra file có tồn tại không
                if (!File.Exists(tempFileName) || new FileInfo(tempFileName).Length == 0)
                {
                    throw new Exception("Không thể chụp màn hình từ thiết bị. Hãy kiểm tra:\n- Thiết bị đã kết nối chưa\n- USB Debugging đã bật chưa\n- Quyền truy cập storage");
                }

                // Tải ảnh từ file
                Bitmap screenshot;
                using (var fileStream = new FileStream(tempFileName, FileMode.Open, FileAccess.Read))
                {
                    screenshot = new Bitmap(fileStream);
                }

                // Cập nhật kích thước màn hình thiết bị
                screenWidth = screenshot.Width;
                screenHeight = screenshot.Height;
                
                // Cập nhật hiển thị độ phân giải
                widthValueLabel.Text = $"{screenWidth} px";
                heightValueLabel.Text = $"{screenHeight} px";
                
                // Hiển thị ảnh chụp trong PictureBox
                if (deviceScreenPictureBox.Image != null)
                {
                    deviceScreenPictureBox.Image.Dispose();
                }
                deviceScreenPictureBox.Image = screenshot;
                
                // Reset tọa độ
                currentX = 0;
                currentY = 0;
                UpdateCoordinatesDisplay();

                // Xóa file tạm
                try { File.Delete(tempFileName); } catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chụp màn hình thiết bị:\n{ex.Message}\n\nHãy kiểm tra:\n- ADB đã cài đặt chưa\n- Thiết bị đã kết nối chưa\n- USB Debugging đã bật chưa", 
                    "Lỗi ADB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deviceScreenPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            // Tính toán tọa độ thực tế dựa trên vị trí click
            var pictureBox = sender as PictureBox;
            if (pictureBox?.Image != null)
            {
                // Tính tỷ lệ scale của hình ảnh trong PictureBox
                var image = pictureBox.Image;
                var pictureBoxSize = pictureBox.Size;
                var imageSize = image.Size;

                // Tính toán tỷ lệ scale (PictureBox sử dụng Zoom mode)
                float scaleX = (float)imageSize.Width / pictureBoxSize.Width;
                float scaleY = (float)imageSize.Height / pictureBoxSize.Height;
                float scale = Math.Max(scaleX, scaleY);

                // Tính toán offset để căn giữa hình ảnh
                int displayWidth = (int)(imageSize.Width / scale);
                int displayHeight = (int)(imageSize.Height / scale);
                int offsetX = (pictureBoxSize.Width - displayWidth) / 2;
                int offsetY = (pictureBoxSize.Height - displayHeight) / 2;

                // Tính tọa độ thực tế trên hình ảnh gốc
                int adjustedX = e.X - offsetX;
                int adjustedY = e.Y - offsetY;

                if (adjustedX >= 0 && adjustedX <= displayWidth && adjustedY >= 0 && adjustedY <= displayHeight)
                {
                    currentX = adjustedX * scale;
                    currentY = adjustedY * scale;

                    // Đảm bảo tọa độ không vượt quá giới hạn
                    currentX = Math.Max(0, Math.Min(currentX, imageSize.Width));
                    currentY = Math.Max(0, Math.Min(currentY, imageSize.Height));

                    // Cập nhật hiển thị
                    UpdateCoordinatesDisplay();

                    // Hiển thị dấu chấm đỏ tại vị trí click
                    DrawClickMarker(e.X, e.Y);
                }
            }
        }

        private void DrawClickMarker(int x, int y)
        {
            // Tạo một copy của hình ảnh hiện tại và vẽ dấu chấm đỏ
            if (deviceScreenPictureBox.Image != null)
            {
                var originalImage = deviceScreenPictureBox.Image;
                var markedImage = new Bitmap(originalImage);
                
                using (Graphics g = Graphics.FromImage(markedImage))
                {
                    // Vẽ dấu chấm đỏ tại vị trí click
                    using (var brush = new SolidBrush(Color.Red))
                    {
                        g.FillEllipse(brush, x - 5, y - 5, 10, 10);
                    }
                    
                    // Vẽ viền trắng cho dễ nhìn
                    using (var pen = new Pen(Color.White, 2))
                    {
                        g.DrawEllipse(pen, x - 5, y - 5, 10, 10);
                    }
                }
                
                // Cập nhật hình ảnh (tạm thời)
                deviceScreenPictureBox.Image = markedImage;
                
                // Sau 1 giây sẽ trở về hình gốc
                var timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000;
                timer.Tick += (s, e) =>
                {
                    deviceScreenPictureBox.Image = originalImage;
                    markedImage.Dispose();
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
        }

        private void UpdateCoordinatesDisplay()
        {
            // Cập nhật tọa độ
            xValueLabel.Text = currentX.ToString("F1");
            yValueLabel.Text = currentY.ToString("F1");

            // Cập nhật phần trăm
            double xPercent = (currentX / screenWidth) * 100;
            double yPercent = (currentY / screenHeight) * 100;
            
            xPercentValueLabel.Text = xPercent.ToString("F1");
            yPercentValueLabel.Text = yPercent.ToString("F1");

            // Cập nhật code trong textbox
            coordinatesTextBox.Text = $"KAutoHelper.ADBHelper.Tap(deviceID, {currentX:F1},{currentY:F1});";
            percentTextBox.Text = $"KAutoHelper.ADBHelper.TapByPercent(deviceID, {xPercent:F1},{yPercent:F1});";
        }

        private void ReloadDevicesButton_Click(object sender, EventArgs e)
        {
            try
            {
                deviceComboBox.Items.Clear();
                
                // Chạy lệnh adb devices để lấy danh sách thiết bị
                var processInfo = new ProcessStartInfo("adb", "devices")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (var process = Process.Start(processInfo))
                {
                    process.WaitForExit(5000); // Timeout 5 giây
                    
                    if (process.ExitCode != 0)
                    {
                        string error = process.StandardError.ReadToEnd();
                        throw new Exception($"ADB command failed: {error}");
                    }

                    string output = process.StandardOutput.ReadToEnd();
                    string[] lines = output.Split('\n');
                    
                    foreach (string line in lines)
                    {
                        string trimmedLine = line.Trim();
                        if (!string.IsNullOrEmpty(trimmedLine) && 
                            !trimmedLine.StartsWith("List of devices") && 
                            trimmedLine.Contains("device") && 
                            !trimmedLine.Contains("offline"))
                        {
                            string deviceId = trimmedLine.Split('\t')[0];
                            if (!string.IsNullOrEmpty(deviceId))
                            {
                                deviceComboBox.Items.Add(deviceId);
                            }
                        }
                    }
                }
                
                if (deviceComboBox.Items.Count > 0)
                {
                    deviceComboBox.SelectedIndex = 0;
                    MessageBox.Show($"Đã tìm thấy {deviceComboBox.Items.Count} thiết bị ADB!", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thiết bị ADB nào!\n\nHãy kiểm tra:\n- ADB đã cài đặt chưa\n- Thiết bị đã kết nối chưa\n- USB Debugging đã bật chưa", 
                        "Không có thiết bị", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách thiết bị:\n{ex.Message}\n\nHãy kiểm tra ADB đã được cài đặt và thêm vào PATH chưa.", 
                    "Lỗi ADB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConnectNoxButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Kết nối với Nox Player (port mặc định 62001)
                string noxPort = "127.0.0.1:62001";
                string adbCommand = $"adb connect {noxPort}";
                
                var processInfo = new ProcessStartInfo("cmd.exe", $"/c {adbCommand}")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (var process = Process.Start(processInfo))
                {
                    process.WaitForExit(10000);
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    
                    if (output.Contains("connected") || output.Contains("already connected"))
                    {
                        MessageBox.Show($"Đã kết nối thành công với Nox Player!\n{output}", 
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Tự động reload devices
                        ReloadDevicesButton_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show($"Không thể kết nối với Nox Player.\n\nOutput: {output}\nError: {error}\n\nHãy kiểm tra:\n- Nox Player đã mở chưa\n- Port 62001 có đang sử dụng không", 
                            "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kết nối Nox Player:\n{ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CropImageButton_Click(object sender, EventArgs e)
        {
            if (deviceScreenPictureBox.Image != null)
            {
                // Lưu ảnh chụp màn hình
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveDialog.Title = "Lưu ảnh chụp màn hình";
                saveDialog.FileName = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}";
                
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    deviceScreenPictureBox.Image.Save(saveDialog.FileName);
                    MessageBox.Show($"Đã lưu ảnh tại: {saveDialog.FileName}", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Chưa có ảnh để lưu! Hãy chụp màn hình trước.", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClickPositionButton_Click(object sender, EventArgs e)
        {
            string selectedDevice = deviceComboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedDevice))
            {
                MessageBox.Show("Vui lòng chọn thiết bị trước!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Copy code tọa độ vào clipboard
            string code = coordinatesTextBox.Text;
            Clipboard.SetText(code);
            
            // Hỏi có muốn thực hiện tap thật không
            var result = MessageBox.Show($"Đã copy code vào clipboard:\n{code}\n\nTọa độ: ({currentX:F1}, {currentY:F1})\n\nBạn có muốn thực hiện TAP trên thiết bị không?", 
                "Copy thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            if (result == DialogResult.Yes)
            {
                ExecuteTapCommand(selectedDevice, currentX, currentY);
            }
        }

        private void ExecuteTapCommand(string deviceId, double x, double y)
        {
            try
            {
                string adbCommand = $"adb -s {deviceId} shell input tap {x:F0} {y:F0}";
                
                var processInfo = new ProcessStartInfo("cmd.exe", $"/c {adbCommand}")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (var process = Process.Start(processInfo))
                {
                    process.WaitForExit(5000);
                    
                    if (process.ExitCode == 0)
                    {
                        MessageBox.Show($"Đã thực hiện TAP tại ({x:F0}, {y:F0}) trên thiết bị!", 
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string error = process.StandardError.ReadToEnd();
                        MessageBox.Show($"Lỗi khi thực hiện TAP:\n{error}", 
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thực hiện TAP:\n{ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClickPercentButton_Click(object sender, EventArgs e)
        {
            string selectedDevice = deviceComboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedDevice))
            {
                MessageBox.Show("Vui lòng chọn thiết bị trước!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Copy code phần trăm vào clipboard
            string code = percentTextBox.Text;
            Clipboard.SetText(code);
            
            double xPercent = (currentX / screenWidth) * 100;
            double yPercent = (currentY / screenHeight) * 100;
            
            // Hỏi có muốn thực hiện tap thật không
            var result = MessageBox.Show($"Đã copy code vào clipboard:\n{code}\n\nPhần trăm: ({xPercent:F1}%, {yPercent:F1}%)\n\nBạn có muốn thực hiện TAP trên thiết bị không?", 
                "Copy thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            if (result == DialogResult.Yes)
            {
                ExecuteTapCommand(selectedDevice, currentX, currentY);
            }
        }
    }
}
