using FingerprintRegnition.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FingerprintRegnition
{
    public partial class DetailInfoUser : Form
    {
        UserController userController = new UserController();
        public DetailInfoUser()
        {
            InitializeComponent();
        }

        private void DetailInfoUser_Load(object sender, EventArgs e)
        {
            try
            {
                if (DataGlobal.IDUser != null)
                {
                    DataTable dataTable = userController.GetUserById(DataGlobal.IDUser);
                    if (dataTable.Rows.Count > 0)
                    {
                        lbl_HoTen.Text = dataTable.Rows[0]["HoTen"].ToString();
                        lbl_NamSinh.Text = dataTable.Rows[0]["NamSinh"].ToString();
                        lbl_ChucVu.Text = dataTable.Rows[0]["ChucVu"].ToString();
                        lbl_Email.Text = dataTable.Rows[0]["Email"].ToString();
                        lbl_SDT.Text = dataTable.Rows[0]["SoDienThoai"].ToString();

                        ImageData imgVanTay = new ImageData(dataTable.Rows[0]["HinhAnh_VanTay_TenFile"].ToString(), DataGlobal.widthSquare);
                        pictureBox_VanTay.Image = imgVanTay.ToBitmap();
                        double[,] directMatrix2 = imgVanTay.Direct;
                        int width2 = imgVanTay.Width;
                        int height2 = imgVanTay.Height;
                        int[,] image2Data = new int[width2, height2];
                        for (int i = 0; i < imgVanTay.Width; i++)
                        {

                            for (int j = 0; j < imgVanTay.Height; j++)
                            {

                                image2Data[i, j] = imgVanTay.Image[i, j];
                            }
                        }

                        byte[] imgAvatar = (byte[])dataTable.Rows[0]["HinhAnh_DaiDien"];
                        MemoryStream ms = new MemoryStream(imgAvatar);
                        ms.Read(imgAvatar, 0, System.Convert.ToInt32(imgAvatar.Length));
                        Image im = Image.FromStream(ms);

                        pictureBox_Avatar.Image = im;
                        pictureBox_Avatar.SizeMode = PictureBoxSizeMode.Zoom;
                        imgAvatar = null;
                        ms.Close();
                    }
                }
            }
            catch { }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FingerCompare fingerCompare = new FingerCompare();
            fingerCompare.Show();
            this.Hide();
        }
    }
}
