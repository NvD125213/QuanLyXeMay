using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {


            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord /*list*/});
            
            return result.Rows.Count > 0;

        }

        
        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from NguoiNv where UserName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }
        public string[] layIdQuyen(string tk , string mk ) 
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select id,Typee from NguoiNv where UserName = '" + tk + "'  and PassWordd='" + mk + "' ");
                string[] s= new string[2];
                foreach (DataRow row in data.Rows)
                {
                    s[0] = row[0].ToString(); ;
                    s[1]= row[1].ToString(); ;
                    break;
                }

                return s;


            
        }

        

    }
}
