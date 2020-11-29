using GamesWPF.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace GamesWPF.Windows
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly LoginModel _loginViewModel;
        public Login(LoginModel vm)
        {
            _loginViewModel = vm;
            DataContext = _loginViewModel;

            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (_loginViewModel.Login())
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials", "Error");
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((dynamic)DataContext).Password = ((PasswordBox)sender).Password;
            }
        }
    }
}
