using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSavior.Model
{
    public class komenModel
    {
        private string id_komen;
        public string IdKomen
        {
            get { return id_komen; }
            set { id_komen = value; }
        }

        private string komen_isi;
        public string KomenIsi
        {
            get { return komen_isi; }
            set { komen_isi = value; }
        }

        private string komen_timestamp;
        public string KomenTimestamp
        {
            get { return komen_timestamp; }
            set { komen_timestamp = value; }
        }
    }
}
