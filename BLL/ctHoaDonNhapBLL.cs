using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;


namespace BLL
{
    public class ctHoaDonNhapBLL
    {
        private static ctHoaDonNhapBLL instance;
        public static ctHoaDonNhapBLL Instance
        {
            get { if (instance == null) instance = new ctHoaDonNhapBLL(); return ctHoaDonNhapBLL.instance; }
            private set { ctHoaDonNhapBLL.instance = value; }
        }


        public List<chiTietHoaDonNhap> ds( string id)
        {
          return  ChiTietHoaDonNhapDAO.Instance.getChiTietHoaDonNhap(id);
        }






        public string xoa(chiTietHoaDonNhap a)
        {

            if (ChiTietHoaDonNhapDAO.Instance.xoa(a.MaHoaDonNhap,a.MaSanPham))
            {
                return "thành công";
            }
            else { return "thất bại"; }

        }

        public string them(chiTietHoaDonNhap a)
        {

            if (ChiTietHoaDonNhapDAO.Instance.addSp(a.MaHoaDonNhap, a.MaSanPham,a.SoLuong,a.DonGia))
            {
                return "thành công";
            }
            else { return "thất bại"; }

        }


        public List<thongKe> loadThongKeThang(string thang,string nam)
        {
            return  hoaDonNhapDAO.Instance.thongKethangNhap(nam, thang);    
        }

        public List<thongKe> loadThongKeNam( string nam)
        {
            return hoaDonNhapDAO.Instance.thongKeNamNhap(nam);
        }

       





    }
}
