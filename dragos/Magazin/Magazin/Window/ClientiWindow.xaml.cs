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
    /// Interaction logic for ClientiWindow.xaml
    /// </summary>
    public partial class ClientiWindow : Window
    {
        public ClientiWindow()
        {
            InitializeComponent();
            DataContext = this;

            DBModel db = new DBModel();
            var all = (from c in db.Clientis select c).ToList();
            dataGrid.ItemsSource = new ObservableCollection<Clienti>(all);
        }

        private void add(object sender, RoutedEventArgs e)
        {
            DBModel db = new DBModel();

            Clienti client = new Clienti();
            client.Nume = numeInput.Text;

            db.Clientis.Add(client);
            db.SaveChanges();

            var all = (from c in db.Clientis select c).ToList();
            dataGrid.ItemsSource = new ObservableCollection<Clienti>(all);
        }

        private void remove(object sender, RoutedEventArgs e)
        {
            DBModel db = new DBModel();

            string nume = numeInput.Text;

            var clienti = from c in db.Clientis
                          where c.Nume == nume
                          select c;

            foreach (var c in clienti) db.Clientis.Remove(c);
            db.SaveChanges();

            var all = (from c in db.Clientis select c).ToList();
            dataGrid.ItemsSource = new ObservableCollection<Clienti>(all);
        }
    }
}
