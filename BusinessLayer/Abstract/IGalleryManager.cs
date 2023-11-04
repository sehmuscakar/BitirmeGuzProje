using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGalleryManager
    {
        List<GalleryListDto> GetGalleryListManager();
        List<Gallery> GetList();
        void Add(Gallery gallery);
        void Update(Gallery gallery);
        void Remove(Gallery gallery);
        Gallery GetByID(int id);
    }
}
