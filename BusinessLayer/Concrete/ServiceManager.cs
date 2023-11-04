using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void Add(Service service)
        {
            var order = _serviceDal.GetAll().Count();
            service.RowOrder = order + 1;
            _serviceDal.Add(service);
        }

        public Service GetByID(int id)
        {
            return _serviceDal.Get(id);
        }

        public List<Service> GetList()
        {
            return _serviceDal.GetAll();
        }

        public List<ServiceListDto> GetServiceListManager()
        {
            return _serviceDal.GetServiceListDal();
        }

        public void Remove(Service service)
        {
          _serviceDal.Delete(service);
        }

        public void Update(Service service)
        {
            var order = _serviceDal.GetAll().Count();
            service.RowOrder = order;
            service.LastUpdatedAt = DateTime.Now;
            _serviceDal.Update(service);
        }
    }
}
