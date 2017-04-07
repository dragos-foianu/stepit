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
using System.Windows.Shapes;

namespace Magazin
{
    /// <summary>
    /// Interaction logic for VanzariWindow.xaml
    /// </summary>
    public partial class VanzariWindow : Window
    {

        public VanzariWindow()
        {
            InitializeComponent();
            DataContext = this;

            DBModel db = new DBModel();

            var produse = from v in db.Vanzaris
                          join p in db.Produses on v.ProdusId equals p.Id
                          join c in db.Clientis on v.ClientId equals c.Id
                          join a in db.Angajatis on v.AngajatId equals a.Id
                select new
                { Produs = p.Nume, Client = c.Nume, Angajat = a.Nume };

            int x = 3;
        }

        private void add(object sender, RoutedEventArgs e)
        {

        }

        private void remove(object sender, RoutedEventArgs e)
        {

        }
    }
}
