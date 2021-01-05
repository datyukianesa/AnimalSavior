using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSavior.Model
{
    public class userModel
    {
        private string id_user;
        public string IdUser
        {
            get { return id_user; }
            set { id_user = value; }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
