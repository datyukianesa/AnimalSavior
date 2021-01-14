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
using System.Configuration;

namespace AnimalSavior
{
    /// <summary>
    /// Interaction logic for dashboardNew.xaml
    /// </summary>
    public partial class dashboardNew : Window
    {
        public dashboardNew()
        {
            InitializeComponent();
            cusMainContent.Source = new Uri("View/loginView.xaml", UriKind.Relative);
        }

        private void btnHomepage_Click(object sender, RoutedEventArgs e)
        {
            //cusMainContent.Source = new Uri("View/loginView.xaml", UriKind.Relative);
        }

        private void btn_userProf_Click(object sender, RoutedEventArgs e)
        {
            cusMainContent.Source = new Uri("View/userProfileView.xaml", UriKind.Relative);
        }

        private void btn_selfTreat_Click(object sender, RoutedEventArgs e)
        {
            cusMainContent.Source = new Uri("View/selfTreatmentView.xaml", UriKind.Relative);
        }

        public void check()
        {
            if (ConfigurationManager.AppSettings["userid"] != "0")
            {
                btn_selfTreat.IsEnabled = true;
                btn_userProf.IsEnabled = true;
                btnHomepage.IsEnabled = false;
            }
            else
            {
                btn_selfTreat.IsEnabled = false;
                btn_userProf.IsEnabled = false;
                btnHomepage.IsEnabled = true;
            }
        }
    }
}
