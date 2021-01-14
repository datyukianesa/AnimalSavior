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

        private int result = 0;
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
            /*DataSet ds = new DataSet();
            ds = petDAO.datamap(pet);
            dataGrid.DataContext = ds;*/

            pet.IdUser = ConfigurationManager.AppSettings["userid"];
            result = petDAO.getInfo(pet);

            if(result == 1)
            {
                dataGrid.ItemsSource = petDAO.getPet(pet);
            }
            else
            {
                MessageBox.Show("Gagal menampilkan data!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("View/userProfileView.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void bt_tambah_Copy_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("View/petAddView.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }


        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            petModel pet = dataGrid.SelectedItem as petModel;
            MessageBoxResult msresult = System.Windows.MessageBox.Show("Akan mengedit " + pet.Petnama, "Hapus data", System.Windows.MessageBoxButton.YesNo);

            if (msresult == MessageBoxResult.Yes)
            {
                ConfigurationManager.AppSettings["petid"] = pet.IdPet;
                Uri uri = new Uri("View/petEditView.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private void b_del_Click(object sender, RoutedEventArgs e)
        {
            petModel pet = dataGrid.SelectedItem as petModel;
            MessageBoxResult msresult = System.Windows.MessageBox.Show("Akan menghapus " + pet.Petnama, "Hapus data", System.Windows.MessageBoxButton.YesNo);

            if (msresult == MessageBoxResult.Yes)
            {
                
                result = petDAO.delete(pet);
                if(result > 0)
                {
                    MessageBox.Show("Berhasil menghapus data!");
                    filltolst();
                }
            }
        }
    }
}
