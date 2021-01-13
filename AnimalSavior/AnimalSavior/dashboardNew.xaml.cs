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
            cusMainContent.Source = new Uri("View/userProfileView.xaml", UriKind.Relative);
        }

        private void btnHomepage_Click(object sender, RoutedEventArgs e)
        {
            //cusMainContent.Source = new Uri("View/loginView.xaml", UriKind.Relative);
        }
    }
}
