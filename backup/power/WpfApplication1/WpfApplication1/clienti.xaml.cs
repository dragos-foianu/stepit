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
    /// Interaction logic for clienti.xaml
    /// </summary>
    public partial class clienti : Window
    {
        public clienti()
        {
            DBmodel db = new DBmodel();

            InitializeComponent();
            var lista = (from x in db.Clientis select x).ToList();
            troll.ItemsSource = new ObservableCollection<Clienti>(lista);
        }

        private void removeB(object sender, RoutedEventArgs e)
        {
            DBmodel db = new DBmodel();

            var query = from s in db.Clientis
                        where s.Nume == nume.Text
                        select s;

            foreach (var x in query)
            {
                db.Clientis.Remove(x);
            }
            db.SaveChanges();

            var lista = (from x in db.Clientis select x).ToList();
            troll.ItemsSource = new ObservableCollection<Clienti>(lista);
        }

        private void addB(object sender, RoutedEventArgs e)
        {
            DBmodel db = new DBmodel();

            Clienti client = new Clienti();
            client.Nume = nume.Text;
            db.Clientis.Add(client);
            db.SaveChanges();

            var lista = (from x in db.Clientis select x).ToList();
            troll.ItemsSource = new ObservableCollection<Clienti>(lista);
        }
    }
}
