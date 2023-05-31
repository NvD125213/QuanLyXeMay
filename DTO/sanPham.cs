
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class sanPham
    {
        public sanPham(int id , string tenXe, string hangXe, string dungTich, string loaiXe, string namSx, string Mau, string giaBan, string linlAnh, int soluong) 
        {
            this.Id = id;
            this.TenXe = tenXe;
            this.HangXe = hangXe;
            this.LoaiXe = loaiXe;
            this.DungTich= dungTich;
            this.NamSx = namSx;
            this.Mau = Mau;
            this.giaBan = giaBan;
            this.LinlAnh= linlAnh;
            this.soluong = soluong;

        }


        public sanPham(DataRow row)
        {
            try {
                this.Id = (int)row["id"];
                this.TenXe = row["tenXE"].ToString();
                this.HangXe = row["hangXE"].ToString();
                this.LoaiXe = row["dungTich"].ToString();
                this.DungTich = row["loaiXe"].ToString();
                this.NamSx = row["namSx"].ToString();
                this.Mau = row["Color"].ToString();
                this.giaBan = row["GiaBan"].ToString();
                this.LinlAnh = row["anh"].ToString();
                this.Soluong = (int)row["SoLuong"];
            }
            catch{ }
            

        }




        private int    id;
        private string tenXe;
        private string hangXe;
        private string dungTich;
        private string loaiXe;
        private string namSx;
        private string Mau;
        private string giaBan;
        private string linlAnh;
        private int     soluong;

        public int Id { get => id; set => id = value; }
        public string TenXe { get => tenXe; set => tenXe = value; }
        public string HangXe { get => hangXe; set => hangXe = value; }
        public string DungTich { get => dungTich; set => dungTich = value; }
        public string LoaiXe { get => loaiXe; set => loaiXe = value; }
        public string NamSx { get => namSx; set => namSx = value; }
        public string Mau1 { get => Mau; set => Mau = value; }
        public string GiaBan { get => giaBan; set => giaBan = value; }
        public string LinlAnh { get => linlAnh; set => linlAnh = value; }
        public int Soluong { get => soluong; set => soluong = value; }
    }
}
