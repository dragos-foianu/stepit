using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace WpfApplication3
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<ObservableCollection<string>> Game { get; set; }
        public ObservableCollection<string> Winner { get; set; }
        public ObservableCollection<string> Log { get; set; }

        private string next;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Game = new ObservableCollection<ObservableCollection<string>>();
            for (int i = 0; i < 3; i++) Game.Add(new ObservableCollection<string>());

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Game[i].Add("");

            Log = new ObservableCollection<string>();
            reset();
        }

        private void reset()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Game[i][j] = "";
            next = "X";
            Log.Clear();
            Log.Add("Game starts...");

            button00.IsEnabled = true;
            button01.IsEnabled = true;
            button02.IsEnabled = true;
            button10.IsEnabled = true;
            button11.IsEnabled = true;
            button12.IsEnabled = true;
            button20.IsEnabled = true;
            button21.IsEnabled = true;
            button22.IsEnabled = true;
        }

        private void setNext(string crt)
        {
            if (next == "X") next = "O";
            else if (next == "O") next = "X";
            Log.Add(next + " moves...");
        }

        private bool isGameOver()
        {
            if (Game[0][0] == Game[0][1] && Game[0][1] == Game[0][2] && Game[0][0] != "")
                { return true; }
            if (Game[1][0] == Game[1][1] && Game[1][1] == Game[1][2] && Game[1][0] != "")
                { return true; }
            if (Game[2][0] == Game[2][1] && Game[2][1] == Game[2][2] && Game[2][0] != "")
                { return true; }

            if (Game[0][0] == Game[1][0] && Game[1][0] == Game[2][0] && Game[0][0] != "")
                { return true; }
            if (Game[0][1] == Game[1][1] && Game[1][1] == Game[2][1] && Game[0][1] != "")
                { return true; }
            if (Game[0][2] == Game[1][2] && Game[1][2] == Game[2][2] && Game[0][2] != "")
                { return true; }

            if (Game[0][0] == Game[1][1] && Game[1][1] == Game[2][2] && Game[0][0] != "")
                { return true; }
            if (Game[2][0] == Game[1][1] && Game[1][1] == Game[0][2] && Game[1][1] != "")
                { return true; }

            return false;
        }

        private void gameOver()
        {
            button00.IsEnabled = false;
            button01.IsEnabled = false;
            button02.IsEnabled = false;
            button10.IsEnabled = false;
            button11.IsEnabled = false;
            button12.IsEnabled = false;
            button20.IsEnabled = false;
            button21.IsEnabled = false;
            button22.IsEnabled = false;
            Log.Add(next + " wins");
        }

        private void resetClicked(object sender, RoutedEventArgs e)
        {
            reset();
        }

        private void stateChanged(int i, int j)
        {
            Game[i][j] = next;
            if (isGameOver()) gameOver();
            else
            {
                setNext(next);
            }
        }

        private void boardClicked00(object sender, RoutedEventArgs e)
        {
            stateChanged(0, 0);
            button00.IsEnabled = false;
        }

        private void boardClicked01(object sender, RoutedEventArgs e)
        {
            stateChanged(0, 1);
            button01.IsEnabled = false;
        }

        private void boardClicked02(object sender, RoutedEventArgs e)
        {
            stateChanged(0, 2);
            button02.IsEnabled = false;

        }

        private void boardClicked10(object sender, RoutedEventArgs e)
        {
            stateChanged(1, 0);
            button10.IsEnabled = false;
        }

        private void boardClicked11(object sender, RoutedEventArgs e)
        {
            stateChanged(1, 1);
            button11.IsEnabled = false;
        }

        private void boardClicked12(object sender, RoutedEventArgs e)
        {
            stateChanged(1, 2);
            button12.IsEnabled = false;
        }

        private void boardClicked20(object sender, RoutedEventArgs e)
        {
            stateChanged(2, 0);
            button20.IsEnabled = false;
        }

        private void boardClicked21(object sender, RoutedEventArgs e)
        {
            stateChanged(2, 1);
            button21.IsEnabled = false;
        }

        private void boardClicked22(object sender, RoutedEventArgs e)
        {
            stateChanged(2, 2);
            button22.IsEnabled = false;
        }
    }
}
