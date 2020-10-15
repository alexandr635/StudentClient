using System;
using System.Windows;
using tryLINQ.Db;

namespace tryLINQ.Forms
{
    /// <summary>
    /// Interaction logic for createEntities.xaml
    /// </summary>
    public partial class CreateEntities : Window
    {
        public CreateEntities()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text != "" && lastName.Text != "" && age.Text != "" && phone.Text != "" && language.Text != "")
            {
                try
                {
                    int agePers = Convert.ToInt32(age.Text);
                    QueryDb query = new QueryDb();
                    bool result = query.CreateAndUpdatePers($"INSERT INTO student (name, last_name, age, phone, language) " +
                                              $"VALUES('{name.Text}', '{lastName.Text}', {agePers}, '{phone.Text}', '{language.Text}')");
                    if (result == true)
                        MessageBox.Show("Student added!");
                }
                catch
                {
                    MessageBox.Show("You entered wrong AGE!\r\nEnter number!", "Exception");
                }
            }
            else
                MessageBox.Show("Not all data entered!");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            Close();
            window.Show();
        }
    }
}
