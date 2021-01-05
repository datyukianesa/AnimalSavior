using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSavior.Model
{
    class pemeriksaanModel
    {
        private string id_pemeriksaan;
        public string IdPemeriksaan
        {
            get { return id_pemeriksaan; }
            set { id_pemeriksaan = value; }
        }

        private string pemeriksaan_waktu;
        public string PemeriksaanWaktu
        {
            get { return pemeriksaan_waktu; }
            set { pemeriksaan_waktu = value; }
        }

        private string pemeriksaan_remarks;
        public string PemeriksaanRemarks
        {
            get { return pemeriksaan_remarks; }
            set { pemeriksaan_remarks = value; }
        }
    }
}
