using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FingerprintRegnition
{
	/// <summary>
	/// Summary description for CompareInfo.
	/// </summary>
	public class CompareInfo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RichTextBox txtCompareInfo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CompareInfo(string info)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			txtCompareInfo.Text = info;
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtCompareInfo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(155, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCompareInfo
            // 
            this.txtCompareInfo.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompareInfo.Location = new System.Drawing.Point(29, 28);
            this.txtCompareInfo.Name = "txtCompareInfo";
            this.txtCompareInfo.Size = new System.Drawing.Size(300, 200);
            this.txtCompareInfo.TabIndex = 1;
            this.txtCompareInfo.Text = "";
            // 
            // CompareInfo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(360, 277);
            this.Controls.Add(this.txtCompareInfo);
            this.Controls.Add(this.button1);
            this.Name = "CompareInfo";
            this.Text = "CompareInfo";
            this.Load += new System.EventHandler(this.CompareInfo_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        private void CompareInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
