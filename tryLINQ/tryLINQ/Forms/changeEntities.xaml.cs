using System;
using System.Data.SqlClient;
using System.Windows;

namespace tryLINQ.Forms
{
    /// <summary>
    /// Interaction logic for changeEntities.xaml
    /// </summary>
    public partial class changeEntities : Window
    {
        public changeEntities()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            Close();
            window.Show();
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            if (id.Text != "" && select.SelectedIndex > -1 && replacement.Text != "")
            {
                SqlConnection connect = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=myDb; Integrated Security=True");
                try
                {
                    connect.Open();
                    try
                    {
                        int variable = Convert.ToInt32(id.Text);
                        string field = "";
                        SqlCommand command;
                        switch (select.SelectedIndex)
                        {
                            case 0:
                                field = "name";
                                break;
                            case 1:
                                field = "last_name";
                                break;
                            case 2:
                                field = "age";
                                break;
                            case 3:
                                field = "phone";
                                break;
                            case 4:
                                field = "language";
                                break;
                        }
                        
                        command = new SqlCommand($"SELECT id FROM student WHERE id={variable}", connect);
                        SqlDataReader read = command.ExecuteReader();
                        if (read.HasRows)
                        {
                            int number;
                            read.Close();
                            if (field != "age")
                            {
                                command = new SqlCommand($"UPDATE student SET {field}='{replacement.Text}' WHERE id={variable}", connect);
                                try
                                {
                                    number = command.ExecuteNonQuery();
                                    MessageBox.Show("Пользователь обновлен!");
                                }
                                catch
                                {
                                    MessageBox.Show("Слишком большое значение!");
                                    replacement.Text = "";
                                }
                            }
                            else
                            {
                                try
                                {
                                    int numb = Convert.ToInt32(replacement.Text);
                                    command = new SqlCommand($"UPDATE student SET {field}='{numb}' WHERE id={variable}", connect);
                                    number = command.ExecuteNonQuery();
                                    MessageBox.Show("Пользователь обновлен!");
                                }
                                catch
                                {
                                    MessageBox.Show($"You entered wrong AGE!\r\nEnter number!", "Exception");
                                    replacement.Text = "";
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("No such Id exists!");
                            id.Text = "";
                        }
                    }
                    catch
                    {
                        MessageBox.Show("You entered wrong id!\r\nEnter number!", "Exception");
                        id.Text = "";
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Введены не все данные!");
        }
    }
}
