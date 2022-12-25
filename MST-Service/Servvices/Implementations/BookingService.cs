using Microsoft.EntityFrameworkCore;
using MST_Service.Entities;
using MST_Service.Repositories.Implementations;
using MST_Service.Repositories.Interfaces;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Interfaces;
using MST_Service.UnitOfWorks;
using MST_Service.ViewModels;
using System.Net.NetworkInformation;

namespace MST_Service.Servvices.Implementations
{
    public class BookingService : BaseService, IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _bookingRepository = unitOfWork.Booking;
        }

        public async Task<BookingViewModel> CreateBooking(BookingCreateModel booking)
        {
            var id = Guid.NewGuid();
            var entry = new Booking
            {
                Id = id,
                BookingAt= DateTime.Now,
                LectureId = booking.LectureId,
                UserId= booking.UserId,
                BookingStatusId= booking.BookingStatusId,

            };
            // Add demand into db context
            _bookingRepository.Add(entry);
            // Add demand into database
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetBooking(id);
            }
            return null!;
        }

        public async Task<BookingViewModel> GetBooking(Guid id)
        {
            return await _bookingRepository
                .GetMany(booking => booking.Id.Equals(id))
                .Select(booking => new BookingViewModel
                {
                    Id = booking.Id,
                    BookingAt = booking.BookingAt,
                    BookingStatus = booking.BookingStatus != null ? new BookingStatusViewModel
                    {
                        Id = booking.BookingStatus!.Id,
                        Name = booking.BookingStatus.Name,
                        Description = booking.BookingStatus.Description,
                    }: null!,
                    Lecture = booking.Lecture != null? new LectureViewModel
                    {
                        Id = booking.Lecture!.Id,
                        FirstName = booking.Lecture.FirstName,
                        LastName = booking.Lecture.LastName,
                        AvatarUrl = booking.Lecture.AvatarUrl,
                        Bio = booking.Lecture.Bio,
                        Price = booking.Lecture.Price,

                    } : null!,
                    User = booking.User != null ? new UserViewModel
                    {
                        Id = booking.User!.Id,
                        Username = booking.User.Username,
                        Email = booking.User.Email,
                        AvatarUrl = booking.User.AvatarUrl,
                        FirstName = booking.User.FirstName,
                        LastName = booking.User.LastName,
                    } : null!,
                    Payment = booking.Payment != null ? new PaymentViewModel
                    {
                        Id = booking.Payment!.Id,
                        Fee = booking.Payment.Fee,
                        IsPayment = booking.Payment.IsPayment,
                        Description = booking.Payment.Description,
                    } : null!,
                }).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<IEnumerable<BookingViewModel>> GetBookings(string? search)
        {
            return await _bookingRepository
                .GetMany(booking => booking.Lecture!.FirstName!.Contains(search ?? "") || booking.Lecture!.LastName!.Contains(search ?? ""))
                //.GetAll()
                .Select(booking => new BookingViewModel
                {
                    Id = booking.Id,
                    BookingAt = booking.BookingAt,
                    BookingStatus = new BookingStatusViewModel
                    {
                        Id = booking.BookingStatus!.Id,
                        Name = booking.BookingStatus.Name,
                        Description = booking.BookingStatus.Description,
                    },
                    Lecture = new LectureViewModel
                    {
                        Id = booking.Lecture!.Id,
                        FirstName = booking.Lecture.FirstName,
                        LastName = booking.Lecture.LastName,
                        AvatarUrl = booking.Lecture.AvatarUrl,
                        Bio = booking.Lecture.Bio,
                        Price = booking.Lecture.Price,

                    },
                    User = new UserViewModel
                    {
                        Id = booking.User!.Id,
                        Username = booking.User.Username,
                        Email = booking.User.Email,
                        AvatarUrl = booking.User.AvatarUrl,
                        FirstName = booking.User.FirstName,
                        LastName = booking.User.LastName,
                    },
                    Payment = new PaymentViewModel
                    {
                        Id = booking.Payment!.Id,
                        Fee = booking.Payment.Fee,
                        IsPayment = booking.Payment.IsPayment,
                        Description = booking.Payment.Description,
                    },
                }).ToListAsync();
        }

        public async Task<BookingViewModel> UpdateBooking(Guid id, BookingUpdateModel booking)
        {
            var currentBooking = await _bookingRepository.GetMany(currentBooking => currentBooking.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentBooking != null)
            {
                if (booking.BookingAt != null) currentBooking!.BookingAt = booking.BookingAt;

                _bookingRepository.Update(currentBooking!);

            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetBooking(id);
            }
            return null!;
        }
    }
}
