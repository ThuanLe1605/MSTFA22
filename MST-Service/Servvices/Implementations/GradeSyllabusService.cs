using MST_Service.Repositories.Interfaces;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Interfaces;
using MST_Service.UnitOfWorks;
using MST_Service.ViewModels;
using MST_Service.Entities;
using MST_Service.Repositories.Implementations;


namespace MST_Service.Servvices.Implementations
{
    public class GradeSyllabusService : BaseService, IGradeSyllabusService
    {
        private readonly IGradeSyllabusRepository _gradeSyllabusRepository;

        public GradeSyllabusService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //_gradeSyllabusRepository = unitOfWork.GradeSyllabus;
        }

        //public async Task<GradeSyllabusViewModel> CreateGradeSyllabus(GradeSyllabusCreateModel gradeSyllabus)
        //{
        //    var entry = new GradeSyllabus
        //    {
        //        GradeId = gradeSyllabus.GradeId,
        //        SyllabusId = gradeSyllabus.SyllabusId,
        //        Ratio = gradeSyllabus.Ratio,

        //    };
        //    // Add lecture into db context
        //    _gradeSyllabusRepository.Add(entry);
        //    // Add lecture into database
        //    var result = await _unitOfWork.SaveChanges();
        //    if (result > 0)
        //    {
        //        //return await GetGradeSyllabus();
        //    }
        //    return null!;
        //}

        //public Task<GradeSyllabusViewModel> GetGradeSyllabus(Guid id)
        //{
        //    return await _gradeSyllabusRepository
        //        .GetMany(gradeSyllabus => gradeSyllabus.Id.Equals(id))
        //        .Select(gradeSyllabus => new GradeSyllabusViewModel
        //        {
        //            Ratio = gradeSyllabus.Ratio,
        //            Grade = new GradeViewModel
        //            {

        //            },
        //            Syllabus = new SyllabusViewModel
        //            {

        //            },
        //        }).FirstOrDefaultAsync() ?? null!;
        //}

        //public Task<IEnumerable<GradeSyllabusViewModel>> GetGradeSyllabuses(string? search)
        //{
        //    return await _gradeSyllabusRepository
        //        .GetMany(gradeSyllabus => gradeSyllabus.Name!.Contains(search!))
        //        .Select(grade => new GradeSyllabusViewModel
        //        {
        //            Id = grade.Id,
        //            Name = grade.Name,
        //            Description = grade.Description,
        //        }).ToListAsync();
        //}

        //public Task<GradeSyllabusViewModel> UpdateGradeSyllabus(Guid id, GradeSyllabusUpdateModelcs gradeSyllabus)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
