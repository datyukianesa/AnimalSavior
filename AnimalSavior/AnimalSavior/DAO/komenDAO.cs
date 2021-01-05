using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using AnimalSavior.Model;

namespace AnimalSavior.DAO
{
    public class komenDAO
    {
        private MySqlConnection conn;
        private string str = string.Empty;

        public komenDAO(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public int save(komenDAO komen)
        {
            str = "insert into komen(komen_isi, komen_timestamp, id_user, id_post) values (@1, @2, @3, @4)";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", "a");
                cmd.Parameters.AddWithValue("@2", "a");
                cmd.Parameters.AddWithValue("@3", "a");
                cmd.Parameters.AddWithValue("@4", "a");

                return cmd.ExecuteNonQuery();
            }
        }

        public int delete(komenDAO komen)
        {
            str = "";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", "a");
                cmd.Parameters.AddWithValue("@2", "a");
                cmd.Parameters.AddWithValue("@3", "a");
                cmd.Parameters.AddWithValue("@4", "a");

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
