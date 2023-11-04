using CoreLayer.DataAccess.EntityFramwork;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Concrete
{
    public class ContactCompanyDal : BaseRepository<ContactCompany, ProjeContext>, IContactCompanyDal
    {
        public List<ContactCompanyListDto> GetContactCompanyListDal()
        {
            using (var context = new ProjeContext())
            {
                var a = context.ContactCompanies.Select(contactCompany => new ContactCompanyListDto()
                {
                    Id = contactCompany.Id,
                    ImageUrl= contactCompany.ImageUrl,
                    CompanyName= contactCompany.CompanyName,
                    Address = contactCompany.Address,
                    Mail = contactCompany.Mail,
                    Phone = contactCompany.Phone,
                    Twiter = contactCompany.Twiter,
                    Facebook = contactCompany.Facebook,
                    Instegram = contactCompany.Instegram,
                    Linkedin = contactCompany.Linkedin,
                    Skype = contactCompany.Skype,
                    WorkDate = contactCompany.WorkDate,
                    LastUpdatedAt = contactCompany.LastUpdatedAt,
                    CreatedFullName = contactCompany.AppUser.Name,
                    RowOrder = contactCompany.RowOrder
                });
                return a.ToList();
            }
        }
    }
}
