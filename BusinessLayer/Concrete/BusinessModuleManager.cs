using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class BusinessModuleManager : IBusinessModuleManager
    {
        private readonly IBusinessModuleDal _bussinesModuleDal;

        public BusinessModuleManager(IBusinessModuleDal bussinesModuleDal)
        {
            _bussinesModuleDal = bussinesModuleDal;
        }

        public void Add(BusinessModule bussinesModule)
        {
            var roworder = _bussinesModuleDal.GetAll().Count();
           bussinesModule.RowOrder= roworder+1;
           _bussinesModuleDal.Add(bussinesModule);
        }

        public List<BusinessModuleListDto> GetBusinessModuleListManager()
        {
            return _bussinesModuleDal.GetBusinessModuleListDal();
        }

        public BusinessModule GetByID(int id)
        {
            return _bussinesModuleDal.Get(id);
        }

        public List<BusinessModule> GetList()
        {
            return _bussinesModuleDal.GetAll(); 
        }

        public void Remove(BusinessModule bussinesModule)
        {
            _bussinesModuleDal.Delete(bussinesModule);
        }

        public void Update(BusinessModule bussinesModule)
        {
            var roworder = _bussinesModuleDal.GetAll().Count();
            bussinesModule.RowOrder = roworder;
            bussinesModule.LastUpdatedAt= DateTime.Now;
           _bussinesModuleDal.Update(bussinesModule);
        }
    }
}
