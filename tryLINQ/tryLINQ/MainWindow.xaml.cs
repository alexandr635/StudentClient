using System.Windows;
using tryLINQ.Forms;
using tryLINQ.Db;

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

        public void List_Click(object sender, RoutedEventArgs e)
        {
            ListEntities window = new ListEntities();
            Close();
            window.Show();

            QueryDb query = new QueryDb();
            window.list.ItemsSource = query.SelectPers("SELECT * FROM student");
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreateEntities window = new CreateEntities();
            Close();
            window.Show();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            ChangeEntities window = new ChangeEntities();
            Close();
            window.Show();
        }
    }
}
