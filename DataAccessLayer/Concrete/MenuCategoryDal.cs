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
    public class MenuCategoryDal : BaseRepository<MenuCategory, ProjeContext>, IMenuCategoryDal
    {
        public List<MenuCategoryListDto> GetMenuCategoryListDal()
        {
            using (var context = new ProjeContext())
            {
                var a = context.MenuCategories.Select(menuCategory => new MenuCategoryListDto()
                {
                    Id = menuCategory.Id,
                    Name= menuCategory.Name,
                    LastUpdatedAt = menuCategory.LastUpdatedAt,
                    CreatedFullName = menuCategory.AppUser.Name,
                    RowOrder = menuCategory.RowOrder
                });
                return a.ToList();
            }
        }
    }
}
