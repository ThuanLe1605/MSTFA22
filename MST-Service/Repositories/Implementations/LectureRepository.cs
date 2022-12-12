using MST_Service.Entities;
using MST_Service.Repositories.Interfaces;

namespace MST_Service.Repositories.Implementations
{
    public class LectureRepository : Repository<Lecture>, ILectureRepository
    {
        public LectureRepository(MstContext context) : base(context)
        {
        }
    }
}
