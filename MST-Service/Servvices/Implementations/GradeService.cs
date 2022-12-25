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
    public class GradeService : BaseService, IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        public GradeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _gradeRepository = unitOfWork.Grade;
        }

        public async Task<GradeViewModel> CreateGrade(GradeCreateModel grade)
        {
            var id = Guid.NewGuid();
            var entry = new Grade
            {
                Id = id,
                Name= grade.Name,
                Description = grade.Description,
                    
            };
            // Add lecture into db context
            _gradeRepository.Add(entry);
            // Add lecture into database
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetGrade(id);
            }
            return null!;
        }

        public async Task<GradeViewModel> GetGrade(Guid id)
        {
            return await _gradeRepository
                .GetMany(grade => grade.Id.Equals(id))
                .Select(grade => new GradeViewModel
                {
                    Id = grade.Id,
                    Name = grade.Name,
                    Description = grade.Description,
                }).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<IEnumerable<GradeViewModel>> GetGrades(string? search)
        {
            return await _gradeRepository
                .GetMany(grade => grade.Name!.Contains(search!) || grade.Description!.Contains(search!))
                .Select(grade => new GradeViewModel
                {
                    Id = grade.Id,
                    Name = grade.Name,
                    Description = grade.Description,
                }).ToListAsync();
        }
        
        public async Task<GradeViewModel> UpdateGrade(Guid id, GradeUpdateModel grade)
        {
            var currentGrade = await _gradeRepository.GetMany(currentGrade => currentGrade.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentGrade != null)
            {
                if (grade.Name != null) currentGrade!.Name = grade.Name;
                if (grade.Description != null) currentGrade!.Description = grade.Description;
                _gradeRepository.Update(currentGrade!);
            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetGrade(id);
            }
            return null!;
        }

        public async Task<bool> RemoveGrade(Guid id)
        {
            if (CheckExist(id))
            {
                var grade = await _gradeRepository.GetMany(grade => grade.Id.Equals(id)).FirstOrDefaultAsync();
                if (grade != null)
                {
                    _gradeRepository.Remove(grade);
                    var result = await _unitOfWork.SaveChanges();
                    if (result > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckExist(Guid id)
        {
            return _gradeRepository.Any(x => x.Id == id);
        }
    }
}
