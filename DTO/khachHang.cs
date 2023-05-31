using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTO
{
    public class khachHang
    {
        public khachHang(int id, string name, string diaChi, string soDienThoai, string email) 
        { 
            this.Id = id;
            this.Name = name;
            this.DiaChi1 = diaChi;
            this.SoDienThoai= SoDienThoai;
            this.Email = email;
        }

        public khachHang( DataRow row )
        {
            this.Id = (int)row["id"];
            this.Name = (string)row["Ten"];
            this.DiaChi1 = (string)row["diaChi"];
            this.SoDienThoai= (string)row["soDienThoai"];
            this.Email = (string)row["email"];

        }




        private int id;
        private string name;
        private string DiaChi;
        private string soDienThoai;
        private string email;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string DiaChi1 { get => DiaChi; set => DiaChi = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string Email { get => email; set => email = value; }
    }
}
