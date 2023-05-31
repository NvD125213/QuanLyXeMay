using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class ChiTietHoaDonNhapDAO
    {

        private static ChiTietHoaDonNhapDAO instance;
        public static ChiTietHoaDonNhapDAO Instance
        {
            get { if (instance == null) instance = new ChiTietHoaDonNhapDAO(); return ChiTietHoaDonNhapDAO.instance; }
            private set { ChiTietHoaDonNhapDAO.instance = value; }
        }

        public List<chiTietHoaDonNhap> getChiTietHoaDonNhap(string id)
        {
            List<chiTietHoaDonNhap> list = new List<chiTietHoaDonNhap>();

            string query = "select MaHoaDonNhap , MaSanPham , SoLuong ,DonGia from dbo.ChiTietHoaDonNhap where  MaHoaDonNhap =" + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                chiTietHoaDonNhap chiTietHoaDonNhap = new chiTietHoaDonNhap(item);
                list.Add(chiTietHoaDonNhap);
            }
            return list;
        }





        public bool addSp(int maHD, int maSp, int SoLong, string Gia)
        {

            string query = "exec ThemHoaDonNhap3  @MaHoaDon , @MaSanPham , @SoLuong , @GiaSanPham ";

            int ss = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maHD, maSp, SoLong, Gia /*list*/});


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
            string query = "exec XoaChiTietHoaDonNhap @MaHoaDon , @MaSanPham";

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
    }
}
