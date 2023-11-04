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
    public class GalleryDal : BaseRepository<Gallery, ProjeContext>, IGalleryDal
    {
        public List<GalleryListDto> GetGalleryListDal()
        {
            using (var context = new ProjeContext())
            {
                var a = context.Galleries.Select(galleri => new GalleryListDto()
                {
                    Id = galleri.Id,
                    ImageUrl= galleri.ImageUrl, 
                    LastUpdatedAt = galleri.LastUpdatedAt,
                    CreatedFullName = galleri.AppUser.Name,
                    RowOrder = galleri.RowOrder
                });
                return a.ToList();
            }
        }
    }
}
