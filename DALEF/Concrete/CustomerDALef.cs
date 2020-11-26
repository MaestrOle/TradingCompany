using AutoMapper;
using DAL.Interfaces;
using DALEF;
using DTO;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DALef.Concrete
{
    public class CustomerDalEf : ICustomerDal
    {
        protected readonly IMapper _mapper;
        public CustomerDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }

        public CustomerDTO CreateCustomer(string firstname, string lastname, int yearofbirth, string email, string password)
        {
            using (var entities = new GamesDBEntities7())
            {
                if (entities.Customer.Any(u => u.Email == email))
                {
                    throw new Exception("User already exists!");
                }

                Guid salt = Guid.NewGuid();
                var customer = new Customer
                {
                    FirstName = firstname,
                    LastName = lastname,
                    YearOfBirth = yearofbirth,
                    Email = email,
                    Password = hash(password, salt.ToString()),
                    Salt = salt
                };

                entities.Customer.Add(customer);
                entities.SaveChanges();

                return _mapper.Map<CustomerDTO>(customer);
            }
        }

        public bool Login(string email, string password)
        {
            using (var ent = new GamesDBEntities7())
            {
                Customer user = ent.Customer.SingleOrDefault(u => u.Email == email);
                return user != null && user.Password.SequenceEqual(hash(password, user.Salt.ToString()));
            }
        }

        private byte[] hash(string password, string salt)
        {
            var alg = SHA512.Create();
            return alg.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }
    }
}