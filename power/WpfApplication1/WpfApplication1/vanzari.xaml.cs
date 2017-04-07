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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for vanzari.xaml
    /// </summary>
    public partial class vanzari : Window
    {
        public vanzari()
        {
            DBmodel db = new DBmodel();

            InitializeComponent();
            var lista = (from x in db.Vanzaris select x).ToList();
            ha.ItemsSource = new ObservableCollection<Vanzari>(lista);
        }

        private void removeB(object sender, RoutedEventArgs e)
        {
            DBmodel db = new DBmodel();

            var query = from s in db.Vanzaris
                        where s.ProdusID == produsID.Text
                        select s;

            foreach (var x in query)
            {
                db.Angajatis.Remove(x);
            }
            db.SaveChanges();

            var lista = (from x in db.Vanzaris select x).ToList();
            ha.ItemsSource = new ObservableCollection<Vanzari>(lista);
        }

        private void addB(object sender, RoutedEventArgs e)
        {
            DBmodel db = new DBmodel();

            Vanzari client = new Vanzari();
            client.ProdusID = int.Parse(produsID.Text);
            client.ClientID = int.Parse(clientID.Text);
            client.AngajatID = int.Parse(angajatID.Text);
            db.Vanzaris.Add(client);
            db.SaveChanges();

            var lista = (from x in db.Vanzaris select x).ToList();
            ha.ItemsSource = new ObservableCollection<Vanzari>(lista);
        }
    }
}
