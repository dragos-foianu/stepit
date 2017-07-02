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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Rectangle[][] Game { get; set; }
        public DispatcherTimer timer;

        public const int SQUARE_SIZE = 15;
        public const int CANVAS_SIZE = 600;
        public const int SIZE = CANVAS_SIZE / SQUARE_SIZE;
        public int SPEED = 500;


        public MainWindow()
        {
            InitializeComponent();

            Game = new Rectangle[SIZE][];
            for (int i = 0; i < SIZE; i++)
                Game[i] = new Rectangle[SIZE];

            canvas.AddHandler(MouseLeftButtonUpEvent, new MouseButtonEventHandler(leftMouseUp), true);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(SPEED);
            timer.Tick += tick;

            init();
        }

        private void init()
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    Rectangle r = new Rectangle();

                    r.Width = SQUARE_SIZE - 2;
                    r.Height = SQUARE_SIZE - 2;
                    r.Fill = Brushes.White;

                    Canvas.SetLeft(r, SQUARE_SIZE * j + 1);
                    Canvas.SetTop(r, SQUARE_SIZE * i + 1);

                    Game[i][j] = r;
                    canvas.Children.Add(r);
                }
            }
        }

        private void leftMouseUp(object sender, MouseButtonEventArgs e)
        {
            double x = Mouse.GetPosition(canvas).X;
            double y = Mouse.GetPosition(canvas).Y;

            int i = (int) y / SQUARE_SIZE;
            int j = (int) x / SQUARE_SIZE;

            Rectangle r = Game[i][j];
            r.Fill = Brushes.Black;
        }

        private void start(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void stop(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void faster(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                SPEED -= 25;
                if (SPEED < 25) SPEED = 25;
                timer.Interval = TimeSpan.FromMilliseconds(SPEED);
                timer.Start();
            }
            else
            {
                SPEED -= 25;
                timer.Interval = TimeSpan.FromMilliseconds(SPEED);
            }
        }

        private void slower(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                SPEED += 25;
                timer.Interval = TimeSpan.FromMilliseconds(SPEED);
                timer.Start();
            }
            else
            {
                SPEED += 25;
                timer.Interval = TimeSpan.FromMilliseconds(SPEED);
            }
        }

        void tick(object sender, EventArgs e)
        {

        }
    }
}
