using BusinessLogic.Interfaces;
using System.ComponentModel;

namespace GamesWPF.ViewModels
{
    public class LoginModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            private get;
            set;
        }

        private readonly ILoginManager _security;

        public LoginModel(ILoginManager security)
        {
            _security = security;
        }

        public bool Login()
        {
            return _security.Login(Email, Password);
        }
    }
}
