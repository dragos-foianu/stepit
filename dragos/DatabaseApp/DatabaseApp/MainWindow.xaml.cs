using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace DatabaseApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string connString = "serverConnectionString";
            SqlConnection conn = new SqlConnection(connString);

            string sql1 = "create table tabel (id int, name varchar(255))";
            string sql2 = "select * from tabel";
            try
            {
                conn.Open();

                SqlCommand command1 = new SqlCommand(sql1, conn);
                command1.ExecuteNonQuery();
                command1.Dispose();

                SqlCommand command2 = new SqlCommand(sql2, conn);
                command2.ExecuteNonQuery();
                command2.Dispose();
            
                conn.Close();
                MessageBox.Show(" ExecuteNonQuery in SqlCommand executed !!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }
    }
}
