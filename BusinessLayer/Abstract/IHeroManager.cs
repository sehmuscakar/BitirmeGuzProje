using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IHeroManager
    {
        List<HeroListDto> GetHeroListManager();
        List<Hero> GetList();
        void Add(Hero hero);
        void Update(Hero hero);
        void Remove(Hero hero);
        Hero GetByID(int id);
    }
}
