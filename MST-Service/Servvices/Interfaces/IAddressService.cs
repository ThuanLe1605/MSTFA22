using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressViewModel>> GetAddresses(string? searchLocation);
        Task<AddressViewModel> GetAddress(Guid id);
        Task<AddressViewModel> CreateAddress(AddressCreateModel address);
        Task<AddressViewModel> UpdateAddress(Guid id, AddressUpdateModel address);
    }
}
