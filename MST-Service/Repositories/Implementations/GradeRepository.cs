using MST_Service.Entities;
using MST_Service.Repositories.Interfaces;

namespace MST_Service.Repositories.Implementations
{
    public class GradeRepository : Repository<Grade>, IGradeRepository
    {
        public GradeRepository(MstContext context) : base(context)
        {
        }
    }
}
