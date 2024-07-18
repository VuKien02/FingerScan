using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FingerprintRegnition.Models
{
    public class UserModel
    {
        private int? iD;
        private string hoTen;
        private string namSinh;
        private string chucVu;
        private string soDienThoai;
        private string email;
        private byte[] hinhAnh_DaiDien;
        private byte[] hinhAnh_VanTay;
        private string hinhAnh_VanTay_TenFile;
        public byte[] HinhAnh_VanTay { get => hinhAnh_VanTay; set => hinhAnh_VanTay = value; }
        public byte[] HinhAnh_DaiDien { get => hinhAnh_DaiDien; set => hinhAnh_DaiDien = value; }
        public string Email { get => email; set => email = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public string NamSinh { get => namSinh; set => namSinh = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public int? ID { get => iD; set => iD = value; }
        public string HinhAnh_VanTay_TenFile { get => hinhAnh_VanTay_TenFile; set => hinhAnh_VanTay_TenFile = value; }
    }
}
