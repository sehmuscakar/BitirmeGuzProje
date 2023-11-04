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
    public class TeamDal : BaseRepository<Team, ProjeContext>, ITeamDal
    {
        public List<TeamListDto> GetTeamListDal()
        {
            using (var context = new ProjeContext())
            {
                var a = context.Teams.Select(team => new TeamListDto()
                {
                    Id = team.Id,
                    ImageUrl= team.ImageUrl,
                    Name= team.Name,
                    Duty= team.Duty,
                    Twitter= team.Twitter,
                    Facebook= team.Facebook,
                    Instegram= team.Instegram,
                    LinkedIn= team.LinkedIn,
                    LastUpdatedAt = team.LastUpdatedAt,
                    CreatedFullName = team.AppUser.Name,
                    RowOrder = team.RowOrder
                });
                return a.ToList();
            }
        }
    }
}
