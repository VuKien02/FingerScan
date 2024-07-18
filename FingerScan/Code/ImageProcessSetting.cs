using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FingerprintRegnition
{
	/// <summary>
	/// Summary description for ImageProcessSetting.
	/// </summary>
	public class ImageProcessSetting : System.Windows.Forms.Form
	{
		#region Window controls
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TextBox txtV;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtM;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtF;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox txtThreshold;
		private System.Windows.Forms.RadioButton raManual;
		private System.Windows.Forms.RadioButton raAuto;
		private System.Windows.Forms.TextBox txtfi;
		private System.Windows.Forms.Label lbThreshManu;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox chbMask;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtMaskNumber;
		#endregion

		#region Attributes
		private int threshold;
		private int m;
		private int v;
		private int f;
		private int fi;
		private int maskNumber;
		#endregion

		#region Propties
		public int Threshold
		{
			get
			{
				return threshold;
			}
		}
		public int M
		{
			get
			{
				return m;
			}
		}
		public int V
		{
			get
			{
				return v;
			}
		}
		public int F
		{
			get
			{
				return f;
			}
		}
		public int Fi
		{
			get
			{
				return fi;
			}
		}
		public int MaskNumber
		{
			get
			{
				return maskNumber;
			}
		}
		#endregion 

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ImageProcessSetting(int thresh,int mValue,int vValue,int fValue,int fiValue,int maskValue)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			threshold = thresh;
			m = mValue;
			v = vValue;
			f = fValue;
			fi = fiValue;
			maskNumber = maskValue;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtM = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.raManual = new System.Windows.Forms.RadioButton();
            this.raAuto = new System.Windows.Forms.RadioButton();
            this.lbThreshManu = new System.Windows.Forms.Label();
            this.txtThreshold = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtMaskNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chbMask = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtfi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtF = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(10, 18);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(355, 204);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtV);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtM);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(347, 172);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chuẩn Hóa";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(259, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 27);
            this.button1.TabIndex = 9;
            this.button1.Text = "Default";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 27);
            this.label4.TabIndex = 8;
            this.label4.Text = "Thiết đặt thông số chuẩn hóa ảnh";
            // 
            // txtV
            // 
            this.txtV.Location = new System.Drawing.Point(259, 111);
            this.txtV.Name = "txtV";
            this.txtV.Size = new System.Drawing.Size(58, 27);
            this.txtV.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(48, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Giá trị kỳ vọng mong muốn";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(48, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "Giá trị phương sai mong muốn";
            // 
            // txtM
            // 
            this.txtM.Location = new System.Drawing.Point(259, 65);
            this.txtM.Name = "txtM";
            this.txtM.Size = new System.Drawing.Size(58, 27);
            this.txtM.TabIndex = 4;
            this.txtM.TextChanged += new System.EventHandler(this.txtM_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.raManual);
            this.tabPage2.Controls.Add(this.raAuto);
            this.tabPage2.Controls.Add(this.lbThreshManu);
            this.tabPage2.Controls.Add(this.txtThreshold);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(347, 175);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Nhị Phân";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(230, 27);
            this.label5.TabIndex = 9;
            this.label5.Text = "Thiết đặt thông số nhị phân hóa ảnh";
            // 
            // raManual
            // 
            this.raManual.Location = new System.Drawing.Point(43, 78);
            this.raManual.Name = "raManual";
            this.raManual.Size = new System.Drawing.Size(183, 28);
            this.raManual.TabIndex = 7;
            this.raManual.Text = "Tự thiết đặt giá trị ngưỡng";
            this.raManual.MouseUp += new System.Windows.Forms.MouseEventHandler(this.raManual_MouseUp);
            // 
            // raAuto
            // 
            this.raAuto.Location = new System.Drawing.Point(43, 51);
            this.raAuto.Name = "raAuto";
            this.raAuto.Size = new System.Drawing.Size(192, 27);
            this.raAuto.TabIndex = 6;
            this.raAuto.Text = "Tính ngưỡng tự động";
            this.raAuto.CheckedChanged += new System.EventHandler(this.raAuto_CheckedChanged);
            this.raAuto.MouseUp += new System.Windows.Forms.MouseEventHandler(this.raAuto_MouseUp);
            // 
            // lbThreshManu
            // 
            this.lbThreshManu.Location = new System.Drawing.Point(72, 115);
            this.lbThreshManu.Name = "lbThreshManu";
            this.lbThreshManu.Size = new System.Drawing.Size(144, 27);
            this.lbThreshManu.TabIndex = 5;
            this.lbThreshManu.Text = "Đặt giá trị ngưỡng";
            // 
            // txtThreshold
            // 
            this.txtThreshold.Location = new System.Drawing.Point(216, 115);
            this.txtThreshold.Name = "txtThreshold";
            this.txtThreshold.Size = new System.Drawing.Size(58, 27);
            this.txtThreshold.TabIndex = 4;
            this.txtThreshold.TextChanged += new System.EventHandler(this.txtThreshold_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtMaskNumber);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.chbMask);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.txtfi);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.txtF);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(347, 175);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Tăng cường";
            // 
            // txtMaskNumber
            // 
            this.txtMaskNumber.Location = new System.Drawing.Point(269, 138);
            this.txtMaskNumber.Name = "txtMaskNumber";
            this.txtMaskNumber.Size = new System.Drawing.Size(57, 27);
            this.txtMaskNumber.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(115, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 18);
            this.label9.TabIndex = 18;
            this.label9.Text = "Số lượng mặt nạ";
            // 
            // chbMask
            // 
            this.chbMask.Location = new System.Drawing.Point(48, 111);
            this.chbMask.Name = "chbMask";
            this.chbMask.Size = new System.Drawing.Size(192, 27);
            this.chbMask.TabIndex = 16;
            this.chbMask.Text = "Sử dụng bộ mặt nạ chuẩn";
            this.chbMask.CheckedChanged += new System.EventHandler(this.chbMask_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(250, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "1/";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(269, 18);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(67, 27);
            this.button4.TabIndex = 14;
            this.button4.Text = "Default";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(19, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(231, 27);
            this.label6.TabIndex = 13;
            this.label6.Text = "Thiết đặt thông số tăng cường ảnh";
            // 
            // txtfi
            // 
            this.txtfi.Location = new System.Drawing.Point(269, 83);
            this.txtfi.Name = "txtfi";
            this.txtfi.Size = new System.Drawing.Size(57, 27);
            this.txtfi.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(48, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(182, 19);
            this.label7.TabIndex = 10;
            this.label7.Text = "Giá trị tần suất vân tay cục bộ";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(48, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 19);
            this.label8.TabIndex = 12;
            this.label8.Text = "Đại diện giải thông";
            // 
            // txtF
            // 
            this.txtF.Location = new System.Drawing.Point(269, 55);
            this.txtF.Name = "txtF";
            this.txtF.Size = new System.Drawing.Size(57, 27);
            this.txtF.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(28, 260);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 26);
            this.button3.TabIndex = 9;
            this.button3.Text = "OK";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(225, 260);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 26);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancel";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ImageProcessSetting
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(393, 346);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl1);
            this.Name = "ImageProcessSetting";
            this.Text = "Thông số xử lý ảnh";
            this.Load += new System.EventHandler(this.ImageProcessSetting_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void ImageProcessSetting_Load(object sender, System.EventArgs e)
		{
			txtM.Text = m.ToString();
			txtV.Text = v.ToString();
			txtfi.Text = fi.ToString();
			txtF.Text = f.ToString();
			if(threshold>0)
			{
				raManual.Checked = true;
				txtThreshold.Text = threshold.ToString();
				txtThreshold.Enabled = true;
				lbThreshManu.Enabled = true;
			}
			else
			{
				raAuto.Checked = true;
				txtThreshold.Text = "";
				txtThreshold.Enabled = false;
				lbThreshManu.Enabled = false;
			}
			if(maskNumber>0)
			{
				chbMask.Checked = true;
				txtMaskNumber.Text = maskNumber.ToString();
				label9.Enabled = true;
				txtMaskNumber.Enabled = true;
			}
			else
			{
				maskNumber = 0;
				label9.Enabled = false;
				txtMaskNumber.Enabled = false;
			}
			
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			txtM.Text = "50";
			txtV.Text = "300";
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			txtF.Text = "7";
			txtfi.Text = "3";
			chbMask.Checked = true;
			txtMaskNumber.Text = "32";
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			try
			{
				m = Convert.ToInt32(txtM.Text);
				v = Convert.ToInt32(txtV.Text);
				f = Convert.ToInt32(txtF.Text);
				fi = Convert.ToInt32(txtfi.Text);
				if(raAuto.Checked == true)
					threshold = 0;
				else
				{
					if(!txtThreshold.Text.Equals(""))					
						threshold = Convert.ToInt32(txtThreshold.Text);
				}
				if(chbMask.Checked == true)
				{
					if(!txtMaskNumber.Text.Equals(""))			
						maskNumber = Convert.ToInt32(txtMaskNumber.Text);
				}
				else
					maskNumber = 0;
			}
			catch
			{
				MessageBox.Show("Dữ liệu nhập không tốt");
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void raAuto_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			lbThreshManu.Enabled = false;
			txtThreshold.Enabled = false;
		}

		private void raManual_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			lbThreshManu.Enabled = true;
			txtThreshold.Enabled = true;
		}

		private void chbMask_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chbMask.Checked == true)
			{
				label9.Enabled = true;
				txtMaskNumber.Enabled = true;				
			}
			else
			{
				label9.Enabled = false;
				txtMaskNumber.Enabled = false;
				txtMaskNumber.Text = "";
			}
		}

		private void raAuto_CheckedChanged(object sender, System.EventArgs e)
		{
			if(raAuto.Checked == true)
			{
				lbThreshManu.Enabled = false;
				txtThreshold.Enabled = false;
				txtThreshold.Text = "";
			}
			else
			{
				lbThreshManu.Enabled = true;
				txtThreshold.Enabled = true;
			}
		}

        private void txtM_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtThreshold_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
