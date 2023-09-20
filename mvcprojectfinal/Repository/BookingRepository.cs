using mvcprojectfinal.Models;

namespace mvcprojectfinal.Repository
{
    public class BookingRepository :IBookingRepository
    {
        Context context;
        public BookingRepository(Context _context)
        {
            context = _context;

        }



        public void Insert(Booking booking)
        {
            context.booking.Add(booking);
            context.SaveChanges();
        }
    }
}
