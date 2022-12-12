using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface IFeedbackService
    {
        Task<IEnumerable<FeedbackViewModel>> GetFeedbacks(string? search);
        Task<FeedbackViewModel> GetFeedback(Guid id);
        Task<FeedbackViewModel> CreateFeedback(FeedbackCreateModel feedback);
        Task<FeedbackViewModel> UpdateFeedback(Guid id, FeedbackUpdateModel feedback);
    }
}
