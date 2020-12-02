using BusinessLogic.Interfaces;
using System;
using System.Windows.Forms;

namespace GamesWF
{
    public partial class LoginForm : Form
    {
        protected readonly ILoginManager _manager;
        public LoginForm(ILoginManager manager)
        {
            InitializeComponent();
            _manager = manager;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            doLogin();
            GenresForm genres = new GenresForm();
            genres.Show();
            Close();
        }

        private void doLogin()
        {
            if (_manager.Login(txtEmail.Text, txtPassword.Text))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                doLogin();
            }
        }
    }
}