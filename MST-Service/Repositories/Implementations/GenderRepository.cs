using MST_Service.Entities;
using MST_Service.Repositories.Interfaces;

namespace MST_Service.Repositories.Implementations
{
    public class GenderRepository : Repository<Gender>, IGenderRepository
    {
        public GenderRepository(MstContext context) : base(context)
        {
        }
    }
}
