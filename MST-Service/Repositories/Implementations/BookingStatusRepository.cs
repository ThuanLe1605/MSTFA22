using MST_Service.Entities;
using MST_Service.Repositories.Interfaces;

namespace MST_Service.Repositories.Implementations
{
    public class BookingStatusRepository : Repository<BookingStatus>, IBookingStatusRepository
    {
        public BookingStatusRepository(MstContext context) : base(context)
        {
        }
    }
}
