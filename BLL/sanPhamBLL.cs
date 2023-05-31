using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class sanPhamBLL
    {


        private static sanPhamBLL instance;

        public static sanPhamBLL Instance
        {
            get { if (instance == null) instance = new sanPhamBLL(); return sanPhamBLL.instance; }
            private set { sanPhamBLL.instance = value; }
        }


        public List<sanPham> ds()
        {
            return SanPhamDAO.Instance.getLisSanPham ();
        }


        public List<sanPham> find(string id, string name)
        {
            return SanPhamDAO.Instance.find(id,name);
        }


        public string them(    string id,   string tenXe,   string hangXe,  string dungTich,  string loaiXe, string namSx, string Mau,  string giaBan,   string linlAnh)
        {
            if (SanPhamDAO.Instance.checkidSanPham(id))
            {
                if (SanPhamDAO.Instance.themSanPham( id, tenXe,  hangXe,   dungTich, loaiXe, namSx, Mau,  giaBan,   linlAnh ))
                {
                    return "thành công";
                }
                else
                {
                    return "thất bại";
                }
            }
            else
            {
                return "id sản phẩm đã tồn tại";
            }

        }



        public string sua(string id, string tenXe, string hangXe, string dungTich, string loaiXe, string namSx, string Mau, string giaBan, string linlAnh)
        {
            if (SanPhamDAO.Instance.Sua(id, tenXe, hangXe, dungTich, loaiXe, namSx, Mau, giaBan, linlAnh))
            {
                return "thành công";
            }
            else
            {
                return "thất bại";
            }

        }


        public string xoa(string id)
        {
            if (SanPhamDAO.Instance.xoaSanPham(id))
            {
                return "thành công";
            }
            else
            {
                return "thất bại";
            }
        }





    }
}
