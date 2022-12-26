using Microsoft.EntityFrameworkCore;
using MST_Service.Entities;
using MST_Service.Repositories.Interfaces;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Interfaces;
using MST_Service.UnitOfWorks;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Implementations
{
    public class LectureService : BaseService, ILectureService
    {
        private readonly ILectureRepository _lectureRepository;

        public LectureService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _lectureRepository = unitOfWork.Lecture;
        }

        public async Task<IEnumerable<LectureViewModel>> GetLectures(string? search)
        {
            return await _lectureRepository
                .GetMany(lecture => lecture.FirstName!.Contains(search ?? "") || lecture.LastName!.Contains(search ?? ""))
                .Select(lecture => new LectureViewModel
                {
                    Id = lecture.Id,
                    AvatarUrl = lecture.AvatarUrl,
                    FirstName = lecture.FirstName,
                    Gender = new GenderViewModel
                    {
                        Id = lecture.Gender!.Id,
                        Name = lecture.Gender.Name
                    },
                    LastName = lecture.LastName,
                    Price = lecture.Price,
                    Status = lecture.Status,
                    Bio = lecture.Bio
                }).ToListAsync();
        }

        public async Task<LectureViewModel> GetLecture(Guid id)
        {
            return await _lectureRepository
                .GetMany(lecture => lecture.Id.Equals(id))
                .Select(lecture => new LectureViewModel
                {
                    Id = lecture.Id,
                    AvatarUrl = lecture.AvatarUrl,
                    FirstName = lecture.FirstName,
                    Gender = new GenderViewModel
                    {
                        Id = lecture.Gender!.Id,
                        Name = lecture.Gender.Name
                    },
                    LastName = lecture.LastName,
                    Price = lecture.Price,
                    Status = lecture.Status,
                    Bio = lecture.Bio
                }).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<LectureViewModel> CreateLecture(LectureCreateModel lecture)
        {
            var id = Guid.NewGuid();
            var entry = new Lecture
            {
                Id = id,
                AvatarUrl = lecture.AvatarUrl,
                Bio = lecture.Bio,
                GenderId = lecture.GenderId,
                LastName = lecture.LastName,
                FirstName = lecture.FirstName,
                Price = lecture.Price,
                Status = true,
            };
            // Add lecture into db context
            _lectureRepository.Add(entry);
            // Add lecture into database
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetLecture(id);
            }
            return null!;
        }

        public async Task<LectureViewModel> UpdateLecture(Guid id, LectureUpdateModel lecture)
        {
            var currentLecture = await _lectureRepository.GetMany(currentLecture => currentLecture.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentLecture != null)
            {
                if (lecture.FirstName is not null) currentLecture!.FirstName = lecture.FirstName;
                if (lecture.LastName is not null) currentLecture!.LastName = lecture.LastName;
                if (lecture.AvatarUrl is not null) currentLecture!.AvatarUrl = lecture.AvatarUrl;
                if (lecture.Bio is not null) currentLecture!.Bio = lecture.Bio;
                if (lecture.Price is not null) currentLecture!.Price = (double)lecture.Price;
                //if (lecture.Gender.Name is not null) currentLecture!.Gender.Name = lecture.Gender.Name;
                // more...

                _lectureRepository.Update(currentLecture!);

            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetLecture(id);
            }
            return null!;
        }

    }
}
