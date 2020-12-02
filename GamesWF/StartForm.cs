using BusinessLogic.Interfaces;
using System;
using System.Windows.Forms;

namespace GamesWF
{
    public partial class StartForm : Form
    {
        protected readonly ILoginManager _manager;
        public StartForm(ILoginManager manager)
        {
            InitializeComponent();
            _manager = manager;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(_manager);
            loginForm.Show();
            Close();
        }
        private void ButtonCreateCustomer_Click(object sender, EventArgs e)
        {
            CreateCustomerForm customerForm = new CreateCustomerForm(_manager);
            customerForm.Show();
            Close();
        }
    }
}
