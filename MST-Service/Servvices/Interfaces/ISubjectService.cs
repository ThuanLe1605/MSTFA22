using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectViewModel>> GetSubjects(string? search);
        Task<SubjectViewModel> GetSubject(Guid id);
        Task<SubjectViewModel> CreateSubject(SubjectCreateModel subject);
        Task<SubjectViewModel> UpdateSubject(Guid id, SubjectUpdateModel subject);
    }
}
