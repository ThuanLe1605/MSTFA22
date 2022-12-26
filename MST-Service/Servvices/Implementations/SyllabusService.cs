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

namespace MST_Service.Servvices.Implementations
{
    public class SyllabusService : BaseService, ISyllabusService
    {
        private readonly ISyllabusRepository _syllabusRepository;

        public SyllabusService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _syllabusRepository = unitOfWork.Syllabus;
        }

        public async Task<SyllabusViewModel> CreateSylabus(SylabusCreateModel syllabus)
        {
            var id = Guid.NewGuid();
            var entry = new Syllabus
            {
                Id = id,
                Name = syllabus.Name,
                Status = syllabus.Status,

            };
            // Add lecture into db context
            _syllabusRepository.Add(entry);
            // Add lecture into database
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetSylabus(id);
            }
            return null!;
        }

        public async Task<SyllabusViewModel> GetSylabus(Guid id)
        {
            return await _syllabusRepository
                .GetMany(syllabus => syllabus.Id.Equals(id))
                .Select(syllabus => new SyllabusViewModel
                {
                    Id = syllabus.Id,
                    Name = syllabus.Name,
                    Status = syllabus.Status,

                }).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<IEnumerable<SyllabusViewModel>> GetSylabuses(string? search)
        {
            return await _syllabusRepository
                .GetMany(syllabus => syllabus.Name!.Contains(search ?? ""))
                //.GetAll()
                .Select(syllabus => new SyllabusViewModel
                {
                    Id = syllabus.Id,
                    Name = syllabus.Name,
                    Status = syllabus.Status,

                }).ToListAsync();
        }

        public async Task<SyllabusViewModel> UpdateSylabus(Guid id, SylabusUpdateModel syllabus)
        {
            var currentSyllabus = await _syllabusRepository.GetMany(currentSyllabus => currentSyllabus.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentSyllabus != null)
            {
                if (syllabus.Name != null) currentSyllabus!.Name = syllabus.Name;
                if (syllabus.Status != null) currentSyllabus!.Status = syllabus.Status;

                _syllabusRepository.Update(currentSyllabus!);
            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetSylabus(id);
            }
            return null!;
        }
    }
}
