using MST_Service.RequestModels.Internal;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface IAuthService
    {
        Task<UserViewModel> AuthenticatedUser(AuthRequest auth);
        Task<AuthViewModel> GetUserById(Guid id);
    }
}
