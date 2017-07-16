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

using MagazinDuminica.Windows;

namespace MagazinDuminica
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

        private void openBuyWindow(object sender, RoutedEventArgs e)
        {
            BuyWindow buy = new BuyWindow();
            buy.Show();
        }

        private void openHistoryWindow(object sender, RoutedEventArgs e)
        {
            HistoryWindow history = new HistoryWindow();
            history.Show();
        }
    }
}
