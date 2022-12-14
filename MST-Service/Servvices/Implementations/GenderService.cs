using Microsoft.EntityFrameworkCore;
using MST_Service.Entities;
using MST_Service.Repositories.Implementations;
using MST_Service.Repositories.Interfaces;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Interfaces;
using MST_Service.UnitOfWorks;
using MST_Service.ViewModels;
using System.Data;
using System.Reflection;

namespace MST_Service.Servvices.Implementations
{
    public class GenderService : BaseService, IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _genderRepository = unitOfWork.Gender;
        }

        public async Task<GenderViewModel> CreateGender(GenderCreateModel gender)
        {
            var id = Guid.NewGuid();
            var entry = new Gender
            {
                Id = id,
                Name = gender.Name,               

            };
            // Add lecture into db context
            _genderRepository.Add(entry);
            // Add lecture into database
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetGender(id);
            }
            return null!;
        }

        public async Task<GenderViewModel> GetGender(Guid id)
        {
            return await _genderRepository
                .GetMany(gender => gender.Id.Equals(id))
                .Select(gender => new GenderViewModel
                {
                    Id = gender.Id,
                    Name = gender.Name,

                }).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<IEnumerable<GenderViewModel>> GetGenders()
        {
            return await _genderRepository
                .GetAll()
                .Select(gender => new GenderViewModel
                {
                    Id = gender.Id,
                    Name = gender.Name,

                }).ToListAsync();
        }

        public async Task<GenderViewModel> UpdateGender(Guid id, GenderUpdateModel gender)
        {
            var currentGender = await _genderRepository.GetMany(currentGender => currentGender.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentGender != null)
            {
                if (gender.Name != null) currentGender!.Name = gender.Name;

                _genderRepository.Update(currentGender!);
            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetGender(id);
            }
            return null!;
        }
    }
}
