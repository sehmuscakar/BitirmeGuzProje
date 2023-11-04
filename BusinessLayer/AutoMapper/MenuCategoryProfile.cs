using AutoMapper;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;
namespace BusinessLayer.AutoMapper
{
    public class MenuCategoryProfile:Profile
    {
        public MenuCategoryProfile()
        {
            CreateMap<MenuCategoryListDto, MenuCategory>().ReverseMap();
        }
    }
}
