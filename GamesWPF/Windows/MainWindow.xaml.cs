using System.Windows;

namespace GamesWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Hide();
        }

        private void Button_NewCustomer_Click(object sender, RoutedEventArgs e)
        {
            CreateCustomer createCustomer = new CreateCustomer();
            createCustomer.Show();
            Hide();
        }
    }

}
