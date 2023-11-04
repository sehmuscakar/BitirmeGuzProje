using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class MenuCategoryManager : IMenuCategoryManager
    {
        private readonly IMenuCategoryDal _menuCategoryDal;

        public MenuCategoryManager(IMenuCategoryDal menuCategoryDal)
        {
            _menuCategoryDal = menuCategoryDal;
        }

        public void Add(MenuCategory menuCategory)
        {
            var order = _menuCategoryDal.GetAll().Count();
            menuCategory.RowOrder = order + 1;
            _menuCategoryDal.Add(menuCategory);
        }

        public MenuCategory GetByID(int id)
        {
            return _menuCategoryDal.Get(id);
        }

        public List<MenuCategory> GetList()
        {
           return _menuCategoryDal.GetAll();
        }

        public List<MenuCategoryListDto> GetMenuCatgoryListManager()
        {
            return _menuCategoryDal.GetMenuCategoryListDal();

        }

        public void Remove(MenuCategory menuCategory)
        {
           _menuCategoryDal.Delete(menuCategory);
        }

        public void Update(MenuCategory menuCategory)
        {
            var order = _menuCategoryDal.GetAll().Count();
            menuCategory.RowOrder = order;
            menuCategory.LastUpdatedAt= DateTime.Now;
            _menuCategoryDal.Update(menuCategory);
        }
    }
}
