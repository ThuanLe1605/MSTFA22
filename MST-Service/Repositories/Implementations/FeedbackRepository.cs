using MST_Service.Entities;
using MST_Service.Repositories.Interfaces;

namespace MST_Service.Repositories.Implementations
{
    public class FeedbackRepository: Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(MstContext context) : base(context)
        {
        }
    }
}
