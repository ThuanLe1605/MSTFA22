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
        public IGenderRepository Gender { get; }
        public IDemandRepository Demand { get; }
        public IScheduleRepository Schedule { get; }
        public ISyllabusRepository Syllabus { get;  }
        public IPromotionRepository Promotion { get;  }
        public ITransactionRepository Transaction { get; }
        public IWalletRepository Wallet { get; }
        public IEventRepository Event { get; }
        public IBookingRepository Booking { get; }
        public IBookingStatusRepository BookingStatus { get; }
        Task<int> SaveChanges();
    }
}
