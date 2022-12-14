using MST_Service.Entities;
using MST_Service.Repositories.Interfaces;

namespace MST_Service.Repositories.Implementations
{
    public class PromotionRepository : Repository<Promotion>, IPromotionRepository
    {
        public PromotionRepository(MstContext context) : base(context)
        {
        }
    }
}
