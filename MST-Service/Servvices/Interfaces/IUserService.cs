using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetUsers(string? search);
        Task<UserViewModel> GetUser(Guid id);
        Task<UserViewModel> CreateUser(UserCreateModel user);
        Task<UserViewModel> UpdateUser(Guid id, UserUpdateModel user);
    }
}
