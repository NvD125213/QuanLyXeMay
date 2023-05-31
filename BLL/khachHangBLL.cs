using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class khachHangBLL
    {

        private static khachHangBLL instance;

        public static khachHangBLL Instance
        {
            get { if (instance == null) instance = new khachHangBLL(); return khachHangBLL.instance; }
            private set { khachHangBLL.instance = value; }
        }


        public List<khachHang> ds()
        {
            return  khacHangDAO.Instance.getListKhachHang();
        }


        public List<khachHang> find(string id, string name)
        {
             return khacHangDAO.Instance.find(id, name);
        }

        public string them(  string id,  string name, string DiaChi, string soDienThoai,  string email )
        {
            
            if (khacHangDAO.Instance.checkidkhachHang(id))
            {
                if(khacHangDAO.Instance.themKhachHang(id,  name,  DiaChi,  soDienThoai, email))
                {
                    return "thành công";
                }
                else
                {
                    return "thất bại";
                }

            }
            {
                return "mã bị trùng";
            }
        }


        public string sua(string id, string name, string DiaChi, string soDienThoai, string email)
        {

            if (khacHangDAO.Instance.SuwaThongTin(id, name, DiaChi, soDienThoai, email))
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

            if (khacHangDAO.Instance.xoakhachHang(id))
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
