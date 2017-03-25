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

namespace WpfApplication1
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

        private void angajatiB(object sender, RoutedEventArgs e)
        {
            angajati p = new angajati();
            p.Show();
        }

        private void vanzariB(object sender, RoutedEventArgs e)
        {
            vanzari p = new vanzari();
            p.Show();
        }

        private void produseB(object sender, RoutedEventArgs e)
        {
            produse p = new produse();
            p.Show();
        }

        private void clientiB(object sender, RoutedEventArgs e)
        {
            clienti p = new clienti();
            p.Show();
        }
    }
}
