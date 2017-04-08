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

namespace MouseEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Events { get; set; }

        private Ellipse selected;
        private bool movingElement;

        public MainWindow()
        {
            InitializeComponent();
            Events = new ObservableCollection<string>();
            DataContext = this;

            Ellipse e = new Ellipse();
            e.Stroke = Brushes.Red;
            e.StrokeThickness = 5;
            e.Fill = Brushes.Black;
            e.Width = 50;
            e.Height = 50;

            Canvas.SetLeft(e, 100);
            Canvas.SetTop(e, 100);
            xamlCanvas.Children.Add(e);

            movingElement = false;
        }

        private void mouseRightDown(object sender, MouseButtonEventArgs e)
        {
            Point p = Mouse.GetPosition(xamlCanvas);

            if (Events.Count > 20) { Events.RemoveAt(0); }
            Events.Add("MouseRightDown - " + (long)p.X + "," + (long)p.Y);
        }

        private void mouseRightUp(object sender, MouseButtonEventArgs e)
        {
            Point p = Mouse.GetPosition(xamlCanvas);

            if (e.OriginalSource is Ellipse)
            {
                Ellipse clickedOn = e.OriginalSource as Ellipse;
                xamlCanvas.Children.Remove(clickedOn);
            }

                if (Events.Count > 20) { Events.RemoveAt(0); }
            Events.Add("MouseRightUp - " + (long)p.X + "," + (long)p.Y);
        }

        private void mouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            Point p = Mouse.GetPosition(xamlCanvas);

            if (e.OriginalSource is Ellipse)
            {
                selected = e.OriginalSource as Ellipse;
                movingElement = true;
            }
            
            if (Events.Count > 20) { Events.RemoveAt(0); }
            Events.Add("MouseLeftDown - " + (long)p.X + "," + (long)p.Y);
        }

        private void mouseLeftUp(object sender, MouseButtonEventArgs e)
        {
            Point p = Mouse.GetPosition(xamlCanvas);

            if (movingElement)
            {
                movingElement = false;
            } else
            {
                Ellipse e2 = new Ellipse();
                e2.Stroke = Brushes.Red;
                e2.StrokeThickness = 5;
                e2.Fill = Brushes.Black;
                e2.Width = 50;
                e2.Height = 50;

                Canvas.SetLeft(e2, p.X - 25);
                Canvas.SetTop(e2, p.Y - 25);
                xamlCanvas.Children.Add(e2);
            }

            if (Events.Count > 20) { Events.RemoveAt(0); }
            Events.Add("MouseLeftUp - " + (long)p.X + "," + (long)p.Y);
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            Point p = Mouse.GetPosition(xamlCanvas);

            if (movingElement)
            {
                double newX = p.X - selected.Width / 2.0;
                double newY = p.Y - selected.Height / 2.0;

                if (newX < 0) newX = 0;
                if (newY < 0) newY = 0;

                Canvas.SetLeft(selected, newX);
                Canvas.SetTop(selected, newY);
            }

            if (Events.Count > 20) { Events.RemoveAt(0); }
            Events.Add("MouseMove - " + (long)p.X + "," + (long)p.Y);
        }
    }
}
