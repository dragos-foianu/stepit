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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADO_DBApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

            Database1Entities db = new Database1Entities();

            var lista = (from x in db.Studentis select x).ToList();
            dataGrid.ItemsSource = new ObservableCollection<Studenti>(lista);
        }

        private void addStudent(object sender, RoutedEventArgs e)
        {
            string nume = numeBox.Text;
            int nota = int.Parse(notaBox.Text);

            Database1Entities db = new Database1Entities();

            Studenti s = new Studenti();
            s.Nume = nume;
            s.Nota = nota;

            db.Studentis.Add(s);
            db.SaveChanges();

            var lista = (from x in db.Studentis select x).ToList();
            dataGrid.ItemsSource = new ObservableCollection<Studenti>(lista);
        }

        private void removeStudent(object sender, RoutedEventArgs e)
        {
            string nume = numeBox.Text;
            int nota = int.Parse(notaBox.Text);

            Database1Entities db = new Database1Entities();

            var query = from s in db.Studentis
                        where s.Nota == nota || s.Nume == nume
                        select s;

            foreach (var x in query)
            {
                db.Studentis.Remove(x);
            }
            db.SaveChanges();

            var lista = (from x in db.Studentis select x).ToList();
            dataGrid.ItemsSource = new ObservableCollection<Studenti>(lista);
        }
    }
}
