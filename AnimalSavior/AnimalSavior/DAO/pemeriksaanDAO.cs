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
    class pemeriksaanDAO
    {
        private MySqlConnection conn;
        private string str = string.Empty;

        public pemeriksaanDAO(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public int save(pemeriksaanModel pemeriksaan)
        {
            str = "insert into pemeriksaan(pemeriksaan_waktu, pemeriksaan_remarks, id_user, id_pet) values (@1, @2, @3, @4)";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", pemeriksaan.PemeriksaanWaktu);
                cmd.Parameters.AddWithValue("@2", pemeriksaan.PemeriksaanRemarks);
                cmd.Parameters.AddWithValue("@3", ConfigurationManager.AppSettings["userid"]);
                cmd.Parameters.AddWithValue("@4", ConfigurationManager.AppSettings["petid"]);

                return cmd.ExecuteNonQuery();
            }
        }

        public int update(pemeriksaanModel pemeriksaan)
        {
            str = "update pemeriksaan set pemeriksaan_waktu = @1, pemeriksaan_remarks = @2 where id_pemeriksaan = @3";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", pemeriksaan.PemeriksaanWaktu);
                cmd.Parameters.AddWithValue("@2", pemeriksaan.PemeriksaanRemarks);
                cmd.Parameters.AddWithValue("@3", pemeriksaan.IdPemeriksaan);

                return cmd.ExecuteNonQuery();
            }
        }

        public int delete(pemeriksaanModel pemeriksaan)
        {
            str = "delete from pemeriksaan where id_pemeriksaan = @1";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", pemeriksaan.IdPemeriksaan);

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
