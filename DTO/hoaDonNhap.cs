using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
     public class hoaDonNhap
    {

        public hoaDonNhap(int id , string ngaynhap, int manv , string tongTien) 
        {
            this.Id = id;
            this.NgayNhap = ngaynhap;
            this.Manv = manv;
            this.TongTien= tongTien;
        }


        public hoaDonNhap(DataRow row) 
        {
            
            this.Id = (int)row["MaHoaDonNhap"];
            this.NhaCC= row["MaNhaCC"].ToString();
            this.NgayNhap = row["NgayNhap"].ToString();
            this.Manv = (int)row["MaNguoiNv"];
            this.TongTien = row["TongTien"].ToString();


         }

        private int id;
        private string nhaCC;
        private string ngayNhap;
        private int manv;
        private string tongTien;

        public int Id { get => id; set => id = value; }
        public string NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public int Manv { get => manv; set => manv = value; }
        public string TongTien { get => tongTien; set => tongTien = value; }
        public string NhaCC { get => nhaCC; set => nhaCC = value; }
    }



   
}
