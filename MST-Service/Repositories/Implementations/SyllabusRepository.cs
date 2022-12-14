using MST_Service.Entities;
using MST_Service.Repositories.Interfaces;

namespace MST_Service.Repositories.Implementations
{
    public class SyllabusRepository : Repository<Syllabus>, ISyllabusRepository
    {
        public SyllabusRepository(MstContext context) : base(context)
        {
        }
    }
}
