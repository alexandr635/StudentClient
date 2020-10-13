using System.Windows;
using System.Data.SqlClient;
using tryLINQ.Forms;
using System.Collections.Generic;
using System;
using tryLINQ.Classes;

namespace tryLINQ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void list_Click(object sender, RoutedEventArgs e)
        {
            listEntities window = new listEntities();
            Close();
            window.Show();
            SqlConnection connect = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=myDb; Integrated Security=True");
            try
            {
                connect.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM student";
                command.Connection = connect;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    List<Pers> myList = new List<Pers>();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader.GetValue(0));
                        string name = Convert.ToString(reader.GetValue(1));
                        string lastName = Convert.ToString(reader.GetValue(2));
                        int age = Convert.ToInt32(reader.GetValue(3));
                        string phone = Convert.ToString(reader.GetValue(4));
                        string language = Convert.ToString(reader.GetValue(5));

                        myList.Add(new Pers(id, name, lastName, phone, age, language));
                    };
                    window.list.ItemsSource = myList;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            createEntities window = new createEntities();
            Close();
            window.Show();
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            changeEntities window = new changeEntities();
            Close();
            window.Show();
        }
    }
}
