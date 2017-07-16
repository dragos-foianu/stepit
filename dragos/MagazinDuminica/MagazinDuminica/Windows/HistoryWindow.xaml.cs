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
    /// Interaction logic for HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Transaction> Transactions { get; set; }


        public HistoryWindow()
        {
            InitializeComponent();

            Products = ((MainWindow)Application.Current.MainWindow).Products;
            Transactions = ((MainWindow)Application.Current.MainWindow).Transactions;
        }
    }
}
