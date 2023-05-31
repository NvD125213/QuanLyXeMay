using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class nhaCungCap
    {
        public nhaCungCap(int id,string name,string sdt,string email) 
        {   this.Id = id;
            this.Name = name;
            this.Sdt = sdt;
            this.Email = email;
        }

        public nhaCungCap() { }
        public nhaCungCap(DataRow row)

        {
            this.Id = (int)row["id"];
            this.Name = row["tenNhaCC"].ToString();
            this.Sdt = row["sdtNhaCC"].ToString();
            this.Email = row["emailNhaCC"].ToString();
        }

        protected int id;
        protected string name;
        protected string sdt;
        protected string email;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
    }
}
