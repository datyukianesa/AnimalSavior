using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalSavior.Model;

namespace AnimalSavior.Model
{
    public class petModel : INotifyPropertyChanged
    {
        private string id_pet;
        public string IdPet
        {
            get { return id_pet; }
            set { id_pet = value; }
        }

        private string pet_nama;
        public string Petnama
        {
            get { return pet_nama; }
            set { pet_nama = value; }
        }

        private string pet_info;
        public string PetInfo
        {
            get { return pet_info; }
            set { pet_info = value; }
        }

        private string pet_jenis;
        public string PetJenis
        {
            get { return pet_jenis; }
            set { pet_jenis = value; }
        }

        private string id_user;

        public string IdUser
        {
            get { return id_user; }
            set { id_user = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<string> pet_list;
        public ObservableCollection<string> Petlist
        {
            get { return pet_list; }
            set
            {
                pet_list = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("pet_list"));
            }
        }
    }
}
