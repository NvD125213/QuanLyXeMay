using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class chiTietHoaDonNhap
    {
        public chiTietHoaDonNhap(int maHoaDonNhap, int maSanPham, int soLuong, string donGia) 
        {
            this.MaHoaDonNhap = maHoaDonNhap;
            this.MaSanPham= maSanPham;
            this.SoLuong= soLuong;
            this.DonGia= donGia;
        }


        public chiTietHoaDonNhap(DataRow row)
        {
            try 
            {
                this.MaHoaDonNhap = (int)row["MaHoaDonNhap"];
                this.MaSanPham = (int)row["MaSanPham"];
                
                this.SoLuong = (int)row["SoLuong"];
                this.DonGia = row["DonGia"].ToString();
            }catch{ }
            
        }

        public chiTietHoaDonNhap() { }


        private int maHoaDonNhap;
        private int maSanPham;
        private int soLuong;
        private string donGia;

        public int MaHoaDonNhap { get => maHoaDonNhap; set => maHoaDonNhap = value; }
        public int MaSanPham { get => maSanPham; set => maSanPham = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string DonGia { get => donGia; set => donGia = value; }
    }
}
