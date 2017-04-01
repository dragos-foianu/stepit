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
    /// Interaction logic for angajati.xaml
    /// </summary>
    public partial class angajati : Window
    {
        public angajati()
        {
            DBmodel db = new DBmodel();

            InitializeComponent();
            var lista = (from x in db.Angajatis select x).ToList();
            haha.ItemsSource = new ObservableCollection<Angajati>(lista);
        }

        private void removeB(object sender, RoutedEventArgs e)
        {
            DBmodel db = new DBmodel();

            var query = from s in db.Angajatis
                        where s.Nume == nume.Text
                        select s;

            foreach (var x in query)
            {
                db.Angajatis.Remove(x);
            }
            db.SaveChanges();

            var lista = (from x in db.Angajatis select x).ToList();
            haha.ItemsSource = new ObservableCollection<Angajati>(lista);
        }

        private void addB(object sender, RoutedEventArgs e)
        {
            DBmodel db = new DBmodel();

            Angajati client = new Angajati();
            client.Nume = nume.Text;
            db.Angajatis.Add(client);
            db.SaveChanges();

            var lista = (from x in db.Angajatis select x).ToList();
            haha.ItemsSource = new ObservableCollection<Angajati>(lista);
        }
    }
}
