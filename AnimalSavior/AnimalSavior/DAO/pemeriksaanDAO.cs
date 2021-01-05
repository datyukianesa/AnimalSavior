using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using AnimalSavior.Model;

namespace AnimalSavior.DAO
{
    class pemeriksaanDAO
    {
        private MySqlConnection conn;
        private string str = string.Empty;

        public pemeriksaanDAO(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public int save(pemeriksaanDAO pemeriksaan)
        {
            str = "insert into pemeriksaan(pemeriksaan_waktu, pemeriksaan_remarks, id_user, id_pet) values (@1, @2, @3, @4)";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", "a");
                cmd.Parameters.AddWithValue("@2", "a");
                cmd.Parameters.AddWithValue("@3", "a");
                cmd.Parameters.AddWithValue("@4", "a");

                return cmd.ExecuteNonQuery();
            }
        }

        public int update(pemeriksaanDAO pemeriksaan)
        {
            str = "update pemeriksaan set pemeriksaan_waktu = @1, pemeriksaan_remarks = @2 where id_pemeriksaan = @3";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", "a");
                cmd.Parameters.AddWithValue("@2", "a");
                cmd.Parameters.AddWithValue("@3", "a");

                return cmd.ExecuteNonQuery();
            }
        }

        public int delete(pemeriksaanDAO pemeriksaan)
        {
            str = "delete from pemeriksaan where id_pemeriksaan = @1";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", "a");

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
