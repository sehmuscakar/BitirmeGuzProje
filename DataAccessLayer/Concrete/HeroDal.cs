using CoreLayer.DataAccess.EntityFramwork;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Concrete
{
    public class HeroDal : BaseRepository<Hero, ProjeContext>, IHeroDal
    {
        public List<HeroListDto> GetHeroListDal()
        {
            using (var context = new ProjeContext())
            {
                var a = context.Heroes.Select(about => new HeroListDto()
                {
                    Id = about.Id,
                    Description = about.Description,
                    Title1= about.Title1,
                    Title2= about.Title2,
                    LastUpdatedAt = about.LastUpdatedAt,
                    CreatedFullName = about.AppUser.Name,
                    RowOrder = about.RowOrder
                });
                return a.ToList();
            }
        }
    }
}
