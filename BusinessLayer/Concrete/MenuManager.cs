using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class MenuManager : IMenuManager
    {
        private readonly IMenuDal _menuDal;

        public MenuManager(IMenuDal menuDal)
        {
            _menuDal = menuDal;
        }

        public void Add(Menu menu)
        {
            var order = _menuDal.GetAll().Count();
          menu.RowOrder = order + 1;
            _menuDal.Add(menu);
        }

        public Menu GetByID(int id)
        {
            return _menuDal.Get(id);
        }

        public List<Menu> GetList()
        {
            return _menuDal.GetAll();
        }

        public List<MenuListDto> GetMenuListManager()
        {
            return _menuDal.GetMenuListDal();
        }

        public void Remove(Menu menu)
        {
           _menuDal.Delete(menu);
        }

        public void Update(Menu menu)
        {
            var order = _menuDal.GetAll().Count();
            menu.RowOrder = order;
            menu.LastUpdatedAt= DateTime.Now;
            _menuDal.Update(menu);
        }
    }
}
