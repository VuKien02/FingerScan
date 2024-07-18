using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using FingerprintRegnition.Controllers;
using FingerprintRegnition.Models;
using System.IO;

namespace FingerprintRegnition
{
    public partial class ThemMoiVanTay : Form
    {
        UserController db = new UserController();

        string hinhAnh_VanTay_FileName = "";
        public ThemMoiVanTay()
        {
            InitializeComponent();
        }
        // Convert Image to byte array
        private byte[] imageToByteArray(Image image)
        {
            if (image == null)
                return null;

            using (var stream = new System.IO.MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }

        // Check số điện thoại
        static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Biểu thức chính quy
            string pattern = @"^0\d{9}$";

            // Kiểm tra nếu số điện thoại khớp với biểu thức chính quy
            return Regex.IsMatch(phoneNumber, pattern);
        }


        // Check Email
        static bool IsValidEmail(string email)
        {
            // Biểu thức chính quy
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Kiểm tra nếu email khớp với biểu thức chính quy
            return Regex.IsMatch(email, pattern);
        }

        // Check Năm Sinh
        static bool IsValidYear(string year)
        {
            // Biểu thức chính quy
            string pattern = @"^(?:1800|18[1-9]\d|19\d\d|20[0-9]\d|202[0-4])$";

            // Lấy năm hiện tại
            int currentYear = DateTime.Now.Year;

            // Kiểm tra năm nằm trong khoảng từ 1800 đến năm hiện tại
            if (Regex.IsMatch(year, pattern))
            {
                int parsedYear;
                if (int.TryParse(year, out parsedYear))
                {
                    return parsedYear <= currentYear;
                }
            }

            return false;
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            UserModel newUser = new UserModel();

            string strHoTen = txtHoTen.Text.Trim();
            string strChucVu = txtChucVu.Text.Trim();
            string strSDT = txtSDT.Text.Trim();
            string strEmail = txtEmail.Text.Trim();
            string strNamSinh = txtNamSinh.Text.Trim();
            byte[] imageData_AnhDaiDien = imageToByteArray(picAnhDaiDien.Image);
            byte[] imageData_AnhVanTay = imageToByteArray(picVanTay.Image);
            string strHinhAnh_VanTay_TenFile = hinhAnh_VanTay_FileName;

            // validate data
            // validate Ảnh đại diện
            if (imageData_AnhDaiDien == null || imageData_AnhDaiDien.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn ảnh đại diện", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // validate Ảnh vân tay
            if (imageData_AnhVanTay == null || imageData_AnhVanTay.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn ảnh vân tay", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // validate HoTen
            if (string.IsNullOrEmpty(strHoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            // validate ChucVu
            if (string.IsNullOrEmpty(strChucVu))
            {
                MessageBox.Show("Vui lòng nhập chức vụ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // validate SDT
            if (string.IsNullOrEmpty(strSDT))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (IsValidPhoneNumber(strSDT)==false)
                {
                    MessageBox.Show("Vui lòng nhập đúng số điện thoại Việt Nam bắt đầu bằng số 0 và có độ dài 10 chữ số!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // validate Email
            if (string.IsNullOrEmpty(strEmail))
            {
                MessageBox.Show("Vui lòng nhập email", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (IsValidEmail(strEmail) == false)
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng email!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // validate NamSinh
            if (string.IsNullOrEmpty(strNamSinh))
            {
                MessageBox.Show("Vui lòng nhập năm sinh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (IsValidYear(strNamSinh) == false)
                {
                    MessageBox.Show("Vui lòng nhập đúng năm sinh!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // query insert data
            newUser.HoTen = strHoTen;
            newUser.NamSinh = strNamSinh;
            newUser.ChucVu = strChucVu;
            newUser.SoDienThoai = strSDT;
            newUser.Email = strEmail;
            newUser.HinhAnh_DaiDien = imageData_AnhDaiDien;
            newUser.HinhAnh_VanTay = imageData_AnhVanTay;
            newUser.HinhAnh_VanTay_TenFile = hinhAnh_VanTay_FileName;

            //string queryInsert = "INSERT INTO tblVanTay (HoTen, NamSinh, ChucVu, SoDienThoai, Email, HinhAnh_DaiDien, HinhAnh_VanTay) VALUES ('" 
            //+ strHoTen + "','" + strNamSinh + "','" + strChucVu + "','" + strSDT + "','" + strEmail + "','" + imageData_AnhDaiDien + "','" + imageData_AnhVanTay + "')";
            try
            {
                int checkInsert = db.InsertUser(newUser);
                if (checkInsert > 0)
                {
                    MessageBox.Show("Thêm mới vân tay thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string destinationPath = Path.Combine(Application.StartupPath, "Storages", Path.GetFileName(hinhAnh_VanTay_FileName));
                    File.Copy(hinhAnh_VanTay_FileName, destinationPath, true);
                    txtChucVu.Text = "";
                    txtHoTen.Text = "";
                    txtNamSinh.Text = "";
                    txtSDT.Text = "";
                    txtEmail.Text = "";
                    picAnhDaiDien.Image = null;
                    picVanTay.Image = null;
                    return;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnChonAnhDaiDien_Click(object sender, EventArgs e)
        {
            // Open file dialog to select an image file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp; *.jpg; *.jpeg; *.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file name and display it
                string selectedFileName = openFileDialog.FileName;
                //txtImagePath.Text = selectedFileName;

                // Load the selected image into PictureBox
                picAnhDaiDien.Image = Image.FromFile(selectedFileName);
            }
        }

        private void btnChonVanTay_Click(object sender, EventArgs e)
        {
            // Open file dialog to select an image file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp; *.jpg; *.jpeg; *.png; *.tif)|*.BMP;*.JPG;*.JPEG;*.PNG;*TIF";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file name and display it
                string selectedFileName = openFileDialog.FileName;
                hinhAnh_VanTay_FileName = openFileDialog.FileName;
                //txtImagePath.Text = selectedFileName;

                // Load the selected image into PictureBox
                picVanTay.Image = Image.FromFile(selectedFileName);
            }
        }

        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            FingerCompare fingerCompare = new FingerCompare();
            fingerCompare.Show();
            this.Hide();
        }
    }
}
