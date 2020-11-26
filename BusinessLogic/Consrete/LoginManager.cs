using BusinessLogic.Interfaces;
using DAL.Interfaces;

namespace BusinessLogic.Concrete
{
    public class LoginManager : ILoginManager
    {
        private readonly ICustomerDal _customerDal;
        public LoginManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public bool Login(string email, string password)
        {
            return _customerDal.Login(email, password);
        }
    }
}