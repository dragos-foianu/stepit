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

namespace Magazin
{
    /// <summary>
    /// Interaction logic for ProduseWindow.xaml
    /// </summary>
    public partial class ProduseWindow : Window
    {
        public ProduseWindow()
        {
            InitializeComponent();
            DataContext = this;

            DBModel db = new DBModel();
            var all = (from p in db.Produses select p).ToList();
            dataGrid.ItemsSource = new ObservableCollection<Produse>(all);
        }

        private void add(object sender, RoutedEventArgs e)
        {
            DBModel db = new DBModel();

            Produse produs = new Produse();
            produs.Nume = numeInput.Text;
            produs.Pret = int.Parse(pretInput.Text);
            produs.Stoc = int.Parse(stocInput.Text);

            db.Produses.Add(produs);
            db.SaveChanges();

            var all = (from p in db.Produses select p).ToList();
            dataGrid.ItemsSource = new ObservableCollection<Produse>(all);
        }

        private void remove(object sender, RoutedEventArgs e)
        {
            DBModel db = new DBModel();

            string nume = numeInput.Text;
            int pret = int.Parse(pretInput.Text);
            int stoc = int.Parse(stocInput.Text);

            var produse = from p in db.Produses
                          where p.Nume == nume || p.Pret == pret || p.Stoc == stoc
                          select p;

            foreach (var p in produse) db.Produses.Remove(p);
            db.SaveChanges();

            var all = (from p in db.Produses select p).ToList();
            dataGrid.ItemsSource = new ObservableCollection<Produse>(all);
        }
    }
}
