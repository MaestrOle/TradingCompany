using AutoMapper;
using DAL;
using DALEF;
using DTO;
using System.Collections.Generic;
using System.Linq;

namespace DALef.Concrete
{
    public class GenreDalEf : IGenreDal
    {
        private readonly IMapper _mapper;

        public GenreDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<GenresDTO> GetAllGenres()
        {
            using (var entities = new GamesDBEntities7())
            {
                var genres = entities.Genres.ToList();
                return _mapper.Map<List<GenresDTO>>(genres);
            }
        }
    }
}