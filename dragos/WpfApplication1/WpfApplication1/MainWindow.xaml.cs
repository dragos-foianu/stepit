using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int vx;
        int vy;
        int speed;
        bool gameOver;

        List<Shape> snake;
        Ellipse food;

        public MainWindow()
        {
            InitializeComponent();

            snake = new List<Shape>();

            speed = 25;
            vx = speed;
            vy = 0;
            gameOver = false;

            food = new Ellipse();
            food.Width = 25;
            food.Height = 25;
            food.Fill = Brushes.Green;

            Ellipse head = new Ellipse();
            head.Width = 25;
            head.Height = 25;
            head.Fill = Brushes.Blue;

            Rectangle middle = new Rectangle();
            middle.Width = 25;
            middle.Height = 25;
            middle.Fill = Brushes.Blue;

            Rectangle tail = new Rectangle();
            tail.Width = 25;
            tail.Height = 25;
            tail.Fill = Brushes.Blue;

            snake.Add(head);
            snake.Add(middle);
            snake.Add(tail);

            Canvas.SetTop(head, 0);
            Canvas.SetLeft(head, 50);

            Canvas.SetTop(middle, 0);
            Canvas.SetLeft(middle, 25);

            Canvas.SetTop(tail, 0);
            Canvas.SetLeft(tail, 0);

            Canvas.SetTop(food, getRandom() * 25);
            Canvas.SetLeft(food, getRandom() * 25);

            canvas.Children.Add(head);
            canvas.Children.Add(middle);
            canvas.Children.Add(tail);
            canvas.Children.Add(food);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += tick;
            timer.Start();
        }

        int getRandom()
        {
            Random r = new Random();
            return r.Next(20);
        }

        void tick(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                double y = Canvas.GetTop(snake[0]);
                double x = Canvas.GetLeft(snake[0]);

                double newY = y + vy;
                double newX = x + vx;

                if (newY < 0 || newY >= canvas.Height || newX < 0 || newX >= canvas.Width)
                {
                    for (int i = 0; i < snake.Count; i++)
                        snake[i].Fill = Brushes.Red;

                    gameOver = true;
                    return;
                }

                double food_y = Canvas.GetTop(food);
                double food_x = Canvas.GetLeft(food);

                if (food_y == newY && food_x == newX)
                {
                    Canvas.SetTop(food, getRandom() * 25);
                    Canvas.SetLeft(food, getRandom() * 25);

                    Rectangle newComponent = new Rectangle();
                    newComponent.Width = 25;
                    newComponent.Height = 25;
                    newComponent.Fill = Brushes.Blue;

                    snake.Add(newComponent);
                    canvas.Children.Add(newComponent);
                }

                Canvas.SetTop(snake[0], y + vy);
                Canvas.SetLeft(snake[0], x + vx);

                for (int i = 1; i < snake.Count; i++)
                {
                    double my_y = Canvas.GetTop(snake[i]);
                    double my_x = Canvas.GetLeft(snake[i]);

                    Canvas.SetTop(snake[i], y);
                    Canvas.SetLeft(snake[i], x);

                    y = my_y;
                    x = my_x;

                }
            }
        }

        private void keyPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && vy != speed)
            {
                vx = 0;
                vy = -speed;
            }
            if (e.Key == Key.Down && vy != -speed)
            {
                vx = 0;
                vy = speed;
            }
            if (e.Key == Key.Left && vx != speed)
            {
                vx = -speed;
                vy = 0;
            }
            if (e.Key == Key.Right && vx != -speed)
            {
                vx = speed;
                vy = 0;
            }
        }
    }
}
