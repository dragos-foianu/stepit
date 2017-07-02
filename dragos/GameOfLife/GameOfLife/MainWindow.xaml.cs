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
            bool[][] state = new bool[SIZE][];
            for (int i = 0; i < SIZE; i++)
                state[i] = new bool[SIZE];

            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                {
                    if (Game[i][j].Fill == Brushes.Black)
                        state[i][j] = true;
                    else
                        state[i][j] = false;
                }

            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    update(i, j, state);
                }
            }
        }

        void update(int x, int y, bool[][] state)
        {
            int neighbors = 0;

            int r1 = x - 1;
            int r2 = x + 1;
            int c1 = y - 1;
            int c2 = y + 1;

            if (r1 < 0) r1 = 0;
            if (r1 >= SIZE) r1 = SIZE - 1;

            if (r2 < 0) r2 = 0;
            if (r2 >= SIZE) r2 = SIZE - 1;

            if (c1 < 0) c1 = 0;
            if (c1 >= SIZE) c1 = SIZE - 1;

            if (c2 < 0) c2 = 0;
            if (c2 >= SIZE) c2 = SIZE - 1;

            for (int i = r1; i <= r2; i++)
            {
                for (int j = c1; j <= c2; j++)
                {
                    if (i == x && j == y)
                        continue;
                    if (state[i][j] == true)
                        neighbors++;
                }
            }

            if (state[x][y] == true)
            {
                if (neighbors == 0 || neighbors == 1 || neighbors >= 4)
                    Game[x][y].Fill = Brushes.White;
            }
            else
            {
                if (neighbors == 3)
                    Game[x][y].Fill = Brushes.Black;
            }
        }
    }
}
