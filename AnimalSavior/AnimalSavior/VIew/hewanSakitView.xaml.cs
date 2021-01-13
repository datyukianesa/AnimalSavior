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
using System.Collections.ObjectModel;

namespace AnimalSavior
{
    /// <summary>
    /// Interaction logic for cariDokterView.xaml
    /// </summary>
    public partial class hewanSakitView : Page
    {
        private connection conn = null;
        private petDAO petDAO = null;
        public hewanSakitView()
        {
            InitializeComponent();

            conn = connection.GetInstance();
            petDAO = new petDAO(conn.GetConnection());

            fillcb();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void fillcb()
        {
            petModel pet = new petModel();

            pet.IdUser = ConfigurationManager.AppSettings["userid"];
            cb_hewan.DataContext = petDAO.datamap(pet);

        }

        private void btn_cariDokter_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("View/cariDokterView.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void btn_pengobatan_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("View/selfTreatmentView.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
