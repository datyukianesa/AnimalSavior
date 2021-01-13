using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using AnimalSavior.Model;
using System.Configuration;
using System.Data;
using System.Collections.ObjectModel;

namespace AnimalSavior.DAO
{
    public class petDAO
    {
        private MySqlConnection conn;
        private string str = string.Empty;
        public ObservableCollection<string> list = new ObservableCollection<string>();
        private string hitung;

        public petDAO(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public ObservableCollection<petModel> getPet(petModel petModel)
        {
            var pet = new ObservableCollection<petModel>();
            pet.Add(new petModel() { Petnama = petModel.Petnama, PetJenis = petModel.PetJenis, PetInfo = petModel.PetInfo , IdPet = petModel.IdPet, IdUser = petModel.IdUser});
            return pet;
        }

        public int getInfo(petModel pet)
        {
            count(pet);
            int hit = Int32.Parse(hitung);
            str = "select * from pet where id_user = @1";
            using(MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", pet.IdUser);
                var read = cmd.ExecuteReader();
                read.Read();

                if (read.HasRows)
                {
                    pet.IdPet = read["id_pet"].ToString();
                    pet.Petnama = read["pet_nama"].ToString();
                    pet.PetJenis = read["pet_jenis"].ToString();
                    pet.PetInfo = read["pet_info"].ToString();
                    getPet(pet);
                    read.Close();
                    return 1;
                }
                else
                {
                    read.Close();
                    return 0;
                }
            }
        }

        public int save(petModel pet)
        {
            str = "insert into pet(pet_nama, pet_info, pet_jenis, id_user) values (@1, @2, @3, @4)";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", pet.Petnama);
                cmd.Parameters.AddWithValue("@2", pet.PetInfo);
                cmd.Parameters.AddWithValue("@3", pet.PetJenis);
                cmd.Parameters.AddWithValue("@4", pet.IdUser);

                return cmd.ExecuteNonQuery();
            }
        }

        public int update(petModel pet)
        {
            str = "update pet set pet_nama = @1, pet_info = @2, pet_jenis = @3 where id_pet = @4";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", pet.Petnama);
                cmd.Parameters.AddWithValue("@2", pet.PetInfo);
                cmd.Parameters.AddWithValue("@3", pet.PetJenis);
                cmd.Parameters.AddWithValue("@4", pet.IdPet);

                return cmd.ExecuteNonQuery();
            }
        }

        public int delete(petModel pet)
        {
            str = "delete from pet where id_pet = @1";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", pet.IdPet);

                return cmd.ExecuteNonQuery();
            }
        }

        private petModel Mapping (MySqlDataReader read)
        {
            petModel pet = new petModel();
            pet.Petnama = read["pet_nama"] is DBNull ?
                string.Empty : read["pet_nama"].ToString();

            return pet;
        }

        public List<petModel> GetAll(petModel petmodel)
        {
            petModel pet = new petModel();
            List<petModel> petlist = new List<petModel>();
            str = "select pet_nama from pet where id_user = @1";

            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", pet.IdUser);
                using(MySqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        petlist.Add(Mapping(read));
                    }
                }
            }
            return petlist;
        }

        public DataSet datamap(petModel petModel)
        {
            str = "select pet_nama as 'Nama Pet', pet_jenis as 'Jenis', pet_info as 'Info' from pet where id_user = @a";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@a", petModel.IdUser);

                DataTable table = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds, "loadData");
                return ds;
            }
        }
        public int getData(petModel pet)
        {
            str = "select pet_nama as 'Nama Pet', pet_jenis as 'Jenis Pet', pet_info as 'Pet Info' from pet where id_pet = @a";
            using (MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@a", pet.IdPet);

                var reader = cmd.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    pet.Petnama = reader["Nama Pet"].ToString();
                    pet.PetInfo = reader["Pet Info"].ToString();
                    pet.PetJenis = reader["Jenis Pet"].ToString();
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

        public int count(petModel pet)
        {
            str = "select count(*) as jumlah from pet where id_user = @1";
            using(MySqlCommand cmd = new MySqlCommand(str, conn))
            {
                cmd.Parameters.AddWithValue("@1", pet.IdUser);
                var read = cmd.ExecuteReader();
                read.Read();

                if (read.HasRows)
                {
                    hitung = read["jumlah"].ToString();
                    read.Close();
                    return 1;
                }
                else
                {
                    read.Close();
                    return 0;
                }
            }
        }
    }
}
