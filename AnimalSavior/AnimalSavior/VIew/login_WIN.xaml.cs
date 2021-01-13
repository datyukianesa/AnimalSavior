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
using System.Windows.Shapes;
using System.Windows.Navigation;
using AnimalSavior.Model;
using AnimalSavior.DAO;

namespace AnimalSavior.View
{
    /// <summary>
    /// Interaction logic for login_WIN.xaml
    /// </summary>
    public partial class login_WIN : Window
    {
        private connection conn = null;
        private userDAO userDAO = null;

        private int result = 0;

        public login_WIN()
        {
            InitializeComponent();

            conn = connection.GetInstance();

            userDAO = new userDAO(conn.GetConnection());
        }

        //private void log_button_Click(object sender, RoutedEventArgs e)
        //{
        //    userModel user = new userModel();

        //    user.Username = log_username.Text;
        //    user.Password = log_password.Password;

        //    result = userDAO.login(user);
        //    if (result == 1)
        //    {
        //        MessageBox.Show("Selamat datang " + user.Username);

        //        Uri uri = new Uri("View/userprofileview.xaml", UriKind.Relative);
        //        this.NavigationService.Navigate(uri);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Pengguna tidak ditemukan!");
        //        clear();
        //        log_username.Focus();
        //    }
        //}

        //private void clear()
        //{
        //    log_username.Text = "";
        //    log_password.Password = "";
        //}
    }
}
