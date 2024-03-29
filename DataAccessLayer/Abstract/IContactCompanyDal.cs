﻿using CoreLayer.DataAccess;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Abstract
{
    public interface IContactCompanyDal:IEntityRepository<ContactCompany>
    {
       List<ContactCompanyListDto> GetContactCompanyListDal();
    }
}
