using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventViewModel>> GetEvents(string? search);
        Task<EventViewModel> GetEvent(Guid id);
        Task<EventViewModel> CreateEvent(EventCreateModel events);
        Task<EventViewModel> UpdateEvent(Guid id, EventUpdateModel events);

    }
}
