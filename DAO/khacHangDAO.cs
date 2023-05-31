using DAO;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class khacHangDAO
    {
        private static khacHangDAO instance;
        public static khacHangDAO Instance
        {
            get { if (instance == null) instance = new khacHangDAO(); return khacHangDAO.instance; }
            private set { khacHangDAO.instance = value; }
        }



        public List<khachHang> getListKhachHang()
        {
            List<khachHang> list = new List<khachHang>();

            string query = "select * from KhachHang ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                khachHang khachHang = new khachHang(item);
                list.Add(khachHang);
            }
            return list;
        }
        public List<khachHang> find(string a, string b)
        {
            List<khachHang> list = new List<khachHang>();
            if (a.Length == 0)
            {
                a = "0";
            }
            if (b.Length == 0)
            {
                b = "0";
            }
            string query = string.Format("select * from KhachHang  where id ={0} or Ten LIKE '%{1}%'", a, b);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                khachHang khachHang = new khachHang(item);
                list.Add(khachHang);
            }
            return list;
        }




        public bool checkidkhachHang(string id)
        {
            
            int ss = DataProvider.Instance.KiemTraMa("select * from KhachHang where id =" + id);

            if (ss > 0)
            {
                return false;

            }
            else { return true; }
        }



        public bool xoakhachHang(string id)
        {
            string query = string.Format("delete  KhachHang where id =" + id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool themKhachHang(string a, string b, string c, string d, string e)
        {
            string query = string.Format("insert into KhachHang(id,Ten,diaChi,soDienThoai,email) values({0},N'{1}',N'{2}','{3}','{4}')", a, b, c, d, e);

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool SuwaThongTin( string a,  string b, string c, string d,string e)
        {
            string query = string.Format("UPDATE dbo.KhachHang set Ten=N'{0}',diaChi=N'{1}',soDienThoai='{2}',email='{3}' Where id ={4}", b, c, d, e,a);

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }



    }
}
