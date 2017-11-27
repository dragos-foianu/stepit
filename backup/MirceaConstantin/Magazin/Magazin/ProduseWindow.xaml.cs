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
using System.Windows.Shapes;

namespace Magazin
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
        }

        private void addProdus_Click(object sender, RoutedEventArgs e)
        {
            string nume = nameProdus.Text;
            int pret = int.Parse(pretProdus.Text);
            int stoc = int.Parse(stocProdus.Text);

            DBModel db = new DBModel();

            var listaProduse = (from x in db.Produses select x).ToList();
            
        }

        private void removeProdus_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
