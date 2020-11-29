using DTO;

namespace BusinessLogic.Interfaces
{
    public interface ILoginManager
    {
        CustomerDTO CreateCustomer(string FirstName, string LastName, int YearOfBirth, string email, string password);
        bool Login(string email, string password);
    }
}
