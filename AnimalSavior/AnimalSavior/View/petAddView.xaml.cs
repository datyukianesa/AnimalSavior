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
using AnimalSavior.Model;
using AnimalSavior.DAO;
using System.Configuration;

namespace AnimalSavior.View
{
    /// <summary>
    /// Interaction logic for petAddView.xaml
    /// </summary>
    public partial class petAddView : Page
    {
        private connection conn = null;
        private petDAO petDAO = null;

        private int result = 0;
        public petAddView()
        {
            InitializeComponent();

            conn = connection.GetInstance();
            petDAO = new petDAO(conn.GetConnection());

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("View/petListView.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void bt_tambah_Copy_Click(object sender, RoutedEventArgs e)
        {
            petModel pet = new petModel();

            TextRange text = new TextRange(
                    rtb_info.Document.ContentStart,
                    rtb_info.Document.ContentEnd
                );

            pet.Petnama = tb_nama.Text;
            pet.PetJenis = cb_jenis.Text;
            pet.PetInfo = text.Text;
            pet.IdUser = ConfigurationManager.AppSettings["userid"];

            result = petDAO.save(pet);

            if(result > 0)
            {
                MessageBox.Show("Berhasil menambahkan pet baru!");
                clear();
            }
            else
            {
                MessageBox.Show("Gagal menambahkan pet baru!");
                clear();
            }
        }

        private void clear()
        {
            tb_nama.Text = "";
            cb_jenis.SelectedItem = default;
            rtb_info.Document.Blocks.Clear();
        }
    }
}
