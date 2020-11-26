using AutoMapper;
using DALEF;
using DTO;

namespace DALef.MapperProfiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genres, GenresDTO>().ReverseMap();
        }
    }
}