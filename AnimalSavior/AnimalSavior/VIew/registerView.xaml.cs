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
    /// Interaction logic for registerNew.xaml
    /// </summary>
    public partial class registerView : Page
    {
        private connection conn = null;
        private userDAO userDAO = null;

        private int result = 0;

        public registerView()
        {
            InitializeComponent();

            conn = connection.GetInstance();
            userDAO = new userDAO(conn.GetConnection());
        }
        private void log_button_Click(object sender, RoutedEventArgs e)
        {
            userModel user = new userModel();

            user.Username = log_username.Text;
            user.Password = log_password.Text;

            result = userDAO.save(user);
            if(result > 0)
            {
                MessageBox.Show("Pendaftaran berhasil!");
                Uri uri = new Uri("View/loginView.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
            else
            {
                MessageBox.Show("Pendaftaran gagal!");
            }
        }
        private void clear()
        {
            log_username.Text = "";
            log_password.Text = "";
        }
    }
}
