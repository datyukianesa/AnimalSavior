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

namespace AnimalSavior
{
    /// <summary>
    /// Interaction logic for cariDokterView.xaml
    /// </summary>
    public partial class cariDokterView : Page
    {
        private connection conn = null;
        private userDAO userDAO = null;
        public cariDokterView()
        {
            InitializeComponent();

            conn = connection.GetInstance();
            userDAO = new userDAO(conn.GetConnection());

            filltolst();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void filltolst()
        {
            userModel user = new userModel();
            dataGrid.DataContext = userDAO.getDokter(user);
        }
    }
}
