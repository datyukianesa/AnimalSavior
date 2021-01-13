using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace AnimalSavior.View
{
    /// <summary>
    /// Interaction logic for kuisionerNew.xaml
    /// </summary>
    public partial class kuisionerView : Page, INotifyPropertyChanged
    {
        private ObservableCollection<selfTreatmentModel> _listGejala;
        public ObservableCollection<selfTreatmentModel> listGejala
        {
            get { return _listGejala; }
            set
            {
                if (_listGejala == value)
                {
                    return;
                }
                _listGejala = value;
                OnPropertyChanged();
            }
        }

        public kuisionerView()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listGejala = new ObservableCollection<selfTreatmentModel>()
            {
                new selfTreatmentModel()
                {
                    Gejala = "Keracunan",
                    Description = "Kamu bisa melihat instruksi pada label kemasan produk. Jika label memerintahkanmu untuk cuci tangan dengan sabun dan air, kamu bisa membilas kulit hewan peliharaanmu dengan sabun dan air juga."
                },
                new selfTreatmentModel()
                {
                    Gejala = "Rabies",
                    Description = "Menginfeksi sistem saraf pusat hewan berdarah panas seperti anjing, kucing, kelelawar, dan lainnya. Virus rabies dikeluarkan bersama air liur hewan yang terinfeksi dan ditularkan melalui gigitan atau jilatan."
                }
            };

            comboBox.Items.Add(listGejala);
        }
    }
}
