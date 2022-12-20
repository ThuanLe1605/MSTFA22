using MST_Service.Entities;
using MST_Service.Repositories.Interfaces;

namespace MST_Service.Repositories.Implementations
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(MstContext context) : base(context)
        {
        }
    }
}
