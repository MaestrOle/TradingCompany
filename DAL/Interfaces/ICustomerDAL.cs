using DTO;

namespace DAL.Interfaces
{
    public interface ICustomerDal
    {
        CustomerDTO CreateCustomer(string FirstName, string LastName, int YearOfBirth, string email, string password);
        bool Login(string email, string password);
    }
}