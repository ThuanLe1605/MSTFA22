using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Interfaces;
using MST_Service.UnitOfWorks;
using MST_Service.ViewModels;
using MST_Service.Entities;
using MST_Service.Repositories.Interfaces;
using MST_Service.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

namespace MST_Service.Servvices.Implementations
{
    public class RoleService: BaseService, IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _roleRepository = unitOfWork.Role;
        }

        public async Task<RoleViewModel> CreateRole(RoleCreateModel role)
        {
            var id = Guid.NewGuid();
            var entry = new Role
            {
                Id = id,
                Name = role.Name,
                Description = role.Description,

            };
            // Add lecture into db context
            _roleRepository.Add(entry);
            // Add lecture into database
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetRole(id);
            }
            return null!;
        }

        public async Task<RoleViewModel> GetRole(Guid id)
        {
            return await _roleRepository
                .GetMany(role => role.Id.Equals(id))
                .Select(role => new RoleViewModel
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description,

                }).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<IEnumerable<RoleViewModel>> GetRoles()
        {
            return await _roleRepository
                .GetAll()
                .Select(role => new RoleViewModel
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description,

                }).ToListAsync();
        }

        public async Task<RoleViewModel> UpdateRole(Guid id, RoleUpdateModel role)
        {
            var currentRole = await _roleRepository.GetMany(currentRole => currentRole.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentRole != null)
            {
                if (role.Name != null) currentRole!.Name = role.Name;
                if (role.Description != null) currentRole!.Description = role.Description;

                _roleRepository.Update(currentRole!);
            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetRole(id);
            }
            return null!;
        }
    }
}
