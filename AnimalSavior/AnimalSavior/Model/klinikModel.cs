using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSavior.Model
{
    public class klinikModel
    {
        private string id_klinik;
        public string IdKlinik
        {
            get { return id_klinik; }
            set { id_klinik = value; }
        }

        private string klinik_nama;
        public string KlinikNama
        {
            get { return klinik_nama; }
            set { klinik_nama = value; }
        }

        private string klinik_alamat;
        public string KlinikAlamat
        {
            get { return klinik_alamat; }
            set { klinik_alamat = value; }
        }
    }
}
