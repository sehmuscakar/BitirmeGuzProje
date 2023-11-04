using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface IContactCompanyManager
    {
        List<ContactCompanyListDto> GetContactCompanyListManager();
        List<ContactCompany> GetList();
        void Add(ContactCompany contactCompany);
       void Update(ContactCompany contactCompany);
      void  Remove(ContactCompany contactCompany);
       ContactCompany GetByID(int id);
    }
}
