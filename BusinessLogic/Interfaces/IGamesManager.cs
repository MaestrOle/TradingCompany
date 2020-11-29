using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IGamesManager
    {
        List<GamesDTO> GamesInGenre(int genreID);
        List<GamesDTO> Sort(string Title, int genreID);
        List<GamesDTO> Find(string Title, int genreID);
        List<GenresDTO> GetAllGenres();
        GamesDTO ShowGameInfo(int gameID);
        BasketDTO AddToBasket(BasketDTO newelem);
    }
}
