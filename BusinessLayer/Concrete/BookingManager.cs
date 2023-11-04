using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class BookingManager : IBookingManager
    {

        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void Add(Booking booking)
        {
            var roworder = _bookingDal.GetAll().Count();
           booking.RowOrder = roworder + 1;

            _bookingDal.Add(booking);
        }

        public Booking GetByID(int id)
        {
            return _bookingDal.Get(id);
        }

        public List<Booking> GetList()
        {
            return _bookingDal.GetAll();
        }

        public void Remove(Booking booking)
        {
           _bookingDal.Delete(booking);
        }

        public void Update(Booking booking)
        {
            var roworder = _bookingDal.GetAll().Count();
           booking.RowOrder = roworder;
            _bookingDal.Update(booking);
        }
    }
}
