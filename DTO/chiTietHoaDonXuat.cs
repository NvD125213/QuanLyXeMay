using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class chiTietHoaDonXuat
    {
        public chiTietHoaDonXuat(int maHoaDonNhap, int maSanPham, int soLuong, string donGia,string vat)
        {
            this.MaHoaDon = maHoaDonNhap;
            this.MaSanPham = maSanPham;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
            this.vat= vat;
        }


        public chiTietHoaDonXuat(DataRow row)
        {
            try
            {
                this.MaHoaDon = (int)row["MaHD"];
                this.MaSanPham = (int)row["MaSP"];
                this.SoLuong = (int)row["SoLuong"];
                this.DonGia = row["Gia"].ToString();
                this.Vat= row["vat"].ToString();

            }
            catch { }

        }

        private int maHoaDonNhap;
        private int maSanPham;
        private int soLuong;
        private string donGia;
        private string vat;

        public int MaHoaDon { get => maHoaDonNhap; set => maHoaDonNhap = value; }
        public int MaSanPham { get => maSanPham; set => maSanPham = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string DonGia { get => donGia; set => donGia = value; }
        public string Vat { get => vat; set => vat = value; }
    }
}
