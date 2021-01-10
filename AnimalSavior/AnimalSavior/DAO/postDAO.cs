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
    class postDAO
    {
        private MySqlConnection conn;
        private string str = string.Empty;

        public postDAO(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public int save(postModel post)
        {
            str = "insert into post(post_judul, post_isi, post_waktu, id_user) values (@1, @2, @3, @4)";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", post.PostJudul);
                cmd.Parameters.AddWithValue("@2", post.PostIsi);
                cmd.Parameters.AddWithValue("@3", post.PostWaktu);
                cmd.Parameters.AddWithValue("@4", ConfigurationManager.AppSettings["userid"]);

                return cmd.ExecuteNonQuery();
            }
        }

        public int update(postModel post)
        {
            str = "update post set post_judul = @1, post_isi = @2, post_waktu = @3 where id_post = @4";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", post.PostJudul);
                cmd.Parameters.AddWithValue("@2", post.PostIsi);
                cmd.Parameters.AddWithValue("@3", post.PostWaktu);
                cmd.Parameters.AddWithValue("@4", post.IdPost);

                return cmd.ExecuteNonQuery();
            }
        }

        public int delete(postModel post)
        {
            str = "delete from post where post_id = @1";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", post.IdPost);

                return cmd.ExecuteNonQuery();
            }
        }

        //put getall here
    }
}
