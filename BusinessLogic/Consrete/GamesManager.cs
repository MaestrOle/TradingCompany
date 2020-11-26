using BusinessLogic.Interfaces;
using DAL;
using DAL.Interfaces;
using DTO;
using System.Collections.Generic;

namespace BusinessLogic.Concrete
{
    public class GamesManager : IGamesManager
    {
        private readonly IGamesDal _gameDal;
        private readonly IGenreDal _genreDal;
        private readonly IBasketDal _basketDal;

        public GamesManager(IGamesDal gameDal, IBasketDal basketDal, IGenreDal genreDal)
        {
            _gameDal = gameDal;
            _genreDal = genreDal;
            _basketDal = basketDal;
        }

        public BasketDTO AddToBasket(BasketDTO newelem)
        {
            return _basketDal.AddToBasket(newelem);
        }

        public List<GenresDTO> GetAllGenres()
        {
            return _genreDal.GetAllGenres();
        }

        public List<GamesDTO> GamesInGenre(int genreID)
        {
            return _gameDal.GamesInGenre(genreID);
        }

        public List<GamesDTO> Find(string Title, int genreID)
        {
            return _gameDal.Find(Title, genreID);
        }

        public List<GamesDTO> Sort(string Title, int genreID)
        {
            return _gameDal.Sort(Title, genreID);
        }
    }
}