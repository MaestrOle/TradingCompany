using AutoMapper;
using DTO;

namespace DALEF.Mapper
{
    class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Basket, BasketDTO>().ReverseMap();
        }
    }
}