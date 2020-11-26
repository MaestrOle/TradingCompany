using DTO;

namespace DAL.Interfaces
{
    public interface IBasketDal
    {
        void AddToBasket(BasketDTO newelem);
    }
}
