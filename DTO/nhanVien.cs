using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class nhanVien
    {
        public nhanVien(int id, string tenNV,string gioiTinh, string ngaySinh, string queQuan, string soDienThoai, int luongCoban, string email, string userName, string passWordd, int type)
        {
            this.ID=id;
            this.TenNguoi = tenNV;
            this.Email=email;
            this.UserName=userName;
            this.PassWordd=passWordd;
            this.Type=type;
            this.QueQuan=queQuan;
            this.NgaySinh = ngaySinh;
            this.SoDienThoai=soDienThoai;
            this.LuongCoban=luongCoban;
            this.GioiTinh = gioiTinh;

        }


        public nhanVien(DataRow row)
        {
            ID = (int)row["id"];
            this.TenNguoi = row["tenNguoi"].ToString();
            this.GioiTinh = row["gioiTinh"].ToString();
            this.Email = row["Email"].ToString();
            this.UserName = row["UserName"].ToString();
            this.PassWordd = row["PassWordd"].ToString();
            this.Type = (int)row["Typee"];
            this.QueQuan = row["QueQuan"].ToString();
            this.NgaySinh =row["NgaySinh"].ToString(); 
            this.SoDienThoai = row["soDienThoai"].ToString();
            this.LuongCoban = (int)row["LuongCoBan"];
        }




        

        private int id;
        private string tenNguoi;
        private string ngaySinh;
        private string queQuan;
        private string soDienThoai;   
        private int luongCoban;
        private string email;
        private string userName;
        private int typee;
        private string passWordd;
        private string GioiTinh;

        public int ID { get => id; set => id = value; }
        public string TenNguoi { get => tenNguoi; set => tenNguoi = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string QueQuan { get => queQuan; set => queQuan = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public int LuongCoban { get => luongCoban; set => luongCoban = value; }
        public string Email { get => email; set => email = value; }
        public string UserName { get => userName; set => userName = value; }
        public int Type { get => typee; set => typee = value; }
        public string PassWordd { get => passWordd; set => passWordd = value; }
        public string GoiTinh { get => GioiTinh; set => GioiTinh = value; }
    }

    
}
