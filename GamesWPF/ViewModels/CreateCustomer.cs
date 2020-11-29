using System.ComponentModel;
using BusinessLogic.Interfaces;
using DTO;
using System;

namespace GamesWPF.ViewModels
{
    public class CreateCustomerModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public string _firstname;
        public string FirstName
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string _lastname;
        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public int _yearofbirth;
        public int YearOfBirth
        {
            get
            {
                return _yearofbirth;
            }
            set
            {
                _yearofbirth = Convert.ToInt32(value);
                OnPropertyChanged(nameof(YearOfBirth));
            }
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

        public CreateCustomerModel(ILoginManager security)
        {
            _security = security;
        }

        public CustomerDTO CreateCustomer()
        {
            return _security.CreateCustomer(FirstName, LastName, YearOfBirth, Email, Password);
        }
    }
}
