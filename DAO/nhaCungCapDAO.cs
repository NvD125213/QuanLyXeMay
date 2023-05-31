using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class nhaCungCapDAO
    {
        private static nhaCungCapDAO instance;
        public static nhaCungCapDAO Instance
        {
            get { if (instance == null) instance = new nhaCungCapDAO(); return nhaCungCapDAO.instance; }
            private set { nhaCungCapDAO.instance = value; }
        }


        public List<nhaCungCap> ds()
        {
            List<nhaCungCap> list = new List<nhaCungCap>();

            string query = "select * from NhaCC ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                nhaCungCap nhaCungCap = new nhaCungCap(item);
                list.Add(nhaCungCap);
            }
            return list;
        }

        public bool kiemTraId(int ma)
        {
            string query = string.Format("select * from NhaCC  where id ={0}",ma);
            int ss = DataProvider.Instance.KiemTraMa(query);

            if (ss > 0)
            {
                return false;

            }
            else { return true; }
        }
        public bool them(nhaCungCap a)
        {
            string query = string.Format("insert into dbo.NhaCC(id,tenNhaCC,sdtNhaCC,emailNhaCC) values ({0},N'{1}','{2}','{3}')",a.Id,a.Name,a.Sdt,a.Email);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool sua(nhaCungCap a)
        {
            string query = string.Format("UPDATE dbo.NhaCC set tenNhaCC = N'{1}',sdtNhaCC= '{2}',emailNhaCC= '{3}' where id={0}", a.Id, a.Name, a.Sdt, a.Email);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool xoa(nhaCungCap a)
        {
            string query = string.Format("delete dbo.NhaCC where id={0}", a.Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
