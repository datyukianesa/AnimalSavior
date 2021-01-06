using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AnimalSavior.DAO;
using AnimalSavior.Model;

namespace AnimalSavior.View
{
    /// <summary>
    /// Interaction logic for editProfileView.xaml
    /// </summary>
    public partial class editProfileView : Page
    {
        private connection conn = null;
        private userDAO userDAO = null;

        private int result = 0;
        public editProfileView()
        {
            InitializeComponent();

            conn = connection.GetInstance();
            userDAO = new userDAO(conn.GetConnection());
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            userModel user = new userModel();

            user.IdUser = "1";
            user.Password = passfield.Password;

            result = userDAO.update(user);
            if (result > 0)
            {
                MessageBox.Show("Ubah password berhasil!");
            }
            else
            {
                MessageBox.Show("Ubah password gagal!");
            }
        }
    }
}
