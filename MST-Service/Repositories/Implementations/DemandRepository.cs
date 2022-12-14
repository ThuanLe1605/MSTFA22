using MST_Service.Entities;
using MST_Service.Repositories.Interfaces;

namespace MST_Service.Repositories.Implementations
{
    public class DemandRepository : Repository<Demand>, IDemandRepository
    {
        public DemandRepository(MstContext context) : base(context)
        {
        }
    }
}
