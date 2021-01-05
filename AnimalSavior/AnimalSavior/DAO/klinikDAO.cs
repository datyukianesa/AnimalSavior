using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalSavior.Model;
using MySql.Data.MySqlClient;

namespace AnimalSavior.DAO
{
    public class klinikDAO
    {
        private MySqlConnection conn;
        private string str = string.Empty;

        public klinikDAO(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public int save(klinikModel klinik)
        {
            str = "insert into klinik(klinik_nama, klinik_alamat) values (@1, @2)";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", "a");
                cmd.Parameters.AddWithValue("@2", "a");

                return cmd.ExecuteNonQuery();
            }
        }

        public int update(klinikModel klinik)
        {
            str = "update klinik set klinik_nama = @1, klinik_alamat = @2 where id_klinik = @3";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", "a");
                cmd.Parameters.AddWithValue("@2", "a");
                cmd.Parameters.AddWithValue("@3", "a");

                return cmd.ExecuteNonQuery();
            }
        }

        public int delete(klinikModel klinik)
        {
            str = "delete from klinik where id_klinik = @1";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", "a");

                return cmd.ExecuteNonQuery();
            }
        }

        //method getAll tergantung dari front end
    }
}
