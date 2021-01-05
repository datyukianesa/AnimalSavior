using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace AnimalSavior
{
    public class connection
    {
        private MySqlConnection conn = null;
        private static connection dbconnect = null;

        private connection()
        {
            if (conn == null)
            {
                string server = ConfigurationManager.AppSettings["server"];
                string port = ConfigurationManager.AppSettings["port"];
                string database = ConfigurationManager.AppSettings["database"];
                string username = ConfigurationManager.AppSettings["username"];
                string password = ConfigurationManager.AppSettings["password"];

                string str = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + username + ";PASSWORD=" + password;

                conn = new MySqlConnection(str);

                conn.Open();

            }
        }

        public static connection GetInstance()
        {
            if(dbconnect == null)
            {
                dbconnect = new connection();
            }
            return dbconnect;
        }

        public MySqlConnection GetConnection()
        {
            return this.conn;
        }
    }
}
