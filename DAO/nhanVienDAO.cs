using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace DAO
{
    public class NhanVienDAO
    {

        private static NhanVienDAO instance;
        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return NhanVienDAO.instance; }
            private set { NhanVienDAO.instance = value; }
        }

        public List<nhanVien> getLisNhanVien()
        {
            List<nhanVien> list = new List<nhanVien>();

            string query = "select * from NguoiNv ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                nhanVien nhanVien = new nhanVien(item);
                list.Add(nhanVien);
            }
            return list;
        }

        



        public bool InsertNhanVien(string id, string tenNV, string gioiTinh, string ngaySinh, string queQuan, string soDienThoai, string luongCoban, string email, string userName, string passWordd, int type)
        {

            string query = string.Format("insert into NguoiNv(id,tenNguoi,gioiTinh,NgaySinh,QueQuan,soDienThoai,LuongCoBan,Email,UserName,PassWordd,Typee) values  ({0},N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',{6},N'{7}',{8},N'{9}',{10})", id, tenNV, gioiTinh, ngaySinh, queQuan, soDienThoai, luongCoban, email, userName, passWordd, type);
            
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }


        //public bool InsertNhanVien(int id, string tenNV, string gioiTinh, string ngaySinh, string queQuan, string soDienThoai, int luongCoban, string email, string userName, string passWordd, int type)
        //{
        //    string query = "insert into NguoiNv(id, tenNguoi, gioiTinh, NgaySinh, QueQuan, soDienThoai, LuongCoBan, Email, UserName, PassWordd, Typee) " +
        //                   "values (@id, @tenNV, @gioiTinh, @ngaySinh, @queQuan, @soDienThoai, @luongCoban, @email, @userName, @passWordd, @type)";
        //    using (SqlConnection connection = new SqlConnection("Data Source=DELL-G15-5515;Initial Catalog=QuanLyXeMay;Integrated Security=True"))
        //    {
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("@id", id);
        //        command.Parameters.AddWithValue("@tenNV", tenNV);
        //        command.Parameters.AddWithValue("@gioiTinh", gioiTinh);
        //        command.Parameters.AddWithValue("@ngaySinh", DateTime.Parse(ngaySinh));
        //        command.Parameters.AddWithValue("@queQuan", queQuan);
        //        command.Parameters.AddWithValue("@soDienThoai", soDienThoai);
        //        command.Parameters.AddWithValue("@luongCoban", luongCoban);
        //        command.Parameters.AddWithValue("@email", email);
        //        command.Parameters.AddWithValue("@userName", userName);
        //        command.Parameters.AddWithValue("@passWordd", passWordd);
        //        command.Parameters.AddWithValue("@type", type);

        //        connection.Open();
        //        int result = command.ExecuteNonQuery();

        //        return result > 0;
        //    }
        //}

        public bool checkidNhanVien( string id)
        {


            int ss = DataProvider.Instance.KiemTraMa("select * from NguoiNv where id =" + id);
            if (ss > 0)
            {
                return false;

            }
            else { return true; }
        }


        public bool checkTk(string Tk)
        {

            string q = "select * from NguoiNv where UserName ='" + Tk + "'";
            int ss = DataProvider.Instance.KiemTraMa(q);
            if (ss > 0)
            {
                return false;

            }
            else { return true; }
        }
        public bool xoaNhanVien(string id)
        {
            string query = string.Format("delete NguoiNv where id =" + id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool Sua(string id, string tenNV, string gioiTinh, string ngaySinh, string queQuan, string soDienThoai, string luongCoban, string email, string userName, string passWordd, int type)
        {

            string query = string.Format("UPDATE dbo.NguoiNv Set tenNguoi =N'{0}',gioiTinh= N'{1}' , NgaySinh= N'{2}',QueQuan= N'{3}',soDienThoai= N'{4}',LuongCoBan= {5},Email= '{6}',UserName= N'{7}',PassWordd= N'{8}',Typee= {9} where id={10}", tenNV, gioiTinh, ngaySinh, queQuan, soDienThoai, luongCoban, email, userName, passWordd, type, id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}

