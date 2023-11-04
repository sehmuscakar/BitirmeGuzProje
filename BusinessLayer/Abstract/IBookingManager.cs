using DataAccessLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface IBookingManager
    {
        List<Booking> GetList();
        void Add(Booking booking);
        void Update(Booking booking);
        void Remove(Booking booking);
        Booking GetByID(int id);
    }
}
