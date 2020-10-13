using System.Windows;

namespace tryLINQ.Forms
{
    /// <summary>
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class listEntities : Window
    {
        public listEntities()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            Close();
            window.Show();
        }
    }
}
