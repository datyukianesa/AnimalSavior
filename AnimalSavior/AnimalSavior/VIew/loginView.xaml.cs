﻿using System;
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
using AnimalSavior.Model;
using AnimalSavior.DAO;


namespace AnimalSavior.View
{
    /// <summary>
    /// </summary>
    public partial class loginView : Page
    {
        private connection conn = null;
        private userDAO userDAO = null;

        private int result = 0;

        public loginView()
        {
            InitializeComponent();

            conn = connection.GetInstance();

            userDAO = new userDAO(conn.GetConnection());
            log_username.Focus();
        }

        private void reg_button_Click(object sender, RoutedEventArgs e)
        {
            userModel user = new userModel();

            user.Username = log_username.Text;
            user.Password = log_password.Password;

            result = userDAO.login(user);
            if(result == 1)
            {
                MessageBox.Show("Selamat datang "+ user.Username);

                Uri uri = new Uri("View/userprofileview.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
            else
            {
                MessageBox.Show("Pengguna tidak ditemukan!") ;
                clear();
                log_username.Focus();
            }
        }

        private void clear()
        {
            log_username.Text = "";
            log_password.Password = "";
        }

        private void log_regist_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("View/registerView.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
