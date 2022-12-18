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
                //Lecture = new LectureViewModel
                //{
                //    Id = feedback.Lecture.Id,
                //    FirstName = feedback.Lecture.FirstName,
                //    LastName = feedback.Lecture.LastName,
                //    AvatarUrl = feedback.Lecture.AvatarUrl,
                //    Bio = feedback.Lecture.Bio,
                //    Price = feedback.Lecture.Price,
                //},
                //User = new UserViewModel
                //{
                //    Id = feedback.User.Id,
                //    Username = feedback.User.Username,
                //    Email = feedback.User.Email,
                //    AvatarUrl = feedback.User.AvatarUrl,
                //    FirstName = feedback.User.FirstName,
                //    LastName = feedback.User.LastName,
                //},

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
            return await _feedbackRepository
                .GetMany(feedback => feedback.Id.Equals(id))
                .Select(feedback => new FeedbackViewModel
                {
                    Id = feedback.Id,
                    Content = feedback.Content,
                    Star = feedback.Star,
                    Lecture = new LectureViewModel
                    {
                        Id = feedback.Lecture.Id,
                        FirstName = feedback.Lecture.FirstName,
                        LastName = feedback.Lecture.LastName,
                        AvatarUrl = feedback.Lecture.AvatarUrl,
                        Bio = feedback.Lecture.Bio,
                        Price = feedback.Lecture.Price,
                    },
                    User = new UserViewModel
                    {
                        Id = feedback.User.Id,
                        Username = feedback.User.Username,
                        Email = feedback.User.Email,
                        AvatarUrl = feedback.User.AvatarUrl,
                        FirstName = feedback.User.FirstName,
                        LastName = feedback.User.LastName,
                    },
                }).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<IEnumerable<FeedbackViewModel>> GetFeedbacks(string? search)
        {
            return await _feedbackRepository
                .GetMany(feedback => feedback.Content!.Contains(search!))
                .Select(feedback => new FeedbackViewModel
                {
                    Id = feedback.Id,
                    Content = feedback.Content,
                    Star = feedback.Star,
                    Lecture = new LectureViewModel
                    {
                        Id = feedback.Lecture.Id,
                        FirstName = feedback.Lecture.FirstName,
                        LastName = feedback.Lecture.LastName,
                        AvatarUrl = feedback.Lecture.AvatarUrl,
                        Bio = feedback.Lecture.Bio,
                        Price = feedback.Lecture.Price,
                    },
                    User = new UserViewModel
                    {
                        Id = feedback.User.Id,
                        Username = feedback.User.Username,
                        Email = feedback.User.Email,
                        AvatarUrl = feedback.User.AvatarUrl,
                        FirstName = feedback.User.FirstName,
                        LastName = feedback.User.LastName,
                    },
                }).ToListAsync();
        }

        public async Task<FeedbackViewModel> UpdateFeedback(Guid id, FeedbackUpdateModel feedback)
        {
            var currentFeedback = await _feedbackRepository.GetMany(currentFeedback => currentFeedback.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentFeedback != null)
            {
                if (feedback.Content is not null) currentFeedback!.Content = feedback.Content;
                if (feedback.Star is not null) currentFeedback!.Star = (double)feedback.Star;

                _feedbackRepository.Update(currentFeedback!);

            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetFeedback(id);
            }
            return null!;
        }
    }
}
