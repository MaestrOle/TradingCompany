using AutoMapper;
using DAL.Interfaces;
using DTO;

namespace DALEF.Concrete
{
    public class BasketDalEf : IBasketDal
    {
        private readonly IMapper _mapper;

        public BasketDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddToBasket(BasketDTO newelem)
        {
            using (var entities = new GamesDBEntities7())
            {
                Basket b = _mapper.Map<Basket>(newelem);
                entities.Basket.Add(b);
                entities.SaveChanges();
            }
        }
    }
}