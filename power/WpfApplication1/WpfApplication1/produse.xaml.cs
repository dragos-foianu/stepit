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
    /// Interaction logic for produse.xaml
    /// </summary>
    public partial class produse : Window
    {
        public produse()
        {
            DBmodel db = new DBmodel();

            InitializeComponent();
            var lista = (from x in db.Produses select x).ToList();
            hah.ItemsSource = new ObservableCollection<Produse>(lista);
        }

        private void removeB(object sender, RoutedEventArgs e)
        {
            DBmodel db = new DBmodel();

            var query = from s in db.Produses
                        where s.Nume == nume.Text
                        select s;

            foreach (var x in query)
            {
                db.Produses.Remove(x);
            }
            db.SaveChanges();

            var lista = (from x in db.Produses select x).ToList();
            hah.ItemsSource = new ObservableCollection<Produse>(lista);
        }

        private void addB(object sender, RoutedEventArgs e)
        {
            DBmodel db = new DBmodel();

            Produse client = new Produse();
            client.Pret = int.Parse (pret.Text);
            client.Nume = (nume.Text);
            client.Stoc = int.Parse(stoc.Text);
            db.Produses.Add (client);
            db.SaveChanges();

            var lista = (from x in db.Produses select x).ToList();
            hah.ItemsSource = new ObservableCollection<Produse>(lista);
        }
    }
}
