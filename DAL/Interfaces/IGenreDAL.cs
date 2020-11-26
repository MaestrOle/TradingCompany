using DTO;
using System.Collections.Generic;

namespace DAL
{
    public interface IGenreDal
    {
        List<GenresDTO> GetAllGenres();
    }
}
