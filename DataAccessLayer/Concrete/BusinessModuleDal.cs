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
    public class BusinessModuleDal : BaseRepository<BusinessModule, ProjeContext>, IBusinessModuleDal
    {
        public List<BusinessModuleListDto> GetBusinessModuleListDal()
        {
            using (var context = new ProjeContext())
            {
                var a = context.BusinessModules.Select(businessModule => new BusinessModuleListDto()
                {
                    Id = businessModule.Id,      
                    ImageUrl = businessModule.ImageUrl,
                    AboutTitle= businessModule.AboutTitle,
                    About= businessModule.About,
                    MissionTitle= businessModule.MissionTitle,
                    Mission= businessModule.Mission,
                    Vision= businessModule.Vision,
                    VisionTitle= businessModule.Vision,
                    LastUpdatedAt = businessModule.LastUpdatedAt,
                    CreatedFullName = businessModule.AppUser.Name,
                    RowOrder = businessModule.RowOrder
                });
                return a.ToList();
            }
        }
    }
}
