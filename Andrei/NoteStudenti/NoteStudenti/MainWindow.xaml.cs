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

using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;

namespace NoteStudenti
{
    
    public partial class MainWindow : Window
    {
        ObservableCollection<string> names;
        public ObservableCollection<string> Names {
            get { return names; }
            set { names = value; }
        }

        private MySqlConnection conn;
        public MainWindow()
        {
            InitializeComponent();

            names = new ObservableCollection<string>();

            DataContext = this;

            string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

            conn = new MySqlConnection(connString);

            conn.Open();

            string SqlCommand = "SELECT Name FROM class;";

            try
            {
                MySqlCommand comm = new MySqlCommand(SqlCommand, conn);
                MySqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Names.Add((string)reader["Name"]);
                }

                reader.Close();

                NameBox.Text = "";
            }
            catch (Exception e)
            {
                MessageBox.Show("Connection failed " + e.Data);
            }
        }

        private void AddName(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text != "")
            {
                Names.Clear();

                string SqlSelectCommand = "SELECT Name FROM class;";
                string SqlAddCommand = string.Format("INSERT INTO class (Name) VALUES ('{0}');", NameBox.Text);

                try
                {
                    MySqlCommand comm1 = new MySqlCommand(SqlAddCommand, conn);
                    MySqlCommand comm2 = new MySqlCommand(SqlSelectCommand, conn);

                    comm1.ExecuteNonQuery();

                    MySqlDataReader reader = comm2.ExecuteReader();

                    while (reader.Read())
                    {
                        Names.Add((string)reader["Name"]);
                    }

                    reader.Close();

                    NameBox.Text = "";
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Connection failed");
                }
            }
        }

        private void RemoveName(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text != "")
            {
                Names.Clear();

                string SqlSelectCommand = "SELECT Name FROM class;";
                string SqlDeleteCommand = string.Format("DELETE FROM class WHERE Name='{0}';", NameBox.Text);

                try
                {
                    MySqlCommand comm1 = new MySqlCommand(SqlDeleteCommand, conn);
                    MySqlCommand comm2 = new MySqlCommand(SqlSelectCommand, conn);

                    comm1.ExecuteNonQuery();

                    MySqlDataReader reader = comm2.ExecuteReader();

                    while (reader.Read())
                    {
                        Names.Add((string)reader["Name"]);
                    }

                    NameBox.Text = "";

                    reader.Close();
                }
                catch (InvalidCastException except)
                {
                    MessageBox.Show("Connection failed" + except.Data);
                }
            }
        }
    }
}
