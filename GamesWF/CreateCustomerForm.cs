using BusinessLogic.Interfaces;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GamesWF
{
    public partial class CreateCustomerForm : Form
    {
        protected readonly ILoginManager _manager;
        public CreateCustomerForm(ILoginManager manager)
        {
            InitializeComponent();
            _manager = manager;
        }
        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            CreateCustomer();
            LoginForm loginForm = new LoginForm(_manager);
            loginForm.Show();
            Close();
        }
        private void CreateCustomer()
        {
            if (txtemail.Text.Contains('@') && txtemail.Text.Contains('.') && txtpass.Text == txtpass2.Text && Convert.ToBoolean(_manager.CreateCustomer(txtfirstname.Text, txtlastname.Text, Convert.ToInt32(txtyearofbirth.Text), txtemail.Text, txtpass.Text)))
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }
    }
}
