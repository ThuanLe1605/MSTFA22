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
    public class BookingStatusService : BaseService, IBookingStatusService
    {
        private readonly IBookingStatusRepository _bookingStatusRepository;

        public BookingStatusService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _bookingStatusRepository = unitOfWork.BookingStatus;
        }

        public async Task<BookingStatusViewModel> CreateBookingStatus(BookingStatusCreateModel bkstatus)
        {
            var id = Guid.NewGuid();
            var entry = new BookingStatus
            {
                Id = id,
                Name = bkstatus.Name,
                Description = bkstatus.Description,
                
            };
            // Add demand into db context
            _bookingStatusRepository.Add(entry);
            // Add demand into database
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetBookingStatus(id);
            }
            return null!;
        }

        public async Task<BookingStatusViewModel> GetBookingStatus(Guid id)
        {
            return await _bookingStatusRepository
                .GetMany(bkStatus => bkStatus.Id.Equals(id))
                .Select(bkstatus => new BookingStatusViewModel
                {
                    Id = bkstatus.Id,
                    Name = bkstatus.Name,
                    Description = bkstatus.Description,

                }).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<IEnumerable<BookingStatusViewModel>> GetBookingStatuses(string? search)
        {
            return await _bookingStatusRepository
                .GetMany(bkstatus => bkstatus.Name!.Contains(search ?? "") || bkstatus.Description!.Contains(search ?? ""))
                .Select(bkstatus => new BookingStatusViewModel
                {
                    Id = bkstatus.Id,
                    Name = bkstatus.Name,
                    Description = bkstatus.Description,
                    
                }).ToListAsync();
        }

        public async Task<BookingStatusViewModel> UpdateBookingStatus(Guid id, BookingStatusUpdateModel bkstatus)
        {
            var currentBookingStatus = await _bookingStatusRepository.GetMany(currentBookingStatus => currentBookingStatus.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentBookingStatus != null)
            {
                if (bkstatus.Name != null) currentBookingStatus!.Name = bkstatus.Name;
                if (bkstatus.Description != null) currentBookingStatus!.Description = bkstatus.Description;

                _bookingStatusRepository.Update(currentBookingStatus!);

            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetBookingStatus(id);
            }
            return null!;
        }
    }
}
