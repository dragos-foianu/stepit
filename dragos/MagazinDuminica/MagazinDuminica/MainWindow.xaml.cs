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
using System.Collections.ObjectModel;
using MagazinDuminica.Classes;

namespace MagazinDuminica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Transaction> Transactions { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            CreateData();
        }

        private void CreateData()
        {
            Products = new ObservableCollection<Product>();
            Transactions = new ObservableCollection<Transaction>();

            Product p1 = new Product();
            p1.Id = 1;
            p1.Name = "Apa Plata";
            p1.Price = 3;
            p1.Stock = 100;

            Product p2 = new Product();
            p2.Id = 2;
            p2.Name = "Apa Minerala";
            p2.Price = 3;
            p2.Stock = 100;

            Product p3 = new Product();
            p3.Id = 3;
            p3.Name = "Suc";
            p3.Price = 4;
            p3.Stock = 100;

            Product p4 = new Product();
            p4.Id = 4;
            p4.Name = "Bere";
            p4.Price = 5;
            p4.Stock = 100;

            Products.Add(p1);
            Products.Add(p2);
            Products.Add(p3);
            Products.Add(p4);
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
