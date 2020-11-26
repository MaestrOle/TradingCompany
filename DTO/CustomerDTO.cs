namespace DTO
{
    public class CustomerDTO
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfBirth { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public System.Guid Salt { get; set; }

    }
}
