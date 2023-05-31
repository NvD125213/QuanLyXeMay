using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class hoaDonBanHang
    {
         public hoaDonBanHang( int id , string ngayBan, string maNv, string maKh, string tongTien) 
        {
            this.Id = id;
            this.NgayBan = ngayBan;
            this.MaNv = maNv;
            this.MaKh = maKh;
            this.TongTien = tongTien;
        }
        public hoaDonBanHang(DataRow row)
        {
            try {
                this.Id = (int)row["id"];
                this.NgayBan = row["NgayBan"].ToString();
                this.MaNv = row["Manv"].ToString();
                this.MaKh = row["MaKh"].ToString();
                this.TongTien = row["TongTien"].ToString();
            }catch{ }
            
        }


        private int id;
        private string ngayBan;
        private string maNv;
        private string maKh;
        private string tongTien;

        public int Id { get => id; set => id = value; }
        public string NgayBan { get => ngayBan; set => ngayBan = value; }
        public string MaNv { get => maNv; set => maNv = value; }
        public string MaKh { get => maKh; set => maKh = value; }
        public string TongTien { get => tongTien; set => tongTien = value; }
    }
}
