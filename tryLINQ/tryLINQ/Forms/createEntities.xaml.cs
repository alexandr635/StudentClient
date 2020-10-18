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
                    StudentQueryDb query = new StudentQueryDb();
                    string[] studentCharacteristics = new string[5]{name.Text, lastName.Text, age.Text, phone.Text, language.Text };
                    bool result = query.CreatePers(studentCharacteristics);
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
