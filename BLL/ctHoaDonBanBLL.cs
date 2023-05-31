using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class ctHoaDonBanBLL
    {


        private static ctHoaDonBanBLL instance;
        public static ctHoaDonBanBLL Instance
        {
            get { if (instance == null) instance = new ctHoaDonBanBLL(); return ctHoaDonBanBLL.instance; }
            private set { ctHoaDonBanBLL.instance = value; }
        }


        public List<chiTietHoaDonXuat> ds(string id)
        {
            return ChiTietHoaDonDAO.Instance.getChiTietHoaDon(id);
        }

        public string them(chiTietHoaDonXuat a)
        {

            if (ChiTietHoaDonDAO.Instance.kiemTraSoLuong(a.MaSanPham, a.SoLuong))
            {
                if (ChiTietHoaDonDAO.Instance.addSp(a.MaHoaDon,a.MaSanPham,a.SoLuong))
                {
                    return " thành công";
                }
                else
                {
                    return " thêm thất bại";
                }
            }
            else
            {
                return " số lượng không đủ";
            }

        }

        public string xoa(chiTietHoaDonXuat a)
        {

            if (ChiTietHoaDonDAO.Instance.xoa(a.MaHoaDon,a.MaSanPham))
            {
                return "thành công";
            }
            else { return "thất bại"; }

        }
    }
}
