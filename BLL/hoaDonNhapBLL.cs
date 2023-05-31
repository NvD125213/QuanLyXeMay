using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMExcel = Microsoft.Office.Interop.Excel;
namespace BLL
{
    public class hoaDonNhapBLL
    {

        private static hoaDonNhapBLL instance;

        public static hoaDonNhapBLL Instance
        {
            get { if (instance == null) instance = new hoaDonNhapBLL(); return hoaDonNhapBLL.instance; }
            private set { hoaDonNhapBLL.instance = value; }
        }

        public List<hoaDonNhap> ds()
        {
            return hoaDonNhapDAO.Instance.GetDonNhaps();
        }
        public List<hoaDonNhap> fid(string ngay)
        {
            return hoaDonNhapDAO.Instance.find( ngay);


        }

        public string them(string id,string ngayNhap,string manv,string maNCC)
        {
            if (hoaDonNhapDAO.Instance.checkidHoaDonNhap(id))
            {
                    if (hoaDonNhapDAO.Instance.themHoaDon( id,  ngayNhap,  manv,maNCC))
                    {
                        return "thành công";
                    }
                    else { return "thất bại"; }
               

            }
            else
            {
                return "trùng id";
            }

        }


        public string xoa(string id)
        {

            if (hoaDonNhapDAO.Instance.xoa(id))
            {
                return "thành công";
            }
            else { return "thất bại"; }

        }

        public List<thongKe> dsThongKeThang( string thang,string nam)
        {
             return hoaDonNhapDAO.Instance.thongKethangNhap(thang, nam);
        }

        public List<thongKe> dsThongKeNam( string nam)
        {
            return  hoaDonNhapDAO.Instance.thongKeNamNhap( nam);
        }


        public void inThongKeThang(string thang, string nam)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            int hang = 0, cot = 0;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5;
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "cửa hàng xe máy HonDa Đức Hiệp";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Ân Thi Hưng Yên";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (08)65963775";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3;
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "thống kê";

            DataTable thongke;
            thongke = hoaDonNhapDAO.Instance.thongTinHoaDonNhapThang(thang, nam);

            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "ngày";
            exRange.Range["C11:C11"].Value = "doanh thu"; ;
            for (hang = 0; hang < thongke.Rows.Count; hang++)
            {

                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < thongke.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = thongke.Rows[hang][cot].ToString();

                }
            }
            exSheet.Name = "báo cáo";
            exApp.Visible = true;
        }

        public void inThongKetNam(string nam)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            int hang = 0, cot = 0;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5;
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "cửa hàng xe máy HonDa Đức Hiệp";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Ân Thi Hưng Yên";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (08)65963775";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3;
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "thống kê";

            DataTable thongke;
            thongke = hoaDonNhapDAO.Instance.thongTinHoaDonNhapNam(nam);
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "tháng";
            exRange.Range["C11:C11"].Value = "doanh thu"; ;
            for (hang = 0; hang < thongke.Rows.Count; hang++)
            {

                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < thongke.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = thongke.Rows[hang][cot].ToString();

                }
            }
            exSheet.Name = "báo cáo";
            exApp.Visible = true;
        }

    }
}
