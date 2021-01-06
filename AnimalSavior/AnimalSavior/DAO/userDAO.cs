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
                cmd.Parameters.AddWithValue("@1", user.Username);
                cmd.Parameters.AddWithValue("@2", user.Password);
                cmd.Parameters.AddWithValue("@3", "2");

                return cmd.ExecuteNonQuery();
            }
        }

        public int update(userModel user)
        {
            str = "update user set password = @1 where id_user = @2";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", user.Password);
                cmd.Parameters.AddWithValue("@2", user.IdUser);

                return cmd.ExecuteNonQuery();
            }
        }

        public int delete(userModel user)
        {
            str = "delete from user where id_user = @1";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", user.IdUser);

                return cmd.ExecuteNonQuery();
            }
        }

        public int login(userModel user)
        {
            str = "SELECT count(*) as num from user where username = @1 and password = @2";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", user.IdUser);
                cmd.Parameters.AddWithValue("@2", user.Password);

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    user.IdUser = (string)reader["id_user"];
                    return 1;
                }
                else
                {
                    return 0;
                }                
            }
        }
        //method getAll tergantung dari front end
    }
}
