using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleViewModel>> GetRoles();
        Task<RoleViewModel> GetRole(Guid id);
        Task<RoleViewModel> CreateRole(RoleCreateModel role);
        Task<RoleViewModel> UpdateRole(Guid id, RoleUpdateModel role);
    }
}
