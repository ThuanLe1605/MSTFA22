using Microsoft.EntityFrameworkCore;
using MST_Service.Entities;
using MST_Service.Repositories.Interfaces;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Interfaces;
using MST_Service.UnitOfWorks;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Implementations
{
    public class ScheduleService : BaseService, IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _scheduleRepository = unitOfWork.Schedule;
        }

        //public async Task<IEnumerable<ScheduleViewModel>> GetSchedules()
        //{
        //    return await _scheduleRepository
        //        .GetMany(schedule => schedule.SlotId!.Equals(""))
        //        .Select(schedule => new ScheduleViewModel
        //        {
        //            Id = schedule.Id,

        //        }).ToListAsync();
        //}
        public async Task<IEnumerable<ScheduleViewModel>> GetAllSchedules()
        {
            return await _scheduleRepository
                .GetAll()
                .Select(schedule => new ScheduleViewModel
                {
                    Id = schedule.Id,
                    SlotId = schedule.SlotId,
                    LectureId = schedule.LectureId,
                    Slot = new SlotViewModel
                    {
                        
                        StartTime = schedule.Slot.StartTime,
                        EndTime = schedule.Slot.EndTime,
                    },
                    Subject = new SubjectViewModel
                    {
                        Id = schedule.Subject.Id,
                        Name = schedule.Subject.Name,
                        Description = schedule.Subject.Description,
                    }

                }).ToListAsync();
        }

        public async Task<ScheduleViewModel> GetSchedule(Guid id)
        {
            return await _scheduleRepository
                .GetMany(schedule => schedule.Id.Equals(id))
                .Select(schedule => new ScheduleViewModel
                {
                    Id = schedule.Id,
                    SlotId = schedule.SlotId,
                    LectureId = schedule.LectureId,
                    Slot = new SlotViewModel
                    {
                        
                        StartTime = schedule.Slot.StartTime,
                        EndTime = schedule.Slot.EndTime,
                    },
                    Subject = new SubjectViewModel
                    {
                        Id = schedule.Subject.Id,
                        Name = schedule.Subject.Name,
                        Description = schedule.Subject.Description,
                    }
                }).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<ScheduleViewModel> CreateSchedule(ScheduleCreateModel schedule)
        {
            var id = Guid.NewGuid();
            var entry = new Schedule
            {
                Id = id,
                SlotId = schedule.SlotId,
                LectureId = schedule.LectureId,
                SubjectId = schedule.SubjectId,
            };
            // Add schedule into db context
            _scheduleRepository.Add(entry);
            // Add schedule into database
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetSchedule(id);
            }
            return null!;
        }

        public async Task<ScheduleViewModel> UpdateSchedule(Guid id, ScheduleUpdateModel schedule)
        {
            var currentSchedule = await _scheduleRepository.GetMany(currentSchedule => currentSchedule.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentSchedule != null)
            {
                if (schedule.LectureId != null) currentSchedule!.LectureId = (Guid)schedule.LectureId;
                if (schedule.SlotId != null) currentSchedule!.SlotId = (Guid)schedule.SlotId;
                if (schedule.SubjectId != null) currentSchedule!.SubjectId = (Guid)schedule.SubjectId;
                if (schedule.UserId != null) currentSchedule!.UserId = (Guid)schedule.UserId;
                // more...

                _scheduleRepository.Update(currentSchedule!);

            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetSchedule(id);
            }
            return null!;
        }
    }
}
