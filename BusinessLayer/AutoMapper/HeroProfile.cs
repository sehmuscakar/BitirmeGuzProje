using AutoMapper;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.AutoMapper
{
    public class HeroProfile:Profile
    {
        public HeroProfile()
        {
            CreateMap<HeroListDto, Hero>().ReverseMap();
        }
    }
}
