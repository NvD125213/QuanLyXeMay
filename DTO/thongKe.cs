using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class thongKe
    {

        public thongKe(string mucBC, string doanhThu)
        {
            this.MucBc = mucBC;
            this.DoanhThu = doanhThu;
        }

        public thongKe(DataRow row)
        {
            this.MucBc = row[0].ToString();
            this.DoanhThu = row[1].ToString();

        }

        private string mucBc;
        private string doanhThu;

        public string MucBc { get => mucBc; set => mucBc = value; }
        public string DoanhThu { get => doanhThu; set => doanhThu = value; }
    }
}
