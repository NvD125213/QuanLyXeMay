using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Account
    {

        private string userName;
        private string password;
        private int type;

        public Account(string userName,  int type, string password = null)
        {
            this.UserName = userName;
            this.Type = type;
            this.Password = password;
        }

        public Account(DataRow row)
        {
            this.UserName = row["UserName"].ToString();
            this.Type = (int)row["Typee"];
            this.Password = row["PassWordd"].ToString();
        }

       

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

       

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
    }
}
