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
                    StudentQueryDb query = new StudentQueryDb();
                    string[] updateData = new string[6] {name.Text, lastName.Text, age.Text, phone.Text, language.Text, id.Content.ToString() };
                    bool result = query.UpdatePers(updateData);
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
