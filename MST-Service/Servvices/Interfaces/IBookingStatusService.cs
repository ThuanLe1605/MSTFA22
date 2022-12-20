using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface IBookingStatusService
    {
        Task<IEnumerable<BookingStatusViewModel>> GetBookingStatuses(string? search);
        Task<BookingStatusViewModel> GetBookingStatus(Guid id);
        Task<BookingStatusViewModel> CreateBookingStatus(BookingStatusCreateModel bkstatus);
        Task<BookingStatusViewModel> UpdateBookingStatus(Guid id, BookingStatusUpdateModel bkstatus);
    }
}
