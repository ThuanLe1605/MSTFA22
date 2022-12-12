using MST_Service.Repositories.Interfaces;

namespace MST_Service.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public ILectureRepository Lecture { get; }

        public IGradeRepository Grade { get; }

        public IAddressRepository Address { get; }

        public IUserRepository User { get; }
        public ISubjectRepository Subject { get; }
        public IRoleRepository Role { get; }
        public IFeedbackRepository Feedback { get; }
        public IPaymentRepository Payment { get; }

        public IDocumentRepository Document { get; }

        public ISlotRepository Slot { get; }
        Task<int> SaveChanges();
    }
}
