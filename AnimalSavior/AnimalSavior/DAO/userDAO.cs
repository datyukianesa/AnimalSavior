using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalSavior.Model;
using MySql.Data.MySqlClient;

namespace AnimalSavior.DAO
{
    class userDAO
    {
        private MySqlConnection conn;
        private string str = string.Empty;

        public userDAO (MySqlConnection conn)
        {
            this.conn = conn;
        }


    }
}
