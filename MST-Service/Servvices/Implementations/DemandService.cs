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
    public class DemandService : BaseService, IDemandService
    {
        private readonly IDemandRepository _demandRepository;

        public DemandService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _demandRepository = unitOfWork.Demand;
        }

        public async Task<DemandViewModel> CreateDemand(DemandCreateModel demand)
        {
            var id = Guid.NewGuid();
            var entry = new Demand
            {
                Id = id,
                Status = demand.Status,
                GenderId = demand.GenderId,
                GradeId = demand.GradeId,
                SubjectId = demand.SubjectId,
                SyllabusId = demand.SyllabusId,
            };
            // Add demand into db context
            _demandRepository.Add(entry);
            // Add demand into database
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetDemand(id);
            }
            return null!;
        }

        public async Task<IEnumerable<DemandViewModel>> GetDemands(string? search, Guid? genderId, Guid? subjectId, Guid? gradeId, Guid? syllabusId)
        {
            return await _demandRepository
                .GetMany(demand => demand.Status!.Contains(search ?? "") || demand.GenderId!.Equals(genderId!) || demand.SubjectId!.Equals(subjectId!) || demand.GradeId!.Equals(gradeId) || demand.SyllabusId!.Equals(syllabusId))
                .Select(demand => new DemandViewModel
                {
                    Id = demand.Id,
                    Status = demand.Status,
                    //GenderId = demand.GenderId,
                    //GradeId = demand.GradeId,
                    //SubjectId = demand.SubjectId,
                    //SyllabusId = demand.SyllabusId,
                    Gender = new GenderViewModel
                    {
                        Id= demand.Gender!.Id,
                        Name= demand.Gender.Name,
                    },
                    Grade = new GradeViewModel
                    {
                        Id= demand.Grade.Id,
                        Name= demand.Grade.Name,
                        Description= demand.Grade.Description,
                    },
                    Subject = new SubjectViewModel
                    {
                        Id= demand.Subject.Id,
                        Name= demand.Subject.Name,
                        Description= demand.Subject.Description,
                    },
                    Syllabus = new SyllabusViewModel
                    {
                        Id = demand.Syllabus.Id,
                        Name = demand.Syllabus.Name,
                        Status = demand.Syllabus.Status,
                    },
                }).ToListAsync();
        }
        public async Task<DemandViewModel> GetDemand(Guid id)
        {
            return await _demandRepository
                .GetMany(demand => demand.Id.Equals(id))
                .Select(demand => new DemandViewModel
                {
                    Id = demand.Id,
                    Status = demand.Status,
                    //GenderId = demand.GenderId,
                    //GradeId = demand.GradeId,
                    //SubjectId = demand.SubjectId,
                    //SyllabusId = demand.SyllabusId,
                    Gender = new GenderViewModel
                    {
                        Id = demand.Gender!.Id,
                        Name = demand.Gender.Name,
                    },
                    Grade = new GradeViewModel
                    {
                        Id = demand.Grade.Id,
                        Name = demand.Grade.Name,
                        Description = demand.Grade.Description,
                    },
                    Subject = new SubjectViewModel
                    {
                        Id = demand.Subject.Id,
                        Name = demand.Subject.Name,
                        Description = demand.Subject.Description,
                    },
                    Syllabus = new SyllabusViewModel
                    {
                        Id = demand.Syllabus.Id,
                        Name = demand.Syllabus.Name,
                        Status = demand.Syllabus.Status,
                    },
                }).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<DemandViewModel> UpdateDemand(Guid id, DemandUpdateModel demand)
        {
            var currentDemand = await _demandRepository.GetMany(currentDemand => currentDemand.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentDemand != null)
            {
                if (demand.Status is not null) currentDemand!.Status = demand.Status;

                if (demand.GradeId != null)
                {
                    currentDemand!.GradeId = (Guid)demand.GradeId;
                }
                if (demand.SubjectId != null)
                {
                    currentDemand!.SubjectId = (Guid)demand.SubjectId;
                }
                if (demand.SyllabusId != null)
                {
                    currentDemand!.SyllabusId = (Guid)demand.SyllabusId;
                }

                _demandRepository.Update(currentDemand!);

            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetDemand(id);
            }
            return null!;
        }

    }
}
