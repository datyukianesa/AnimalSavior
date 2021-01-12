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
using AnimalSavior.DAO;
using AnimalSavior.Model;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace AnimalSavior.View
{
    /// <summary>
    /// Interaction logic for petListView.xaml
    /// </summary>
    public partial class petListView : Page
    {
        private connection conn = null;
        private petDAO petDAO = null;

        public petListView()
        {
            InitializeComponent();

            conn = connection.GetInstance();
            petDAO = new petDAO(conn.GetConnection());

            filltolst();
        }

        public void filltolst()
        {
            petModel pet = new petModel();

            pet.IdUser = ConfigurationManager.AppSettings["userid"];

            dataGrid.DataContext = petDAO.datamap(pet);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("View/userProfileView.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void bt_tambah_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt_edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt_del_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
