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

using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace Graphs
{
    public partial class MainWindow : Window
    {
        DataTable MyDataTable { get; set; }
        DataTable MyDataTable2 { get; set; }

        private MySqlConnection conn;


        public MainWindow()
        {
            InitializeComponent();
            MyDataTable = new DataTable();


            string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            conn = new MySqlConnection(connString);
            conn.Open();

            string sqlCommand = "SELECT * FROM info;";
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCommand, conn);
                sda.Fill(MyDataTable);

                MyGuiTable.DataContext = MyDataTable;
                MyGuiTable.ItemsSource = MyDataTable.DefaultView;
            }
            catch (Exception e)
            {
                MessageBox.Show("Connection Error! Data: " + e.Data);
            }

            MyDataTable2 = new DataTable();
            string sqlCommand2 = "SELECT * FROM road;";
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCommand2, conn);
                sda.Fill(MyDataTable2);

                MyGuiTable2.DataContext = MyDataTable2;
                MyGuiTable2.ItemsSource = MyDataTable2.DefaultView;
            }
            catch (Exception e)
            {
                MessageBox.Show("Connection Error! Data: " + e.Data);
            }

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

        private void addButton(object sender, RoutedEventArgs e)
        {
            string id = IdBox.Text;
            string name = NameBox.Text;
            string x = XBox.Text;
            string y = YBox.Text;

            string sqlCommand = "SELECT * FROM info;";
            string insertCommand = String.Format("insert into info values ('{0}', '{1}', '{2}', '{3}');", id, name, x, y);

            try
            {
                MyDataTable.Clear();
                MySqlCommand ins = new MySqlCommand(insertCommand, conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCommand, conn);
                ins.ExecuteNonQuery();
                sda.Fill(MyDataTable);

                MyGuiTable.DataContext = MyDataTable;
                MyGuiTable.ItemsSource = MyDataTable.DefaultView;

                MessageBox.Show("Add Command Executed!");
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Error!");
            }
        }

        private void removeButton(object sender, RoutedEventArgs e)
        {
            string id = IdBox.Text;
            string name = NameBox.Text;
            string x = XBox.Text;
            string y = YBox.Text;

            string sqlCommand = "select * from info;";
            string deleteCommand = String.Format("delete from info where ID='{0}' or name='{1}' or x='{2}' or y='{3}';", id, name, x, y);

            try
            {
                MyDataTable.Clear();
                MySqlCommand del = new MySqlCommand(deleteCommand, conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCommand, conn);
                del.ExecuteNonQuery();
                sda.Fill(MyDataTable);

                MyGuiTable.DataContext = MyDataTable;
                MyGuiTable.ItemsSource = MyDataTable.DefaultView;

                MessageBox.Show("Remove Command Executed!");
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Error!");
            }
        }

        private void addToFromButton(object sender, RoutedEventArgs e)
        {
            string to = ToBox.Text;
            string from = FromBox.Text;

            string sqlCommand = "SELECT * FROM road;";
            string insertCommand = String.Format("insert into road values ('{0}', '{1}');", to, from);

            try
            {
                MyDataTable2.Clear();
                MySqlCommand ins = new MySqlCommand(insertCommand, conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCommand, conn);
                ins.ExecuteNonQuery();
                sda.Fill(MyDataTable2);

                MyGuiTable2.DataContext = MyDataTable2;
                MyGuiTable2.ItemsSource = MyDataTable2.DefaultView;

                MessageBox.Show("Add Command Executed!");
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Error!");
            }
        }

        private void removeToFromButton(object sender, RoutedEventArgs e)
        {
            string to = ToBox.Text;
            string from = FromBox.Text;

            string sqlCommand = "select * from road;";
            string deleteCommand = String.Format("delete from road where `to`='{0}' or `from`='{1}';", to,from);

            try
            {
                MyDataTable2.Clear();
                MySqlCommand del = new MySqlCommand(deleteCommand, conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCommand, conn);
                del.ExecuteNonQuery();
                sda.Fill(MyDataTable2);

                MyGuiTable2.DataContext = MyDataTable2;
                MyGuiTable2.ItemsSource = MyDataTable2.DefaultView;

                MessageBox.Show("Remove Command Executed!");
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Error!");
            }
        }
    }
}
