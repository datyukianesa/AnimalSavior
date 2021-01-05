using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalSavior.Model;
using MySql.Data.MySqlClient;

namespace AnimalSavior.DAO
{
    public class userDAO
    {
        private MySqlConnection conn;
        private string str = string.Empty;

        public userDAO (MySqlConnection conn)
        {
            this.conn = conn;
        }

        public int save(userModel user)
        {
            str = "insert into user(username, password, id_role) values (@1, @2, @3)";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", "a");
                cmd.Parameters.AddWithValue("@2", "a");
                cmd.Parameters.AddWithValue("@3", "a");

                return cmd.ExecuteNonQuery();
            }
        }

        public int update(userModel user)
        {
            str = "update user set password = @1 where id_user = @2";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", "a");
                cmd.Parameters.AddWithValue("@2", "a");

                return cmd.ExecuteNonQuery();
            }
        }

        public int delete(userModel user)
        {
            str = "delete from user where id_user = @1";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", "a");

                return cmd.ExecuteNonQuery();
            }
        }

        //method getAll tergantung dari front end
    }
}
