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

        public MainWindow()
        {
            InitializeComponent();
            MyDataTable = new DataTable();

            string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            MySqlConnection conn = new MySqlConnection(connString);

            string sqlCommand = "select * from studenti";
            try
            {
                conn.Open();

                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCommand, conn);
                sda.Fill(MyDataTable);

                MyGuiTable.DataContext = MyDataTable;
                MyGuiTable.ItemsSource = MyDataTable.DefaultView;

                MessageBox.Show("Sql Command Executed!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Connection Error! Data: " + e.Data);
            }
        }
    }
}
