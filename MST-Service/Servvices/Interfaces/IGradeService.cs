using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface IGradeService
    {
        Task<IEnumerable<GradeViewModel>> GetGrades(string? search);
        Task<GradeViewModel> GetGrade(Guid id);
        Task<GradeViewModel> CreateGrade(GradeCreateModel grade);
        Task<GradeViewModel> UpdateGrade(Guid id, GradeUpdateModel grade);
    }
}
