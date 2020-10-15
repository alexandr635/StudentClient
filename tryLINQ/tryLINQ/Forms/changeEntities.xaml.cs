using System;
using System.Windows;
using tryLINQ.Db;

namespace tryLINQ.Forms
{
    /// <summary>
    /// Interaction logic for changeEntities.xaml
    /// </summary>
    public partial class ChangeEntities : Window
    {
        public ChangeEntities()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            Close();
            window.List_Click(sender, e);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text != "" && lastName.Text != "" && age.Text != "" && phone.Text != "" && language.Text != "")
            {
                try
                {
                    int agePers = Convert.ToInt32(age.Text);
                    QueryDb query = new QueryDb();
                    bool result = query.CreateAndUpdatePers($"UPDATE student " +
                                                            $"SET name='{name.Text}', last_name='{lastName.Text}', age={agePers}, " +
                                                            $"phone='{phone.Text}', language='{language.Text}'" +
                                                            $" WHERE id={id.Content}");
                    if (result == true)
                        MessageBox.Show("Student updated!");
                }
                catch
                {
                    MessageBox.Show("You entered wrong AGE!\r\nEnter number!", "Exception");
                }
            }
            else
                MessageBox.Show("Not all data entered!");
        }
    }
}
