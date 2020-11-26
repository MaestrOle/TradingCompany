using BusinessLogic.Concrete;
using DAL.Interfaces;
using DAL;
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
    public class GamesManagerTest
    {
        private Mock<IGamesDal> gameDal;
        private Mock<IGenreDal> genreDal;
        private Mock<IBasketDal> basketDal;
        private GamesManager manager;

        [SetUp]
        public void Setup()
        {
            gameDal = new Mock<IGamesDal>(MockBehavior.Strict);
            genreDal = new Mock<IGenreDal>(MockBehavior.Strict);
            basketDal = new Mock<IBasketDal>(MockBehavior.Strict);

            manager = new GamesManager(gameDal.Object, basketDal.Object, genreDal.Object);
        }


        [Test]
        public void AddToBasket()
        {
            BasketDTO inBasket = new BasketDTO
            {
                Title = "Test",
                Price = 1
            };
            BasketDTO outBasket = new BasketDTO { BasketID = 1 };

            basketDal.Setup(d => d.AddToBasket(inBasket)).Returns(outBasket);
            var res = manager.AddToBasket(inBasket);

            Assert.IsNotNull(res);
            Assert.AreEqual(outBasket.BasketID, res.BasketID);
        }
    }
}
