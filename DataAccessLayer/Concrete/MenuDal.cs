using CoreLayer.DataAccess.EntityFramwork;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class MenuDal : BaseRepository<Menu, ProjeContext>, IMenuDal
    {
        public List<MenuListDto> GetMenuListDal()
        {
            using (var context = new ProjeContext())
            {
                var a = context.Menus.Select(menu => new MenuListDto()
                {
                    Id = menu.Id,
                    Name = menu.Name,
                    ImageUrl= menu.ImageUrl,
                    Price= menu.Price,
                    Description= menu.Description,
                    MenuCategoryName=menu.MenuCategory.Name,
                    LastUpdatedAt = menu.LastUpdatedAt,
                    CreatedFullName = menu.AppUser.Name,
                    RowOrder = menu.RowOrder
                });
                return a.ToList();
            }
        }
    }
}
