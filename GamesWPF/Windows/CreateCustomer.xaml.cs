using GamesWPF.ViewModels;
using System;
using System.Windows;
using System.Windows.Media;
using DTO;

namespace GamesWPF
{
    /// <summary>
    /// Логика взаимодействия для CreateCustomer.xaml
    /// </summary>
    public partial class CreateCustomer : Window
    {
        private readonly CreateCustomerModel _CustomerViewModel;
        public CreateCustomer(CreateCustomerModel vm)
        {
            _CustomerViewModel = vm;
            DataContext = _CustomerViewModel;

            InitializeComponent();
        }
        private void CreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(_CustomerViewModel.CreateCustomer()))
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials", "Error");
            }
        }
    }
}

