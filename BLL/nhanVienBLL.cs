using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class nhanVienBLL
    {

        private static nhanVienBLL instance;

        public static nhanVienBLL Instance
        {
            get { if (instance == null) instance = new nhanVienBLL(); return nhanVienBLL.instance; }
            private set { nhanVienBLL.instance = value; }
        }


        public bool Login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);

        }

        public List<nhanVien> ds()
        {
            return NhanVienDAO.Instance.getLisNhanVien();
        }

        public string them(string id, string tenNguoi, string GioiTinh, string ngaySinh, string queQuan, string soDienThoai, string luongCoban, string email, string userName, string passWordd, int typee)
        {
            if (NhanVienDAO.Instance.checkidNhanVien(id))
            {
                if (NhanVienDAO.Instance.checkTk(userName))
                {
                    if (NhanVienDAO.Instance.InsertNhanVien(id, tenNguoi, GioiTinh, ngaySinh, queQuan, soDienThoai, luongCoban, email, userName, passWordd, typee))
                    {
                        return "thành công";
                    }
                    else { return "thất bại"; }
                }
                else
                {
                    return "trùng tên tài khoản";
                }

            }
            else
            {
                return "trùng id";
            }

        }




        public string sua(string id, string tenNguoi, string GioiTinh, string ngaySinh, string queQuan, string soDienThoai, string luongCoban, string email, string userName, string passWordd, int typee)
        {
            if (NhanVienDAO.Instance.Sua(id, tenNguoi, GioiTinh, ngaySinh, queQuan, soDienThoai, luongCoban, email, userName, passWordd, typee))
            {
                return "thành công";
            }
            else { return "thất bại"; }

        }

        public string xoa(string id)
        {
            if (NhanVienDAO.Instance.xoaNhanVien(id))
            {
                return "thành công";
            }
            else { return "thất bại"; }
        }


        public string[] idVaQuyen(string tk , string mk ) 
        {
            return AccountDAO.Instance.layIdQuyen(tk, mk);
        }
    }
}
