using MagazinDuminica.Classes;
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

namespace MagazinDuminica.Windows
{
    /// <summary>
    /// Interaction logic for BuyWindow.xaml
    /// </summary>
    public partial class BuyWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Transaction> Transactions { get; set; }


        public BuyWindow()
        {
            InitializeComponent();
            DataContext = this;

            Products = ((MainWindow)Application.Current.MainWindow).Products;
            Transactions = ((MainWindow)Application.Current.MainWindow).Transactions;
        }

        private void buyProduct(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            Product p = (Product)b.DataContext;


            if (p.Stock > 0)
            {
                p.Stock--;

                Transaction t = new Transaction();
                t.Product = p;
                t.Price = p.Price;
                p.Price += p.Price * 0.01;

                Transactions.Add(t);
            }

            int index = Products.IndexOf(p);
            Products.Remove(p);
            Products.Insert(index, p);
        }
    }
}
