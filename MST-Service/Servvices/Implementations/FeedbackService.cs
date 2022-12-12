using MST_Service.Repositories.Implementations;
using MST_Service.Servvices.Interfaces;
using MST_Service.Entities;
using MST_Service.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using MST_Service.ViewModels;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Repositories.Interfaces;

namespace MST_Service.Servvices.Implementations
{
    public class FeedbackService : BaseService, IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _feedbackRepository = unitOfWork.Feedback;
        }

        public async Task<FeedbackViewModel> CreateFeedback(FeedbackCreateModel feedback)
        {
            var id = Guid.NewGuid();
            var entry = new Feedback
            {
                Id = id,
                Content = feedback.Content,
                Star = feedback.Star,
                //Lecture = new Lecture
                //{
                //    Id = feedback.id,

                   
                //}
            };
            // Add lecture into db context
            _feedbackRepository.Add(entry);
            // Add lecture into database
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetFeedback(id);
            }
            return null!;
        }

        public async Task<FeedbackViewModel> GetFeedback(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FeedbackViewModel>> GetFeedbacks(string? search)
        {
            throw new NotImplementedException();
        }

        public async Task<FeedbackViewModel> UpdateFeedback(Guid id, FeedbackUpdateModel feedback)
        {
            throw new NotImplementedException();
        }
    }
}
