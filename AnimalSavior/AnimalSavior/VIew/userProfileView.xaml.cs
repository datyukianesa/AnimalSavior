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
using System.Configuration;

namespace AnimalSavior.View
{
    /// <summary>
    /// Interaction logic for userProfileNew.xaml
    /// </summary>
    public partial class userProfileView : Page
    {
        private connection conn = null;
        private userDAO userDAO = null;

        private int result = 0;
        public userProfileView()
        {
            InitializeComponent();
            conn = connection.GetInstance();

            userDAO = new userDAO(conn.GetConnection());
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("View/petlistview.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void getInfo()
        {
            userModel user = new userModel();

            user.IdUser = ConfigurationManager.AppSettings["userid"];
            
        }
    }
}
