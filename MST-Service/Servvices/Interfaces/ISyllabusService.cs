using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface ISyllabusService
    {
        Task<IEnumerable<SyllabusViewModel>> GetSylabuses(string? search);
        Task<SyllabusViewModel> GetSylabus(Guid id);
        Task<SyllabusViewModel> CreateSylabus(SylabusCreateModel syllabus);
        Task<SyllabusViewModel> UpdateSylabus(Guid id, SylabusUpdateModel syllabus);
    }
}
