using MST_Service.Entities;
using MST_Service.Repositories.Implementations;
using MST_Service.Repositories.Interfaces;

namespace MST_Service.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MstContext _context;

        public UnitOfWork(MstContext context)
        {
            _context = context;
        }

        private ILectureRepository _lecture = null!;

        public ILectureRepository Lecture
        {
            get { return _lecture ??= new LectureRepository(_context); }
        }

        private IGradeRepository _grade = null!;

        public IGradeRepository Grade
        {
            get { return _grade ??= new GradeRepository(_context); }
        }

        private IAddressRepository _address = null!;

        public IAddressRepository Address
        {
            get { return _address ??= new AddressRepository(_context); }
        }


        public IUserRepository _user = null!;
        public IUserRepository User
        {
            get { return _user ??= new UserRepository(_context); }
        }

        public ISubjectRepository _subject = null!;
        public ISubjectRepository Subject
        {
            get { return _subject ??= new SubjectRepository(_context); }
        }

        public IRoleRepository _role = null!;
        public IRoleRepository Role
        {
            get { return _role ??= new RoleRepository(_context); }
        }

        public IFeedbackRepository _feedback = null!;
        public IFeedbackRepository Feedback
        {
            get { return _feedback ??= new FeedbackRepository(_context); }
        }

        public IPaymentRepository _payment = null!;
        public IPaymentRepository Payment
        {
            get { return _payment ??= new PaymentRepository(_context); }
        }

        public IDocumentRepository _document = null!;
        public IDocumentRepository Document
        {
            get { return _document ??= new DocumentRepository(_context); }
        }

        public ISlotRepository _slot = null!;
        public ISlotRepository Slot
        {
            get { return _slot ??= new SlotRepository(_context); }
        }
        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
