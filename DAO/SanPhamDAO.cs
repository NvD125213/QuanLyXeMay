
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAO;
using DTO;
using System.Threading.Tasks;


namespace DAO
{
    public class SanPhamDAO
    {
        private static SanPhamDAO instance;
        public static SanPhamDAO Instance
        {
            get { if (instance == null) instance = new SanPhamDAO(); return SanPhamDAO.instance; }
            private set { SanPhamDAO.instance = value; }
        }

        public List<sanPham> getLisSanPham()
        {
            List<sanPham> list = new List<sanPham>();

            string query = "select * from xe ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                sanPham sanPham = new sanPham(item);
                list.Add(sanPham);
            }
            return list;
        }

        public List<sanPham> find(string a, string b)
        {
            List<sanPham> list = new List<sanPham>();
            if (a.Length == 0)
            {
                a = "0";
            }
            if (b.Length == 0)
            {
                b = "0";
            }

            string query = string.Format("select * from xe where id={0} or tenXE LIKE '%{1}%' ", a, b);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                sanPham sanPham = new sanPham(item);
                list.Add(sanPham);
            }
            return list;
        }


        public bool checkidSanPham(string id)
        {
                
            int ss = DataProvider.Instance.KiemTraMa("select * from xe where id =" + id);

            if (ss > 0)
            {
                return false;

            }
            else { return true; }
        }

        public bool themSanPham(string a, string b, string c, string d, string e, string g, string h, string j, string k)
        {
            string query = string.Format("insert into xe(id,tenXE,hangXE,dungTich,loaiXe,namSx,Color,GiaBan,anh,SoLuong) values({0},N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',{7},N'{8}',0) ", a, b, c, d, e, g, h, j, k);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }


        public bool xoaSanPham(string id)
        {
            string query = string.Format("delete xe where id =" + id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool Sua(string a, string b, string c, string d, string e, string g, string h, string i, string k)
        {
            string query = string.Format("UPDATE dbo.xe Set tenXE=N'{0}',hangXE=N'{1}',dungTich=N'{2}',loaiXe=N'{3}',namSx='{4}',Color=N'{5}',GiaBan={6},anh='{7}' where id={8}", b, c, d, e, g, h, i, k,a);
            
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;

        }
    }
}