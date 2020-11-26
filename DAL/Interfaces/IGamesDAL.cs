using DTO;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IGamesDal
    {
        List<GamesDTO> GamesInGenre(int genreID);
        List<GamesDTO> Sort(string Title, int genreID);
        List<GamesDTO> Find(string Title, int genreID);
        GamesDTO ShowGameInfo(int gameID);
    }
}
