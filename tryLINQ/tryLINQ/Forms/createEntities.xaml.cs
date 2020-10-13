using System;
using System.Data.SqlClient;
using System.Windows;

namespace tryLINQ.Forms
{
    /// <summary>
    /// Interaction logic for createEntities.xaml
    /// </summary>
    public partial class createEntities : Window
    {
        public createEntities()
        {
            InitializeComponent();
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text != "" && lastName.Text != "" && age.Text != "" && phone.Text != "" && language.Text != "")
            {
                int variable;
                SqlConnection connect = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=myDb; Integrated Security=True");
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand();
                    try
                    {
                        variable = Convert.ToInt32(age.Text);
                        command.CommandText = $"INSERT INTO student (name, last_name, age, phone, language) " +
                                              $"VALUES('{name.Text}', '{lastName.Text}', {variable}, '{phone.Text}', '{language.Text}')";
                        command.Connection = connect;

                        int number = command.ExecuteNonQuery();
                        MessageBox.Show("Student add!");
                    }
                    catch
                    {
                        MessageBox.Show("You entered wrong AGE!\r\nEnter number!", "Exception");
                        age.Text = "";
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
            else
                MessageBox.Show("Введены не все данные!");
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            Close();
            window.Show();
        }
    }
}
