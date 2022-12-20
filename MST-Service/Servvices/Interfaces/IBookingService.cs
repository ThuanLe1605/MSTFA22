using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingViewModel>> GetBookings(string? search);
        Task<BookingViewModel> GetBooking(Guid id);
        Task<BookingViewModel> CreateBooking(BookingCreateModel booking);
        Task<BookingViewModel> UpdateBooking(Guid id, BookingUpdateModel booking);
    }
}
