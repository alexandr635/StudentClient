using System;
using System.Windows;
using tryLINQ.Classes;

namespace tryLINQ.Forms
{
    /// <summary>
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class ListEntities : Window
    {
        public ListEntities()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            Close();
            window.Show();
        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pers changePerson = (Pers)list.SelectedItem;
                if (changePerson != null)
                {
                    ChangeEntities window = new ChangeEntities();
                    Close();
                    window.Show();

                    window.id.Content = changePerson.id;
                    window.name.Text = changePerson.name;
                    window.lastName.Text = changePerson.last_name;
                    window.age.Text = changePerson.age.ToString();
                    window.phone.Text = changePerson.phone;
                    window.language.Text = changePerson.language;
                }
                else
                    MessageBox.Show("Select student!");
            }
            catch
            {
                MessageBox.Show("Are you stupid?");
            }
        }
    }
}
