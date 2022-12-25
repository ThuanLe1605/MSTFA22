using Microsoft.EntityFrameworkCore;
using MST_Service.Entities;
using MST_Service.Repositories.Implementations;
using MST_Service.Repositories.Interfaces;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Interfaces;
using MST_Service.UnitOfWorks;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Implementations
{
    public class SubjectService : BaseService, ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _subjectRepository = unitOfWork.Subject;
        }

        public async Task<IEnumerable<SubjectViewModel>> GetSubjects(string? search)
        {
            return await _subjectRepository
                .GetMany(subject => subject.Name!.Contains(search ?? "") || subject.Description!.Contains(search ?? ""))
                //.GetAll()
                .Select(subject => new SubjectViewModel
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    Description = subject.Description,

                }).ToListAsync();
        }

        public async Task<SubjectViewModel> GetSubject(Guid id)
        {
            return await _subjectRepository
                .GetMany(subject => subject.Id.Equals(id))
                .Select(subject => new SubjectViewModel
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    Description = subject.Description,

                }).FirstOrDefaultAsync() ?? null!;
        }


        public async Task<SubjectViewModel> CreateSubject(SubjectCreateModel subject)
        {
            var id = Guid.NewGuid();
            var entry = new Subject
            {
                Id = id,
                Name = subject.Name,
                Description = subject.Description,

            };
            // Add lecture into db context
            _subjectRepository.Add(entry);
            // Add lecture into database
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetSubject(id);
            }
            return null!;
        }


        public async Task<SubjectViewModel> UpdateSubject(Guid id, SubjectUpdateModel subject)
        {
            var currentSubject = await _subjectRepository.GetMany(currentSubject => currentSubject.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentSubject != null)
            {
                if (subject.Name != null) currentSubject!.Name = subject.Name;
                if (subject.Description != null) currentSubject!.Description = subject.Description;

                _subjectRepository.Update(currentSubject!);
            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetSubject(id);
            }
            return null!;
        }

        public async Task<bool> RemoveSubject(Guid id)
        {
            if (CheckExist(id))
            {
                var subject = await _subjectRepository.GetMany(subject => subject.Id.Equals(id)).FirstOrDefaultAsync();
                if (subject != null)
                {
                    _subjectRepository.Remove(subject);
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
            return _subjectRepository.Any(x => x.Id == id);
        }
    }
}
