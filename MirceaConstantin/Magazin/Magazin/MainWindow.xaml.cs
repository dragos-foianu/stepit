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

namespace Magazin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

            DBModel db = new DBModel();
        }

        private void clickProdus(object sender, RoutedEventArgs e)
        {
            ProduseWindow pWindow = new ProduseWindow();
            pWindow.Show();
        }

        private void clickAngajati(object sender, RoutedEventArgs e)
        {
            AngajatiWindow aWindow = new AngajatiWindow();
            aWindow.Show();
        }

        private void clickClienti(object sender, RoutedEventArgs e)
        {
            ClientiWindow cWindow = new ClientiWindow();
            cWindow.Show();
        }

        private void clickVanzari(object sender, RoutedEventArgs e)
        {
            VanzariWindow vWindow = new VanzariWindow();
            vWindow.Show();
        }
    }
}
