﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using AnimalSavior.Model;

namespace AnimalSavior.DAO
{
    public class petDAO
    {
        private MySqlConnection conn;
        private string str = string.Empty;

        public petDAO(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public int save(petModel pet)
        {
            str = "insert into pet(pet_nama, pet_info, pet_jenis, id_user) values (@1, @2, @3, @4)";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", "a");
                cmd.Parameters.AddWithValue("@2", "a");
                cmd.Parameters.AddWithValue("@3", "a");
                cmd.Parameters.AddWithValue("@4", "a");

                return cmd.ExecuteNonQuery();
            }
        }

        public int update(petModel pet)
        {
            str = "update pet set pet_nama = @1, pet_info = @2, pet_jenis = @3 where id_pet = @4";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", "a");
                cmd.Parameters.AddWithValue("@2", "a");
                cmd.Parameters.AddWithValue("@3", "a");
                cmd.Parameters.AddWithValue("@4", "a");

                return cmd.ExecuteNonQuery();
            }
        }

        public int delete(petModel pet)
        {
            str = "delete from pet where id_pet = @1";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", "a");

                return cmd.ExecuteNonQuery();
            }
        }

        //method getAll tergantung dari front end
    }
}
