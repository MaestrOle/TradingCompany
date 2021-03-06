﻿using BusinessLogic.Concrete;
using DAL.Interfaces;
using DTO;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    [TestFixture]
    public class ManagerTests
    {
        private Mock<ICustomerDal> customerDal;
        private LoginManager manager;

        [SetUp]
        public void Setup()
        {
            customerDal = new Mock<ICustomerDal>(MockBehavior.Strict);

            manager = new LoginManager(customerDal.Object);
        }


        [Test]
        public void LoginCustomerTest()
        {
            string email = "email";
            string password = "pass";

            customerDal.Setup(d => d.Login(email, password)).Returns(true);
            var res = manager.Login(email, password);

            Assert.IsTrue(res);
        }
        [Test]
        public void CreateCustomerTest()
        {
            string fn = "firstname";
            string ln = "lastname";
            int yearofbirth = 2000;
            string email = "email";
            string password = "pass";

            customerDal.Setup(d => d.CreateCustomer(fn, ln, yearofbirth, email, password));
            var res = manager.CreateCustomer(fn, ln, yearofbirth, email, password);
            Assert.IsNotNull(res);
        }
    }
}
