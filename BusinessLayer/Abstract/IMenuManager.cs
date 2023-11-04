using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMenuManager
    {
        List<MenuListDto> GetMenuListManager();
        List<Menu> GetList();
        void Add(Menu menu);
        void Update(Menu menu);
        void Remove(Menu menu);
        Menu GetByID(int id);
    }
}
