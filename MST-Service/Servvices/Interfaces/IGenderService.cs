using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface IGenderService
    {
        Task<IEnumerable<GenderViewModel>> GetGenders();
        Task<GenderViewModel> GetGender(Guid id);
        Task<GenderViewModel> CreateGender(GenderCreateModel gender);
        Task<GenderViewModel> UpdateGender(Guid id, GenderUpdateModel gender);
    }
}
