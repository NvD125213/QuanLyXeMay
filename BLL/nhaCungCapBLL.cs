using DAO;
using DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BLL
{
    public class nhaCungCapBLL
    {

        private static nhaCungCapBLL instance;

        public static nhaCungCapBLL Instance
        {
            get { if (instance == null) instance = new nhaCungCapBLL(); return nhaCungCapBLL.instance; }
            private set { nhaCungCapBLL.instance = value; }
        }


        public List<nhaCungCap> ds()
        {
            return  nhaCungCapDAO.Instance.ds();
        }


        

        public string them(nhaCungCap a)
        {

            if (nhaCungCapDAO.Instance.kiemTraId(a.Id))
            {
                if (nhaCungCapDAO.Instance.them(a))
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


        public string sua(nhaCungCap a)
        {

            if (nhaCungCapDAO.Instance.sua(a))
            {
                return "thành công";
            }
            else
            {
                return "thất bại";
            }
        }


        public string xoa(nhaCungCap a)
        {

            if (nhaCungCapDAO.Instance.xoa(a))
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
