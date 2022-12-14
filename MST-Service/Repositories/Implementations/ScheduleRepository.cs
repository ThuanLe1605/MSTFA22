using MST_Service.Entities;
using MST_Service.Repositories.Interfaces;

namespace MST_Service.Repositories.Implementations
{
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(MstContext context) : base(context)
        {
        }
    }
}
