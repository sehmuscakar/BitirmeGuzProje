using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class GalleryManager : IGalleryManager
    {
        private readonly IGalleryDal _galleryDal;

        public GalleryManager(IGalleryDal galleryDal)
        {
            _galleryDal = galleryDal;
        }

        public void Add(Gallery gallery)
        {
            var roworder = _galleryDal.GetAll().Count();
            gallery.RowOrder = roworder+1;
            _galleryDal.Add(gallery);
        }

        public Gallery GetByID(int id)
        {
            return _galleryDal.Get(id);
        }

        public List<GalleryListDto> GetGalleryListManager()
        {
            return _galleryDal.GetGalleryListDal();
        }

        public List<Gallery> GetList()
        {
            return _galleryDal.GetAll();
        }

        public void Remove(Gallery gallery)
        {
           _galleryDal.Delete(gallery);
        }

        public void Update(Gallery gallery)
        {
            var roworder = _galleryDal.GetAll().Count();
            gallery.RowOrder = roworder;
            gallery.LastUpdatedAt = DateTime.Now;
            _galleryDal.Update(gallery);
        }
    }
}
