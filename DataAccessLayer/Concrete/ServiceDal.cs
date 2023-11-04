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
    public class ServiceDal : BaseRepository<Service, ProjeContext>, IServiceDal
    {
        public List<ServiceListDto> GetServiceListDal()
        {
            using (var context = new ProjeContext())
            {
                var a = context.Services.Select(service => new ServiceListDto()
                {
                    Id = service.Id,
                 Title=service.Title,
                    ImageUrl = service.ImageUrl,
                 
                    Description = service.Description,
                   
                    LastUpdatedAt = service.LastUpdatedAt,
                    CreatedFullName = service.AppUser.Name,
                    RowOrder = service.RowOrder
                });
                return a.ToList();
            }
        }
    }
}
