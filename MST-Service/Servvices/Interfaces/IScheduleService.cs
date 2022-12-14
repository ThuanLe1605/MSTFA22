using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface IScheduleService
    {
        //Task<IEnumerable<ScheduleViewModel>> GetSchedules();
        Task<IEnumerable<ScheduleViewModel>> GetAllSchedules();
        Task<ScheduleViewModel> GetSchedule(Guid id);
        Task<ScheduleViewModel> CreateSchedule(ScheduleCreateModel schedule);
        Task<ScheduleViewModel> UpdateSchedule(Guid id, ScheduleUpdateModel schedule);
    }
}
