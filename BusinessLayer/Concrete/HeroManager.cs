using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class HeroManager : IHeroManager
    {
        private readonly IHeroDal _heroDal;

        public HeroManager(IHeroDal heroDal)
        {
            _heroDal = heroDal;
        }

        public void Add(Hero hero)
        {
            var order = _heroDal.GetAll().Count();
            hero.RowOrder= order+1;
            _heroDal.Add(hero);
        }

        public Hero GetByID(int id)
        {
            return _heroDal.Get(id);
        }

        public List<HeroListDto> GetHeroListManager()
        {
            return _heroDal.GetHeroListDal();
        }

        public List<Hero> GetList()
        {
           return _heroDal.GetAll();
        }

        public void Remove(Hero hero)
        {
           _heroDal.Delete(hero);
        }

        public void Update(Hero hero)
        {
            var order = _heroDal.GetAll().Count();
            hero.RowOrder = order;
            hero.LastUpdatedAt= DateTime.Now;
            _heroDal.Update(hero);
        }
    }
}
