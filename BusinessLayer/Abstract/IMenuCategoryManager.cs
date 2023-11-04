using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface IMenuCategoryManager
    {
        List<MenuCategoryListDto> GetMenuCatgoryListManager();
        List<MenuCategory> GetList();
        void Add(MenuCategory menuCategory);
        void Update(MenuCategory menuCategory);
        void Remove(MenuCategory menuCategory);
       MenuCategory GetByID(int id);
    }
}
