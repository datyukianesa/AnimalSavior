using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSavior.Model
{
    class postModel
    {
        private string id_post;
        public string IdPost
        {
            get { return id_post; }
            set { id_post = value; }
        }

        private string post_judul;
        public string PostJudul
        {
            get { return post_judul; }
            set { post_judul = value; }
        }

        private string post_isi;
        public string PostIsi
        {
            get { return post_isi; }
            set { post_isi = value; }
        }

        private string post_waktu;
        public string PostWaktu
        {
            get { return post_waktu; }
            set { post_waktu = value; }
        }
    }
}
