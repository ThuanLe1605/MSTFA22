using MST_Service.Entities;
using MST_Service.Repositories.Interfaces;

namespace MST_Service.Repositories.Implementations
{
    public class GradeSyllabusRepository : Repository<GradeSyllabus>, IGradeSyllabusRepository
    {
        public GradeSyllabusRepository(MstContext context) : base(context)
        {
        }
    }
}
