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
    /// Interaction logic for AngajatiWindow.xaml
    /// </summary>
    public partial class AngajatiWindow : Window
    {
        public AngajatiWindow()
        {
            InitializeComponent();
            DataContext = this;

            DBModel db = new DBModel();
            var all = (from c in db.Angajatis select c).ToList();
            dataGrid.ItemsSource = new ObservableCollection<Angajati>(all);
        }

        private void add(object sender, RoutedEventArgs e)
        {
            DBModel db = new DBModel();

            Angajati angajat = new Angajati();
            angajat.Nume = numeInput.Text;
            angajat.Salariu = int.Parse(salariuInput.Text);

            db.Angajatis.Add(angajat);
            db.SaveChanges();

            var all = (from c in db.Angajatis select c).ToList();
            dataGrid.ItemsSource = new ObservableCollection<Angajati>(all);
        }

        private void remove(object sender, RoutedEventArgs e)
        {
            DBModel db = new DBModel();

            string nume = numeInput.Text;
            int salariu = int.Parse(salariuInput.Text);

            var angajati = from a in db.Angajatis
                           where a.Nume == nume || a.Salariu == salariu
                           select a;

            foreach (var a in angajati) db.Angajatis.Remove(a);
            db.SaveChanges();

            var all = (from c in db.Angajatis select c).ToList();
            dataGrid.ItemsSource = new ObservableCollection<Angajati>(all);
        }
    }
}
