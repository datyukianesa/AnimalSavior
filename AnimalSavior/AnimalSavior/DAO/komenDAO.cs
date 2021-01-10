using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using AnimalSavior.Model;
using System.Configuration;

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

        public int save(komenModel komen)
        {
            str = "insert into komen(komen_isi, komen_timestamp, id_user, id_post) values (@1, @2, @3, @4)";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", komen.KomenIsi);
                cmd.Parameters.AddWithValue("@2", komen.KomenTimestamp);
                cmd.Parameters.AddWithValue("@3", ConfigurationManager.AppSettings["userid"]);
                cmd.Parameters.AddWithValue("@4", ConfigurationManager.AppSettings["postid"]);

                return cmd.ExecuteNonQuery();
            }
        }

        public int delete(komenModel komen)
        {
            str = "delete from komen where id_komen = @1";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", komen.IdKomen);

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
