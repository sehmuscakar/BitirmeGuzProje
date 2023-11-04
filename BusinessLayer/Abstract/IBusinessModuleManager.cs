using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBusinessModuleManager
    {
        List<BusinessModuleListDto> GetBusinessModuleListManager();
        List<BusinessModule> GetList();
        void Add(BusinessModule bussinesModule);
        void Update(BusinessModule bussinesModule);
        void Remove(BusinessModule bussinesModule);
        BusinessModule GetByID(int id);
    }
}
