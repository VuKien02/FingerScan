﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using FingerprintRegnition.Controllers;

namespace FingerprintRegnition
{
    /// <summary>
    /// Summary description for FingerCompare.
    /// </summary>
    public class FingerCompare : System.Windows.Forms.Form
    {
        UserController db = new UserController();

        #region Window controls
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.MenuItem menuItem16;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.IContainer components;
        #endregion

        #region Options info

        //padding
        private int left1 = 50;
        private int top1 = 20;
        private int right1 = 50;
        private int bottom1 = 20;
        private int left2 = 50;
        private int top2 = 20;
        private int right2 = 50;
        private int bottom2 = 20;

        //image process
        public static int m = 50;
        public static int v = 300;
        public static int threshold = 0;
        public static int f = 7;
        public static int fi = 3;

        //mask gabor
        public static ArrayList MaskGaborCollection = new ArrayList();
        public static int maskNumber = 32;

        //compare options
        private int angleLimit = 5;
        private int distanceLimit = 5;
        private int minuNumberLimit = 14;

        #endregion

        private bool isFirst1 = true;
        private int width1, height1;
        private int width2, height2;
        private bool isFirst2 = true;
        
        private ArrayList minus1 = new ArrayList();
        private ArrayList minus2 = new ArrayList();
        private Minutiae minuResult;
        private string sResult;
        public static int widthSquare = 4;//
        private ImageData image1;
        private int[,] image1Data;
        private ImageData image2;
        private int[,] image2Data;
        private double[,] directMatrix1;
        private System.Windows.Forms.StatusBarPanel statueP2;
        private MenuItem btnThemVanTay;
        private MenuItem menuItem17;
        private ComboBox cbxNhanSu;
        private Label label3;
        private Button btnKiemTraVanTay;
        private Button btnXemThongTin;

        private bool checkSuccess = false;
        private ToolBarButton btAbout;
        private ToolBarButton btViewCpDetail;
        private ToolBarButton btViewMinu;
        private ToolBarButton btCompare;
        private ToolBarButton bt1OpenPic;
        private double[,] directMatrix2;
        public FingerCompare()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            UpdateMaskGaborCollection();

            menuItem6.Enabled = false;
            menuItem7.Enabled = false;
            menuItem8.Enabled = false;
            btCompare.Enabled = false;
            btViewCpDetail.Enabled = false;
            btViewMinu.Enabled = false;
        }
        [STAThread]
        static void Main()
        {
            Application.Run(new FingerCompare());
        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// 

        // Phương thức chuyển đổi dữ liệu hình ảnh từ byte array sang hình ảnh
        static Image ImageFromByteArray(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                Image image = Image.FromStream(ms);
                return image;
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FingerCompare));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.btnThemVanTay = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statueP2 = new System.Windows.Forms.StatusBarPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cbxNhanSu = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnKiemTraVanTay = new System.Windows.Forms.Button();
            this.btnXemThongTin = new System.Windows.Forms.Button();
            this.btAbout = new System.Windows.Forms.ToolBarButton();
            this.btViewCpDetail = new System.Windows.Forms.ToolBarButton();
            this.btViewMinu = new System.Windows.Forms.ToolBarButton();
            this.btCompare = new System.Windows.Forms.ToolBarButton();
            this.bt1OpenPic = new System.Windows.Forms.ToolBarButton();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statueP2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(492, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "Vân tay mẫu";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Vân tay mẫu kiểm tra";
            // 
            // pic2
            // 
            this.pic2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pic2.Location = new System.Drawing.Point(496, 167);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(307, 296);
            this.pic2.TabIndex = 5;
            this.pic2.TabStop = false;
            this.pic2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic2_MouseMove);
            // 
            // pic1
            // 
            this.pic1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pic1.Location = new System.Drawing.Point(12, 167);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(307, 296);
            this.pic1.TabIndex = 4;
            this.pic1.TabStop = false;
            this.pic1.Click += new System.EventHandler(this.pic1_Click);
            this.pic1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic1_MouseMove);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem5,
            this.menuItem9,
            this.menuItem12});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.btnThemVanTay,
            this.menuItem17,
            this.menuItem2,
            this.menuItem4});
            this.menuItem1.Text = "Vân tay";
            // 
            // btnThemVanTay
            // 
            this.btnThemVanTay.Index = 0;
            this.btnThemVanTay.Text = "Thêm vân tay";
            this.btnThemVanTay.Click += new System.EventHandler(this.btnThemVanTay_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 1;
            this.menuItem17.Text = "-";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "Mở vân tay mẫu kiểm tra";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "Thoát";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6,
            this.menuItem7,
            this.menuItem8});
            this.menuItem5.Text = "Xử lý";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.Text = "So sánh vân tay";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.Text = "Thông tin so sánh";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 2;
            this.menuItem8.Text = "Hiện chi tiết";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 2;
            this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem10,
            this.menuItem11});
            this.menuItem9.Text = "Công cụ";
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 0;
            this.menuItem10.Text = "Kiểm nghiệm thuật toán";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 1;
            this.menuItem11.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem14,
            this.menuItem15,
            this.menuItem16});
            this.menuItem11.Text = "Tùy chỉnh";
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 0;
            this.menuItem14.Text = "Vùng chọn đặc trưng";
            this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 1;
            this.menuItem15.Text = "Thông số xử lý ảnh";
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 2;
            this.menuItem16.Text = "Thông số đối sánh vân";
            this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 3;
            this.menuItem12.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem13});
            this.menuItem12.Text = "Thông tin";
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 0;
            this.menuItem13.Text = "Tác giả";
            this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 637);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statueP2});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(814, 26);
            this.statusBar1.TabIndex = 8;
            this.statusBar1.Text = "Waiting";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 430;
            // 
            // statueP2
            // 
            this.statueP2.Name = "statueP2";
            this.statueP2.Text = "Waiting";
            this.statueP2.Width = 120;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            // 
            // cbxNhanSu
            // 
            this.cbxNhanSu.FormattingEnabled = true;
            this.cbxNhanSu.Location = new System.Drawing.Point(315, 45);
            this.cbxNhanSu.Name = "cbxNhanSu";
            this.cbxNhanSu.Size = new System.Drawing.Size(415, 24);
            this.cbxNhanSu.TabIndex = 10;
            this.cbxNhanSu.SelectedIndexChanged += new System.EventHandler(this.cbxNhanSu_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Chọn vân tay mẫu:";
            // 
            // btnKiemTraVanTay
            // 
            this.btnKiemTraVanTay.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnKiemTraVanTay.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKiemTraVanTay.Location = new System.Drawing.Point(78, 557);
            this.btnKiemTraVanTay.Name = "btnKiemTraVanTay";
            this.btnKiemTraVanTay.Size = new System.Drawing.Size(270, 49);
            this.btnKiemTraVanTay.TabIndex = 12;
            this.btnKiemTraVanTay.Text = "Kiểm tra vân tay";
            this.btnKiemTraVanTay.UseVisualStyleBackColor = false;
            this.btnKiemTraVanTay.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // btnXemThongTin
            // 
            this.btnXemThongTin.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnXemThongTin.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemThongTin.Location = new System.Drawing.Point(460, 557);
            this.btnXemThongTin.Name = "btnXemThongTin";
            this.btnXemThongTin.Size = new System.Drawing.Size(270, 49);
            this.btnXemThongTin.TabIndex = 13;
            this.btnXemThongTin.Text = "Xem thông tin";
            this.btnXemThongTin.UseVisualStyleBackColor = false;
            this.btnXemThongTin.Click += new System.EventHandler(this.btnXemThongTin_Click);
            // 
            // btAbout
            // 
            this.btAbout.ImageIndex = 4;
            this.btAbout.Name = "btAbout";
            this.btAbout.ToolTipText = "Thông tin";
            // 
            // btViewCpDetail
            // 
            this.btViewCpDetail.ImageIndex = 2;
            this.btViewCpDetail.Name = "btViewCpDetail";
            this.btViewCpDetail.ToolTipText = "Thông tin so sánh";
            // 
            // btViewMinu
            // 
            this.btViewMinu.ImageIndex = 1;
            this.btViewMinu.Name = "btViewMinu";
            this.btViewMinu.ToolTipText = "Xem chi tiết";
            // 
            // btCompare
            // 
            this.btCompare.ImageIndex = 3;
            this.btCompare.Name = "btCompare";
            this.btCompare.ToolTipText = "So sánh";
            // 
            // bt1OpenPic
            // 
            this.bt1OpenPic.ImageIndex = 0;
            this.bt1OpenPic.Name = "bt1OpenPic";
            this.bt1OpenPic.ToolTipText = "Mở ảnh vân tay 1";
            // 
            // FingerCompare
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(814, 663);
            this.Controls.Add(this.btnXemThongTin);
            this.Controls.Add(this.btnKiemTraVanTay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxNhanSu);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pic2);
            this.Controls.Add(this.pic1);
            this.MaximumSize = new System.Drawing.Size(1200, 800);
            this.Menu = this.mainMenu1;
            this.Name = "FingerCompare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đối sánh vân tay";
            this.Load += new System.EventHandler(this.FingerCompare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statueP2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void menuItem10_Click(object sender, System.EventArgs e)
        {
            AlgorithmTest alTest = new AlgorithmTest();
            alTest.Show();
        }

        private void menuItem4_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    image1 = new ImageData(dlg.FileName, widthSquare);
                    pic1.Image = image1.ToBitmap();
                    directMatrix1 = image1.Direct;
                    width1 = image1.Width;
                    height1 = image1.Height;
                    minus1.Clear();
                    sResult = "";
                    isFirst1 = true;
                    image1Data = new int[image1.Width, image1.Height];
                    for (int i = 0; i < image1.Width; i++)
                        for (int j = 0; j < image1.Height; j++)
                            image1Data[i, j] = image1.Image[i, j];
                    if (image2 != null)
                    {
                        menuItem6.Enabled = true;
                        menuItem7.Enabled = true;
                        menuItem8.Enabled = true;
                        btCompare.Enabled = true;
                        btViewCpDetail.Enabled = true;
                        btViewMinu.Enabled = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi mở file");
            }
        }

        private void menuItem3_Click(object sender, System.EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    image2 = new ImageData(dlg.FileName, widthSquare);
                    pic2.Image = image2.ToBitmap();
                    directMatrix2 = image2.Direct;
                    width2 = image2.Width;
                    height2 = image2.Height;
                    isFirst2 = true;
                    minus2.Clear();
                    sResult = "";
                    image2Data = new int[width2, height2];
                    for (int i = 0; i < image2.Width; i++)
                        for (int j = 0; j < image2.Height; j++)
                            image2Data[i, j] = image2.Image[i, j];
                    if (image1 != null)
                    {
                        menuItem6.Enabled = true;
                        menuItem7.Enabled = true;
                        menuItem8.Enabled = true;
                        btCompare.Enabled = true;
                        btViewCpDetail.Enabled = true;
                        btViewMinu.Enabled = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi mở file");
            }
        }

        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            
        }

        private void menuItem6_Click(object sender, System.EventArgs e)
        {
            try
            {
                int i, j;
                if (!isFirst1)
                {
                    int[,] input1 = new int[width1, height1];
                    for (i = 0; i < width1; i++)
                        for (j = 0; j < height1; j++)
                            input1[i, j] = image1Data[i, j];

                    image1.SetImage(input1, width1, height1, widthSquare);
                }
                if (!isFirst2)
                {
                    int[,] input2 = new int[width2, height2];
                    for (i = 0; i < width2; i++)
                        for (j = 0; j < height2; j++)
                            input2[i, j] = image2Data[i, j];
                    image2.SetImage(input2, width2, height2, widthSquare);
                }
                this.Cursor = Cursors.WaitCursor;

                #region prepare data
                statueP2.Text = "Đang chuẩn hóa";
                image1.ToNornal(m, v);
                image2.ToNornal(m, v);

                statueP2.Text = "Đang tăng cường";
                image1.ToFiltring(widthSquare, f, fi);
                image2.ToFiltring(widthSquare, f, fi);

                statueP2.Text = "Đang nhị phân hóa";
                image1.ToBinary(threshold);
                image2.ToBinary(threshold);

                statueP2.Text = "Đang làm mảnh";
                image1.ToBoneImage();
                image2.ToBoneImage();

                minus1.Clear();
                minus2.Clear();
                minus1 = image1.GetMinutiae(left1, top1, right1, bottom1);
                minus2 = image2.GetMinutiae(left2, top2, right2, bottom2);
                #endregion

                #region run hough
                //int i;			
                //angles
                int angleStart = -30;
                int angleUnit = 3;
                int angleFinish = 30;
                int anglesCount = Convert.ToInt32((angleFinish - angleStart) / angleUnit) + 1;
                int[] angleSet = new int[anglesCount];
                i = 0;
                int angle = angleStart;
                while (i < anglesCount)
                {
                    angleSet[i] = angle;
                    i++;
                    angle += angleUnit;
                }
                //DELTAXSET
                int deltaXStart = -image1.Width;
                int deltaXFinish = image1.Width;
                int deltaXUnit = 2;
                int deltaXCount = Convert.ToInt32((deltaXFinish - deltaXStart) / deltaXUnit) + 1;
                int[] deltaXSet = new int[deltaXCount];
                i = 0;
                int deltaX = deltaXStart;
                while (i < deltaXCount)
                {
                    deltaXSet[i] = deltaX;
                    i++;
                    deltaX += deltaXUnit;
                }
                //DELTAYSET
                int deltaYStart = -image1.Height;
                int deltaYFinish = image1.Height;
                int deltaYUnit = 2;
                int deltaYCount = Convert.ToInt32((deltaYFinish - deltaYStart) / deltaYUnit) + 1;
                int[] deltaYSet = new int[deltaYCount];
                i = 0;
                int deltaY = deltaYStart;
                while (i < deltaYCount)
                {
                    deltaYSet[i] = deltaY;
                    i++;
                    deltaY += deltaYUnit;
                }

                //scaleset
                double[] scaleSet = { 0.8, 0.9, 1.0, 1.1, 1.2 };
                minuResult = Functions.GetMinutiaeChanging_UseHoughTransform(minus1, minus2, angleSet, deltaXSet, deltaYSet, angleLimit * Math.PI / 180, image1.Width / 2, image1.Height / 2);
                int count = Functions.CountMinuMatching(minus1, minus2, minuResult, distanceLimit, angleLimit * Math.PI / 180);
                if (count >= minuNumberLimit)
                {
                    MessageBox.Show("Hai vân tay trùng khớp");
                    checkSuccess = true;
                }    
                else
                {
                    MessageBox.Show("Hai vân tay không trùng khớp");
                    checkSuccess = false;
                }    
                sResult = "Tịnh tiến trục X:" + minuResult.X.ToString() + "\nTịnh tiến trục Y:" + minuResult.Y.ToString() + "\nGóc quay:" + Convert.ToString(minuResult.Direct * 180 / Math.PI) + "\n Số lượng chi tiết trùng khớp:" + count.ToString();
                #endregion

                statueP2.Text = "Đã hoàn thành";
                this.Cursor = Cursors.Default;
                isFirst1 = false;
                isFirst2 = false;
            }
            catch
            {
                MessageBox.Show("Lỗi xử lý");
            }

        }

        private void menuItem8_Click(object sender, System.EventArgs e)
        {
            try
            {
                pic1.Image = image1.ToBitmap();
                pic2.Image = image2.ToBitmap();
                ViewMinus();
            }
            catch { }
        }

        private void menuItem7_Click(object sender, System.EventArgs e)
        {
            CompareInfo ciDialog = new CompareInfo(sResult);
            ciDialog.ShowDialog();
        }

        private void menuItem13_Click(object sender, System.EventArgs e)
        {
            About aboutDialog = new About();
            aboutDialog.ShowDialog();
        }

        private void menuItem14_Click(object sender, System.EventArgs e)
        {
            RegionSelectPadding regionDialog = new RegionSelectPadding(left1, top1, right1, bottom1, left2, top2, right2, bottom2);
            regionDialog.ShowDialog();
            if (regionDialog.DialogResult == DialogResult.OK)
            {
                left1 = regionDialog.Left1WidthPadding;
                top1 = regionDialog.Top1WidthPadding;
                right1 = regionDialog.Right1WidthPadding;
                bottom1 = regionDialog.Bottom1WidthPadding;

                left2 = regionDialog.Left2WidthPadding;
                top2 = regionDialog.Top2WidthPadding;
                right2 = regionDialog.Right2WidthPadding;
                bottom2 = regionDialog.Bottom2WidthPadding;
            }
        }

        private void menuItem15_Click(object sender, System.EventArgs e)
        {
            ImageProcessSetting imageprocessDialog = new ImageProcessSetting(threshold, m, v, f, fi, maskNumber);
            imageprocessDialog.ShowDialog();
            if (imageprocessDialog.DialogResult == DialogResult.OK)
            {
                m = imageprocessDialog.M;
                v = imageprocessDialog.V;
                f = imageprocessDialog.F;
                fi = imageprocessDialog.Fi;
                threshold = imageprocessDialog.Threshold;
                maskNumber = imageprocessDialog.MaskNumber;
                if (maskNumber > 0)
                    UpdateMaskGaborCollection();
            }
        }

        private void menuItem16_Click(object sender, System.EventArgs e)
        {
            CompareOption comOptionDialog = new CompareOption(angleLimit, distanceLimit, minuNumberLimit);
            comOptionDialog.ShowDialog();
            if (comOptionDialog.DialogResult == DialogResult.OK)
            {
                angleLimit = comOptionDialog.AngleLimit;
                distanceLimit = comOptionDialog.DistanceLimit;
                minuNumberLimit = comOptionDialog.MinuNumberLimit;
            }
        }



        private void UpdateMaskGaborCollection()
        {
            double direct = 0;
            MaskGaborCollection.Clear();
            for (int i = 0; i < maskNumber; i++)
            {
                MaskGabor mask = new MaskGabor(widthSquare, direct, 1.0 / f, fi);
                MaskGaborCollection.Add(mask);
                direct += Math.PI / maskNumber;
            }
        }
        private void ViewMinus()
        {
            Pen pen = new Pen(Color.Red, 1);
            Pen pen1 = new Pen(Color.Blue, 2);
            Graphics g = Graphics.FromImage(pic1.Image);
            for (int index = 0; index < minus1.Count; index++)
            {
                Minutiae minu = (Minutiae)minus1[index];
                g.DrawRectangle(pen, minu.X - 2, minu.Y - 2, 5, 5);
                g.DrawLine(pen1, minu.X, minu.Y, minu.X + Convert.ToInt32(15 * Math.Cos(minu.Direct)), minu.Y - Convert.ToInt32(15 * Math.Sin(minu.Direct)));
            }
            pic1.Refresh();
            g.Dispose();

            //Pen pen = new Pen(Color.Red,1);
            //Pen pen1 = new Pen(Color.Blue,2);
            Graphics g1 = Graphics.FromImage(pic2.Image);
            for (int index = 0; index < minus2.Count; index++)
            {
                Minutiae minu = (Minutiae)minus2[index];
                g1.DrawRectangle(pen, minu.X - 2, minu.Y - 2, 5, 5);
                g1.DrawLine(pen1, minu.X, minu.Y, minu.X + Convert.ToInt32(15 * Math.Cos(minu.Direct)), minu.Y - Convert.ToInt32(15 * Math.Sin(minu.Direct)));
            }
            pic2.Refresh();
            g1.Dispose();
        }
        private int[] BuildHoughInput(int start, int finish, int unit)
        {
            int count = Convert.ToInt32((finish - start) / unit) + 1;
            int[] valueSet = new int[count];
            int valueMember = start;
            for (int i = 0; i < count; i++)
            {
                valueSet[i] = valueMember;
                valueMember += unit;
            }
            return valueSet;
        }

        private void btnThemVanTay_Click(object sender, EventArgs e)
        {
            ThemMoiVanTay fThemMoiVantay = new ThemMoiVanTay();
            fThemMoiVantay.Show();
            this.Hide();
        }

        private void FingerCompare_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = db.GetAllUser();
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        string valueData = dataTable.Rows[i]["ID"].ToString() + " - " + dataTable.Rows[i]["HoTen"].ToString();
                        cbxNhanSu.Items.Add(valueData);
                    }
                }
            }
            catch
            {

            }
        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        private void cbxNhanSu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //byte[] imageData_VanTayNhanSu = null;
            string dataSelected = cbxNhanSu.SelectedItem.ToString();

            string[] ID_NhanSuSelected = dataSelected.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            int IdNhanSu = Convert.ToInt32(ID_NhanSuSelected[0].Trim());
            DataGlobal.IDUser = IdNhanSu;

            DataTable dataTable = new DataTable();
            dataTable = db.GetUserById(IdNhanSu);
            if (dataTable.Rows.Count > 0)
            {

                try
                {
                        image2 = new ImageData(dataTable.Rows[0]["HinhAnh_VanTay_TenFile"].ToString(), widthSquare);
                        pic2.Image = image2.ToBitmap();
                        directMatrix2 = image2.Direct;
                        width2 = image2.Width;
                        height2 = image2.Height;
                        isFirst2 = true;
                        minus2.Clear();
                        sResult = "";
                        image2Data = new int[width2, height2];
                        for (int i = 0; i < image2.Width; i++)
                            for (int j = 0; j < image2.Height; j++)
                                image2Data[i, j] = image2.Image[i, j];
                        if (image1 != null)
                        {
                            menuItem6.Enabled = true;
                            menuItem7.Enabled = true;
                            menuItem8.Enabled = true;
                            btCompare.Enabled = true;
                            btViewCpDetail.Enabled = true;
                            btViewMinu.Enabled = true;
                        }
                    
                }
                catch
                {
                    //MessageBox.Show("Lỗi mở file");
                }
            }
        }

        private void btnXemThongTin_Click(object sender, EventArgs e)
        {
            if (checkSuccess==false)
            {
                MessageBox.Show("Không thể xem thông tin khi chưa xác thực vân tay hoặc vân tay không trùng khớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                DetailInfoUser frmDetailInfoUser = new DetailInfoUser();
                frmDetailInfoUser.Show();
                this.Hide();
            }
        }

        private void menuItem18_Click(object sender, EventArgs e)
        {
            
        }

        private void pic1_Click(object sender, EventArgs e)
        {

        }

        private void menuItem3_Click_1(object sender, EventArgs e)
        {

        }

        private void menuItem18_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pic1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (pic1.Image != null)
            {
                try
                {
                    statusBarPanel1.Text = " Vân tay 1:X:" + e.X.ToString() + " Y:" + e.Y.ToString() + " Hướng cục bộ:" + Convert.ToString(image1.Direct[e.X, e.Y] * 180 / Math.PI);
                }
                catch { }
            }
        }

        private void pic2_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (pic2.Image != null)
            {
                try
                {
                    statusBarPanel1.Text = " Vân tay 2:X:" + e.X.ToString() + " Y:" + e.Y.ToString() + " Hướng cục bộ:" + Convert.ToString(image2.Direct[e.X, e.Y] * 180 / Math.PI);
                }
                catch { }

            }
        }
    }
}
