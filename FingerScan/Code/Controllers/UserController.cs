using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FingerprintRegnition.Models;
using FingerprintRegnition.Database;

namespace FingerprintRegnition.Controllers
{
    public class UserController
    {
        FingerprintRegnition.Database.DbConnect db = new FingerprintRegnition.Database.DbConnect();
        public DataTable GetAllUser()
        {
            return db.LayDuLieu("SP_GetAll_UserData");
        }

        public DataTable GetUserById(int ID)
        {
            int Nparameter = 1;
            string[] param = new string[Nparameter];
            object[] value = new object[Nparameter];

            param[0] = "@ID";
            value[0] = ID;

            return db.LayDuLieu("SP_Get_UserData_By_Id", param, value, Nparameter);
        }

        public int InsertUser(UserModel user)
        {
            int Nparameter = 8;
            string[] param = new string[Nparameter];
            object[] value = new object[Nparameter];

            param[0] = "@HoTen";
            param[1] = "@NamSinh";
            param[2] = "@ChucVu";
            param[3] = "@SoDienThoai";
            param[4] = "@Email";
            param[5] = "@HinhAnh_DaiDien";
            param[6] = "@HinhAnh_VanTay";
            param[7] = "@HinhAnh_VanTay_TenFile";

            value[0] = user.HoTen;
            value[1] = user.NamSinh;
            value[2] = user.ChucVu;
            value[3] = user.SoDienThoai;
            value[4] = user.Email;
            value[5] = user.HinhAnh_DaiDien;
            value[6] = user.HinhAnh_VanTay;
            value[7] = user.HinhAnh_VanTay_TenFile;

            return db.Update("SP_Insert_NewUser", param, value, Nparameter);
        }
    }
}
