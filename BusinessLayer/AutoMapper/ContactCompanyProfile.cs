﻿using AutoMapper;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper
{
   public class ContactCompanyProfile:Profile
    {
        public ContactCompanyProfile()
        {
            CreateMap<ContactCompanyListDto, ContactCompany>().ReverseMap();
        }
    }
}
