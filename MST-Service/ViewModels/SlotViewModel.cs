using MST_Service.Entities;

namespace MST_Service.ViewModels
{
    public class SlotViewModel
    {
        public Guid Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        //public virtual ICollection<Schedule> Schedules { get; } = new List<Schedule>();
    }
}
