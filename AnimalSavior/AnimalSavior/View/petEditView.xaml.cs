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
    /// Interaction logic for petEditView.xaml
    /// </summary>
    public partial class petEditView : Page
    {
        private connection conn = null;
        private petDAO petDAO = null;

        private int result = 0;
        public petEditView()
        {
            InitializeComponent();

            conn = connection.GetInstance();
            petDAO = new petDAO(conn.GetConnection());

            loadData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("View/petListView.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void loadData()
        {
            petModel pet = new petModel();
            pet.IdPet = ConfigurationManager.AppSettings["petid"];
            result = petDAO.getData(pet);

            if(result == 1)
            {
                tb_nama.Text = pet.Petnama;
                cb_jenis.SelectedItem = pet.PetJenis;
                rtb_info.Document.Blocks.Add(new Paragraph(new Run(pet.PetInfo)));
            }
        }

        private void saveData()
        {
            petModel pet = new petModel();

            TextRange text = new TextRange(
                    rtb_info.Document.ContentStart,
                    rtb_info.Document.ContentEnd
                );

            pet.IdPet = ConfigurationManager.AppSettings["petid"];
            pet.Petnama = tb_nama.Text;
            pet.PetJenis = cb_jenis.Text;
            pet.PetInfo = text.Text;
            result = petDAO.update(pet);

            if (result > 0)
            {
                MessageBox.Show("Berhasil menyimpan data baru!");
                clear();
            }
            else
            {
                MessageBox.Show("Gagal menyimpan data!");
                clear();
            }
        }

        private void clear()
        {
            tb_nama.Text = "";
            cb_jenis.SelectedItem = default;
            rtb_info.Document.Blocks.Clear();
        }

        private void bt_tambah_Copy_Click(object sender, RoutedEventArgs e)
        {
            saveData();
        }
    }
}
