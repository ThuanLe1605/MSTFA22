using MST_Service.Entities;
using MST_Service.Repositories.Interfaces;

namespace MST_Service.Repositories.Implementations
{
    public class SlotRepository : Repository<Slot>, ISlotRepository
    {
        public SlotRepository(MstContext context) : base(context)
        {
        }
    }
}
