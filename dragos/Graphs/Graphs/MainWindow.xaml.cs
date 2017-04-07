using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Graphs
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

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
            node.Width = 20;
            node.Height = 20;
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
    }
}
