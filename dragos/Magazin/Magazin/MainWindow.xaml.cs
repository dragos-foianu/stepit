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
            InitializeComponent();
        }

        private void openProduse(object sender, RoutedEventArgs e)
        {
            ProduseWindow produseWindow = new ProduseWindow();
            produseWindow.Show();
        }

        private void openAngajati(object sender, RoutedEventArgs e)
        {
            AngajatiWindow produseWindow = new AngajatiWindow();
            produseWindow.Show();
        }

        private void openClienti(object sender, RoutedEventArgs e)
        {
            ClientiWindow produseWindow = new ClientiWindow();
            produseWindow.Show();
        }

        private void openVanzari(object sender, RoutedEventArgs e)
        {
            VanzariWindow produseWindow = new VanzariWindow();
            produseWindow.Show();
        }
    }
}
