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
    public class ChiTietHoaDonDAO
    {
        private static ChiTietHoaDonDAO instance;
        public static ChiTietHoaDonDAO Instance
        {
            get { if (instance == null) instance = new ChiTietHoaDonDAO(); return ChiTietHoaDonDAO.instance; }
            private set { ChiTietHoaDonDAO.instance = value; }
        }

        public List<chiTietHoaDonXuat> getChiTietHoaDon(string id)
        {
            List<chiTietHoaDonXuat> list = new List<chiTietHoaDonXuat>();

            string query = "select * from dbo.tblChiTietHoaDon where  MaHD =" + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                chiTietHoaDonXuat chiTietHoaDon = new chiTietHoaDonXuat(item);
                list.Add(chiTietHoaDon);
            }
            return list;
        }


        public bool addSp(int maHD, int maSp, int SoLong)
        {

            string query = "exec sp_ThemChiTietHoaDon7 @MaHoaDon , @MaSanPham , @SoLuong";
            
            int ss = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maHD, maSp, SoLong, /*list*/});

            if (ss > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }


        public bool xoa(int a, int b)
        {
            string query = "exec sp_xoaChiTietHoaDon1 @MaHoaDon , @MaSanPham";
            
            int ss = DataProvider.Instance.ExecuteNonQuery(query, new object[] { a, b /*list*/});


            if (ss > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public bool kiemTraSoLuong(int a, int b)
        {
            string q = string.Format("select * from xe where id ={0} and SoLuong >= {1}", a, b);
            int ss = DataProvider.Instance.KiemTraMa(q);
            return ss > 0;
        }
    }
}
