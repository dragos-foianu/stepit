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

namespace DatabaseApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable MyDataTable { get; set; }
        DataTable StudentTable { get; set; }

        private MySqlConnection conn;

        public MainWindow()
        {
            InitializeComponent();
            MyDataTable = new DataTable();
            StudentTable = new DataTable();

            string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            conn = new MySqlConnection(connString);
            conn.Open();

            string sqlCommand = "select * from troll;";
            string sqlCommand2 = "select * from note;";
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCommand, conn);
                sda.Fill(StudentTable);

                numeTable.DataContext = StudentTable;
                numeTable.ItemsSource = StudentTable.DefaultView;

                MySqlDataAdapter sda2 = new MySqlDataAdapter(sqlCommand2, conn);
                sda2.Fill(MyDataTable);

                MyGuiTable.DataContext = MyDataTable;
                MyGuiTable.ItemsSource = MyDataTable.DefaultView;
            }
            catch (Exception e)
            {
                MessageBox.Show("Connection Error! Data: " + e.Data);
            }
        }
        /*
        private void addButton(object sender, RoutedEventArgs e)
        {
            string id = idBox.Text;
            string nume = NumeBox.Text;
            string nota = NotaBox.Text;
            string comment = CommentBox.Text;

            string sqlCommand = "select * from studenti;";
            string insertCommand = String.Format("insert into troll values ('{0}');", nume);

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
            string nume = NumeBox.Text;
            string nota = NotaBox.Text;
            string comment = CommentBox.Text;

            string sqlCommand = "select * from studenti;";
            string deleteCommand = String.Format("delete from studenti where ID='{0}' or Nume='{1}' or Nota='{2}';", id, nume, nota);

            try
            {
                MyDataTable.Clear();
                MySqlCommand ins = new MySqlCommand(deleteCommand, conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCommand, conn);
                ins.ExecuteNonQuery();
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

        private void updateButton(object sender, RoutedEventArgs e)
        {
            string id = IdBox.Text;
            string nume = NumeBox.Text;
            string nota = NotaBox.Text;
            string comment = CommentBox.Text;

            string sqlCommand = "select * from studenti;";
            string updateCommand = String.Format("delete from studenti where ID='{0}' or Nume='{1}' or Nota='{2}';", id, nume, nota);

            try
            {
                MyDataTable.Clear();
                MySqlCommand ins = new MySqlCommand(updateCommand, conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCommand, conn);
                ins.ExecuteNonQuery();
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
        */

        private void removestudent(object sender, RoutedEventArgs e)
        {
            string nume = numeBox.Text;

            string sqlCommand = "select * from troll;";
            string insertCommand = String.Format("delete from troll where nume='{0}';", nume);

            try
            {
                StudentTable.Clear();
                MySqlCommand ins = new MySqlCommand(insertCommand, conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCommand, conn);
                ins.ExecuteNonQuery();
                sda.Fill(StudentTable);

                numeTable.DataContext = StudentTable;
                numeTable.ItemsSource = StudentTable.DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Error!");
            }
        }

        private void addstudent(object sender, RoutedEventArgs e)
        {


            string nume = numeBox.Text;

            string sqlCommand = "select * from troll;";
            string insertCommand = String.Format("insert into troll(nume) values ('{0}');", nume);

            try
            {

                StudentTable.Clear();
                MySqlCommand ins = new MySqlCommand(insertCommand, conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCommand, conn);
                ins.ExecuteNonQuery();
                sda.Fill(StudentTable);

                numeTable.DataContext = StudentTable;
                numeTable.ItemsSource = StudentTable.DefaultView;

            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Connection Error!");
            }
        }

        private void addnota(object sender, RoutedEventArgs e)
        {
            string materie = materieBox.Text;
            string nota = NotaBox.Text;

            string sqlCommand = "select * from note;";
            string insertCommand = String.Format("insert into note(id, materie, nota) values ('{0}', '{1}','{2}');", 3 ,materie, nota);

            try
            {
                MyDataTable.Clear();
                MySqlCommand ins = new MySqlCommand(insertCommand, conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCommand, conn);
                ins.ExecuteNonQuery();
                sda.Fill(MyDataTable);

                MyGuiTable.DataContext = MyDataTable;
                MyGuiTable.ItemsSource = MyDataTable.DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Error!");
            }
        }

        private void removenota(object sender, RoutedEventArgs e)
        {
            string materie = materieBox.Text;
            string nota = NotaBox.Text;
            
            string sqlCommand = "select * from note;";
            string deleteCommand = String.Format("delete from note where nota='{0}' or materie='{1}';", nota, materie );

            try
            {
                MyDataTable.Clear();
                MySqlCommand ins = new MySqlCommand(deleteCommand, conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCommand, conn);
                ins.ExecuteNonQuery();
                sda.Fill(MyDataTable);

                MyGuiTable.DataContext = MyDataTable;
                MyGuiTable.ItemsSource = MyDataTable.DefaultView;
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Connection Error!");
            }
        
    }

        private void numeTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
