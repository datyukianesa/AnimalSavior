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

namespace AnimalSavior.View
{
    /// <summary>
    /// Interaction logic for petListView.xaml
    /// </summary>
    public partial class petListView : Page
    {
        private connection conn = null;
        private petDAO petDAO = null;

        private int result = 0;
        public petListView()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void filltolst(petModel pet)
        {
            
        }
    }
}
