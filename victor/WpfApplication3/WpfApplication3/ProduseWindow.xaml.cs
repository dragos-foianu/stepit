using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for ProduseWindow.xaml
    /// </summary>
    public partial class ProduseWindow : Window
    {
        public ProduseWindow()
        {
            DataContext = this;
            InitializeComponent();

            WpfApplication3.

            DBModel db = new DBModel();

            var lista = (from x in db.Produses select x).ToList();
            ProduseGrid.ItemsSource = new ObservableCollection<Produse>(lista);
        }

        private void addProdus(object sender, RoutedEventArgs e)
        {

        }

        private void removeProdus(object sender, RoutedEventArgs e)
        {

        }
    }
}
