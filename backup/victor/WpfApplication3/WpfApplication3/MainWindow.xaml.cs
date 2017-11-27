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

namespace WpfApplication3
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

        private void Produse_Click(object sender, RoutedEventArgs e)
        {
            Window ProduseWindow = new ProduseWindow();
            ProduseWindow.Show();

        }

        private void Angajati_Click(object sender, RoutedEventArgs e)
        {
            Window Angajati = new Angajati();
            Angajati.Show();
        }

        private void Clienti_Click(object sender, RoutedEventArgs e)
        {
            Window Clienti = new Clienti();
            Clienti.Show();
        }

        private void Vanzari_Click(object sender, RoutedEventArgs e)
        {
            Window Vanzari = new VanzariWindow();
            Vanzari.Show();
        }
    }
}
