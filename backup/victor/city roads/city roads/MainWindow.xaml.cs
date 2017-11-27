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

namespace city_roads
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

            Database1Entities db1 = new Database1Entities();
            var listaOras = (from x in db1.Oras1 select x).ToList();
            OrasGrid.ItemsSource = new ObservableCollection<Oras>(listaOras);


            Database1Entities db2 = new Database1Entities();
            var listaDrum = (from x in db2.Drums select x).ToList();
            DrumGrid.ItemsSource = new ObservableCollection<Drum>(listaDrum);

            world.AddHandler(MouseLeftButtonUpEvent, new MouseButtonEventHandler(leftMouseUp), true);
            world.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(leftMouseDown), true);
            world.AddHandler(MouseRightButtonUpEvent, new MouseButtonEventHandler(rightMouseUp), true);
        }

        private void leftMouseUp(object sender, MouseButtonEventArgs e)
        {
            /* find clicked position */
            Point p = e.GetPosition(this);

            /* define a new node */
            Ellipse node = new Ellipse();
            node.Width = 10;
            node.Height = 10;
            node.Stroke = Brushes.Black;
            node.Fill = Brushes.Black;

            /* set position of the new node in canvas */
            Canvas.SetLeft(node, p.X - node.Width * 1.5);
            Canvas.SetTop(node, p.Y - node.Height * 1.5);

            /* add node to canvas */
            world.Children.Add(node);

        }

        private void leftMouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void rightMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Ellipse)
            {
                Ellipse node = e.OriginalSource as Ellipse;
                world.Children.Remove(node);
            }
        }

        private void addOras(object sender, RoutedEventArgs e)
        {
            string nume = numeBox.Text;
            int Orasx = int.Parse(xBox.Text);
            int Orasy= int.Parse(yBox.Text);

            Database1Entities db1 = new Database1Entities();

            Oras o = new Oras();
            o.Nume = nume;
            o.x = Orasx;
            o.y = Orasy;

            db1.Oras1.Add(o);
            db1.SaveChanges();

            var listaOras = (from x in db1.Oras1 select x).ToList();
            OrasGrid.ItemsSource = new ObservableCollection<Oras>(listaOras);

        }

        private void removeOras(object sender, RoutedEventArgs e)
        {
            string nume = numeBox.Text;
            int Orasx = int.Parse(xBox.Text);
            int Orasy = int.Parse(yBox.Text);

            Database1Entities db1 = new Database1Entities();

            var query = from s in db1.Oras1
                        where s.Nume == nume || s.x == Orasx || s.y == Orasy
                        select s;

            foreach (var x in query)
            {
                db1.Oras1.Remove(x);
            }
            db1.SaveChanges();

            var listaOras = (from x in db1.Oras1 select x).ToList();
            OrasGrid.ItemsSource = new ObservableCollection<Oras>(listaOras);
        }

        private void addDrum(object sender, RoutedEventArgs e)
        {
            
            int From = int.Parse(FromBox.Text);
            int To = int.Parse(ToBox.Text);

            Database1Entities db2 = new Database1Entities();

            Drum d = new Drum();
            d.From = From;
            d.to = To;

            db2.Drums.Add(d);
            db2.SaveChanges();

            var listaDrum = (from x in db2.Drums select x).ToList();
            DrumGrid.ItemsSource = new ObservableCollection<Drum>(listaDrum);
        }

        private void removeDrum(object sender, RoutedEventArgs e)
        {
            int From = int.Parse(FromBox.Text);
            int To = int.Parse(ToBox.Text);

            Database1Entities db2 = new Database1Entities();

            var query = from s in db2.Drums
                        where s.From == From || s.to == To
                        select s;

            foreach (var x in query)
            {
                db2.Drums.Remove(x);
            }
            db2.SaveChanges();

            var listaDrum = (from x in db2.Drums select x).ToList();
            DrumGrid.ItemsSource = new ObservableCollection<Drum>(listaDrum);
        }
    }
}
