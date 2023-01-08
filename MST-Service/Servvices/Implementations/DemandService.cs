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
                Address = demand.Address,
                StartDate = demand.StartDate,
                EndDate = demand.EndDate,
                Monday = (bool)demand.Monday,
                Tuesday = (bool)demand.Tuesday,
                Wednesday = (bool)demand.Wednesday,
                Thursday = (bool)demand.Thursday,
                Friday = (bool)demand.Friday,
                Saturday = (bool)demand.Saturday,
                Sunday = (bool)demand.Sunday,
                LectureId = demand.LectureId,
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

        public async Task<IEnumerable<DemandViewModel>> GetDemands(string? search, Guid? lectureId, Guid? genderId, Guid? subjectId, Guid? gradeId, Guid? syllabusId)
        {
            return await _demandRepository
                .GetMany(demand => demand.Status!.Contains(search ?? "") || demand.Address!.Contains(search ?? "") || demand.GenderId!.Equals(genderId!) || demand.SubjectId!.Equals(subjectId!) || demand.GradeId!.Equals(gradeId) || demand.SyllabusId!.Equals(syllabusId))
                .Select(demand => new DemandViewModel
                {
                    Id = demand.Id,
                    Status = demand.Status,
                    Address = demand.Address,
                    StartDate = demand.StartDate,
                    EndDate = demand.EndDate,
                    Monday = (bool)demand.Monday,
                    Tuesday = (bool)demand.Tuesday,
                    Wednesday = (bool)demand.Wednesday,
                    Thursday = (bool)demand.Thursday,
                    Friday = (bool)demand.Friday,
                    Saturday = (bool)demand.Saturday,
                    Sunday = (bool)demand.Sunday,
                    Lecture = new LectureViewModel
                    {
                        Id = demand.Lecture!.Id,
                        FirstName = demand.Lecture.FirstName,
                        LastName = demand.Lecture.LastName,
                        AvatarUrl = demand.Lecture.AvatarUrl,
                        Bio = demand.Lecture.Bio,
                        Price = demand.Lecture.Price,
                    },
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
                    Address = demand.Address,
                    StartDate = demand.StartDate,
                    EndDate = demand.EndDate,
                    Monday = (bool)demand.Monday,
                    Tuesday = (bool)demand.Tuesday,
                    Wednesday = (bool)demand.Wednesday,
                    Thursday = (bool)demand.Thursday,
                    Friday = (bool)demand.Friday,
                    Saturday = (bool)demand.Saturday,
                    Sunday = (bool)demand.Sunday,
                    Lecture = new LectureViewModel
                    {
                        Id = demand.Lecture!.Id,
                        FirstName = demand.Lecture.FirstName,
                        LastName = demand.Lecture.LastName,
                        AvatarUrl = demand.Lecture.AvatarUrl,
                        Bio = demand.Lecture.Bio,
                        Price = demand.Lecture.Price,
                    },
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
                if (demand.GenderId!= null)
                {
                    currentDemand!.GenderId = (Guid)demand.GenderId;
                }
                if(demand.StartDate!= null)
                {
                    currentDemand!.StartDate = (DateTime)demand.StartDate;
                }
                if (demand.EndDate != null)
                {
                    currentDemand!.EndDate = (DateTime)demand.EndDate;
                }
                
                if(demand.Monday != null) currentDemand!.Monday = (bool)demand.Monday;
                if(demand.Tuesday != null) currentDemand!.Tuesday = (bool)demand.Tuesday;
                if(demand.Wednesday != null) currentDemand!.Wednesday = (bool)demand.Wednesday;
                if(demand.Thursday != null) currentDemand!.Thursday = (bool)demand.Thursday;
                if(demand.Friday != null) currentDemand!.Friday = (bool)demand.Friday;
                if(demand.Saturday != null) currentDemand!.Saturday = (bool)demand.Saturday;
                if(demand.Sunday != null) currentDemand!.Sunday = (bool)demand.Sunday;

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
