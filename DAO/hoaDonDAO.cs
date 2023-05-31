using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class hoaDonDAO
    {
        private static hoaDonDAO instance;

        public static hoaDonDAO Instance
        {
            get { if (instance == null) instance = new hoaDonDAO(); return hoaDonDAO.instance; }
            private set { hoaDonDAO.instance = value; }
        }


        public List<hoaDonBanHang> GetDon()

        {
            string query = string.Format("select*from tblHoaDon");
            List<hoaDonBanHang> tableList = new List<hoaDonBanHang>();
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                hoaDonBanHang hoaDonBanHang = new hoaDonBanHang(item);
                tableList.Add(hoaDonBanHang);
            }
            return tableList;


        }
        public List<hoaDonBanHang> find(string a)

        {


            string query = string.Format("select*from tblHoaDon where NgayBan ='{0}'", a);
            List<hoaDonBanHang> tableList = new List<hoaDonBanHang>();
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dataTable.Rows)
            {
                hoaDonBanHang hoaDonBanHang = new hoaDonBanHang(item);
                tableList.Add(hoaDonBanHang);
            }
            return tableList;


        }

        public bool checkidHoaDon(string id)
        {

            int ss = DataProvider.Instance.KiemTraMa("select * from tblHoaDon where id =" + id);
            if( ss > 0)
            {
                return false;

            }
            else
            {
                return true;
            }
            
        }

        public bool themHoaDon(string a, string b, string c, string d)
        {
            string query = string.Format("insert into tblHoaDon(id,NgayBan,Manv,MaKh,TongTien) values({0},'{1}',{2},{3},0)", a, b, c, d);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool xoa(string a)
        {
            string query = string.Format("delete dbo.tblHoaDon where id ={0} ", a);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public DataTable thongTinDon(string id)
        {
            DataTable tblThongtinHD =new DataTable();
            string sql = "SELECT a.id, a.NgayBan, a.Tongtien, b.Ten, b.DiaChi, b.soDienThoai, c.tenNguoi FROM tblHoaDon AS a, KhachHang AS b, NguoiNv AS c WHERE a.id = " + id + " AND a.MaKH = b.id AND a.MaNV = c.id";
            tblThongtinHD = DataProvider.Instance.ExecuteQuery(sql);
            return tblThongtinHD;
        }


        public DataTable thongTinCtHD(string id)
        {
            DataTable tblThongtinHD = new DataTable();
            string sql = " SELECT x.tenXE, a.SoLuong, x.GiaBan, a.Gia FROM tblChiTietHoaDon AS a , tblHoaDon AS b , dbo.xe as x WHERE a.MaHD = " + id + " AND a.MaHD = b.id and a.MaSP = x.id";
            tblThongtinHD = DataProvider.Instance.ExecuteQuery(sql);
            return tblThongtinHD;
        }



        public List<thongKe> thongKethang(string thang, string nam)
        {
            List<thongKe> list = new List<thongKe>();

            string query = string.Format("SELECT * FROM fn_DoanhThuTheoThang({0}, {1}) ", thang, nam);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                thongKe baoCao = new thongKe(item);
                list.Add(baoCao);
            }
            return list;
        }


        public List<thongKe> theoNgay(string tu,string den)
        {
            List<thongKe> list = new List<thongKe>();

            string query = string.Format("SELECT * FROM thongke ('{0}', '{1}') ", tu, den);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                thongKe baoCao = new thongKe(item);
                list.Add(baoCao);
            }
            return list;
        }

        public List<thongKe> thongKeNam(string nam)
        {
            List<thongKe> list = new List<thongKe>();

            string query = string.Format("EXEC sp_ThongKeDoanhThuTheoThang @Nam = {0} ", nam);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                thongKe baoCao = new thongKe(item);
                list.Add(baoCao);
            }
            return list;
        }

        public DataTable inThongKeNgay(string tu, string den)
        {
            DataTable thongke;
            string query = string.Format("SELECT * FROM thongke ('{0}', '{1}') ", tu, den);
            thongke = DataProvider.Instance.ExecuteQuery(query);
            return thongke;
        }


        public DataTable inThongKeThang(string thang, string nam)
        {
            DataTable thongke;
            string query = string.Format("SELECT * FROM fn_DoanhThuTheoThang({0}, {1}) ", thang, nam);
            thongke = DataProvider.Instance.ExecuteQuery(query);
            return thongke;
        }


        public DataTable inThongKeNam(string nam)
        {
            DataTable thongke;
            string query = string.Format("EXEC sp_ThongKeDoanhThuTheoThang @Nam = {0} ", nam);
            thongke = DataProvider.Instance.ExecuteQuery(query);
            return thongke;
        }



    }
}
