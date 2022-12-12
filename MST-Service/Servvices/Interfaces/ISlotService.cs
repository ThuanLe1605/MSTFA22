using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface ISlotService
    {
        Task<IEnumerable<SlotViewModel>> GetSlots();
        Task<SlotViewModel> GetSlot(Guid id);
        Task<SlotViewModel> CreateSlot(SlotCreateModel slot);
        Task<SlotViewModel> UpdateSlot(Guid id, SlotUpdateModel slot);
    }
}
