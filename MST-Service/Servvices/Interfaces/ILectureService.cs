using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface ILectureService
{
        Task<IEnumerable<LectureViewModel>> GetLectures(string? search);
        Task<LectureViewModel> GetLecture(Guid id);
        Task<LectureViewModel> CreateLecture(LectureCreateModel lecture);
        Task<LectureViewModel> UpdateLecture(Guid id, LectureUpdateModel lecture);
    }
}
