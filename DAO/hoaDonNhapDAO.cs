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
    public class hoaDonNhapDAO
    {

        private static hoaDonNhapDAO instance;

        public static hoaDonNhapDAO Instance
        {
            get { if (instance == null) instance = new hoaDonNhapDAO(); return hoaDonNhapDAO.instance; }
            private set { hoaDonNhapDAO.instance = value; }
        }


        public List<hoaDonNhap> GetDonNhaps()

        {
            string query = string.Format("select*from HoaDonNhap");
            List<hoaDonNhap> tableList = new List<hoaDonNhap>();
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                hoaDonNhap nhanVien = new hoaDonNhap(item);
                tableList.Add(nhanVien);
            }
            return tableList;
        }


        public List<hoaDonNhap> find( string b)

        {

           
            
            string query = string.Format("select*from HoaDonNhap  where NgayNhap ='{0}'", b);
            List<hoaDonNhap> tableList = new List<hoaDonNhap>();
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                hoaDonNhap nhanVien = new hoaDonNhap(item);
                tableList.Add(nhanVien);
            }
            return tableList;
        }

        public bool checkidHoaDonNhap(string id)
        {

            int ss = DataProvider.Instance.KiemTraMa("select * from HoaDonNhap where MaHoaDonNhap =" + id);
            
            if (ss > 0)
            {
                return false;

            }else { return true; }
        }



        public bool themHoaDon(string a, string b, string c, string d)
        {
            string query = string.Format("insert into HoaDonNhap(MaHoaDonNhap,NgayNhap,MaNguoiNv,MaNhaCC,TongTien) values('{0}','{1}','{2}',{3},0)", a, b, c ,d);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool xoa(string a)
        {
            string query = string.Format("delete dbo.HoaDonNhap where MaHoaDonNhap ={0} ", a);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }


        public List<thongKe> thongKethangNhap(string thang, string nam)
        {
            List<thongKe> list = new List<thongKe>();

            string query = string.Format("SELECT * FROM thongKeNhapThang({0}, {1}) ", thang, nam);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                thongKe baoCao = new thongKe(item);
                list.Add(baoCao);
            }
            return list;
        }

        public List<thongKe> thongKeNamNhap(string nam)
        {
            List<thongKe> list = new List<thongKe>();

            string query = string.Format("SELECT * FROM ThongKeNhapTheoThang({0}); ", nam);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                thongKe baoCao = new thongKe(item);
                list.Add(baoCao);
            }
            return list;
        }


        public DataTable thongTinHoaDonNhapThang(string thang, string nam) 
        {
            DataTable thongke;
            string query = string.Format("SELECT * FROM thongKeNhapThang({0}, {1}) ", thang, nam);
            thongke = DataProvider.Instance.ExecuteQuery(query);
            return thongke;

        }


        public DataTable thongTinHoaDonNhapNam( string nam)
        {
            DataTable thongke;
            string query = string.Format("SELECT * FROM ThongKeNhapTheoThang({0}); ", nam);
            thongke = DataProvider.Instance.ExecuteQuery(query);
            return thongke;

        }





    }
}
