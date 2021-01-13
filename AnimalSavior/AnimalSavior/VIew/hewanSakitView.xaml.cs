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

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        /*private void filllv(petModel pet)
        {
            int id = lv_hewan.Items.Count + 1;

            ListViewItem item = new ListViewItem();

            item.DataContext = pet.Petnama;
            lv_hewan.Items.Add(item);
        }

        private void loadpetlist()
        {
            petModel petModel = new petModel();

            petModel.IdUser = ConfigurationManager.AppSettings["userid"];
            lv_hewan.Items.Clear();

            List<petModel> petlist = petDAO.GetAll(petModel);
            foreach(petModel pet in petlist)
            {
                filllv(pet);
            }
        }*/
    }
}
