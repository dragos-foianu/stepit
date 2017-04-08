using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Graphs
{
    public class CityNode
    {
        public CityInfo Info { get; set; }
        public List<CityNode> Roads { get; set; }

        public CityNode(CityInfo info)
        {
            Info = info;
            Roads = new List<CityNode>();
        }
    }

    public class CityInfo {
        public int Id { get; set; }
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public Ellipse CanvasNode { get; set; }

        public CityInfo(int id, double x, double y, Ellipse e = null, string name = null)
        {
            Id = id;
            Name = name;
            X = x;
            Y = y;
            CanvasNode = e;
        }
    }


    public partial class MainWindow : Window
    {
        private const double NODE_WIDTH = 20;
        private const double NODE_HEIGHT = 20;
        private const double CANVAS_DISP_X = 120;
        private const double CANVAS_DISP_Y = 20;

        private int GLOBAL_ID;

        private bool drawingConnection;
        private Line connectionLine;

        public ObservableCollection<CityNode> World { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            drawingConnection = false;
            GLOBAL_ID = 0;

            worldCanvas.AddHandler(MouseLeftButtonUpEvent, new MouseButtonEventHandler(leftMouseUp), true);
            worldCanvas.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(leftMouseDown), true);
            worldCanvas.AddHandler(MouseRightButtonUpEvent, new MouseButtonEventHandler(rightMouseUp), true);
            worldCanvas.AddHandler(MouseMoveEvent, new MouseEventHandler(mouseMove), true);

            World = new ObservableCollection<CityNode>();
        }

        private void leftMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!drawingConnection)
            {
                /* find clicked position */
                Point p = e.GetPosition(this);

                /* define a new node */
                Ellipse ellipse = new Ellipse();
                ellipse.Width = NODE_WIDTH;
                ellipse.Height = NODE_HEIGHT;
                ellipse.Stroke = Brushes.Black;
                ellipse.Fill = Brushes.CadetBlue;

                /* set position of the new node in canvas */
                double Xpos = p.X - CANVAS_DISP_X - NODE_WIDTH / 2.0;
                double Ypos = p.Y - CANVAS_DISP_Y - NODE_HEIGHT / 2.0;
                Canvas.SetLeft(ellipse, Xpos);
                Canvas.SetTop(ellipse, Ypos);

                /* add node to canvas */
                worldCanvas.Children.Add(ellipse);

                CityInfo ci = new CityInfo(GLOBAL_ID++, Xpos, Ypos, ellipse);
                CityNode n = new CityNode(ci);
                World.Add(n);
            } else
            {
                if (e.OriginalSource is Ellipse)
                {
                    Ellipse node = e.OriginalSource as Ellipse;

                    connectionLine.X2 = Canvas.GetLeft(node) + NODE_WIDTH / 2.0;
                    connectionLine.Y2 = Canvas.GetTop(node) + NODE_HEIGHT / 2.0;
                    
                    drawingConnection = false;
                } else
                {
                    worldCanvas.Children.Remove(connectionLine);
                    drawingConnection = false;
                }
            }
        }

        private void leftMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Ellipse)
            {
                drawingConnection = true;

                Ellipse node = e.OriginalSource as Ellipse;

                connectionLine = new Line();
                connectionLine.IsHitTestVisible = false;

                connectionLine.X1 = Canvas.GetLeft(node) + NODE_WIDTH / 2.0;
                connectionLine.Y1 = Canvas.GetTop(node) + NODE_HEIGHT / 2.0;
                connectionLine.Stroke = Brushes.CadetBlue;
                connectionLine.StrokeThickness = 3;

                connectionLine.X2 = Mouse.GetPosition(worldCanvas).X;
                connectionLine.Y2 = Mouse.GetPosition(worldCanvas).Y;

                worldCanvas.Children.Add(connectionLine);
            }
        }

        private void rightMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Ellipse)
            {
                Ellipse node = e.OriginalSource as Ellipse;
                worldCanvas.Children.Remove(node);

                foreach (CityNode c in World)
                {
                    if (c.Info.CanvasNode == node)
                    {
                        World.Remove(c);
                        break;
                    }
                }
            }
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (drawingConnection && connectionLine != null) {
                connectionLine.X2 = Mouse.GetPosition(worldCanvas).X;
                connectionLine.Y2 = Mouse.GetPosition(worldCanvas).Y;
            }
        }
    }
}
