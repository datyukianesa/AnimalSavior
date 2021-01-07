using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalSavior.Model;
using MySql.Data.MySqlClient;
using System.Configuration;
using MySqlConnector;

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
            str = "SELECT * from user where username = @1 and password = @2";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", user.Username);
                cmd.Parameters.AddWithValue("@2", user.Password);

                var reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    ConfigurationManager.AppSettings["userid"] = reader["id_user"].ToString();
                    reader.Close();
                    return 1;
                }
                else
                {
                    reader.Close();
                    return 0;
                }
            }
        }

        public int getUsername(userModel user)
        {
            str = "select * from user where id_user = @1";
            using(MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", user.IdUser);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user.Username = reader["username"].ToString();
                    reader.Close();
                    return 1;
                }
                else
                {
                    reader.Close();
                    return 0;
                }
            }
        }

        public int getPet(userModel user)
        {
            str = "select * from pet where id_user = @1 limit 1";
            using(MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", user.IdUser);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user.Pet = reader["pet_jenis"].ToString();
                    reader.Close();
                    return 1;
                }
                else
                {
                    reader.Close();
                    return 0;
                }
            }
        }
    }
}
