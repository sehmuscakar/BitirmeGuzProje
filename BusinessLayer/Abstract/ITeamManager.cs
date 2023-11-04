using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public interface ITeamManager
    {
        List<TeamListDto> GetTeamListManager();
        List<Team> GetList();
        void Add(Team team);
        void Update(Team team);
        void Remove(Team team);
        Team GetByID(int id);
    }
}
