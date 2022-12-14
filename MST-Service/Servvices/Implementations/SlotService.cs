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
    public class SlotService : BaseService, ISlotService
    {
        private readonly ISlotRepository _slotRepository;
        public SlotService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _slotRepository = unitOfWork.Slot;
        }

        public async Task<SlotViewModel> CreateSlot(SlotCreateModel Slot)
        {
            var id = Guid.NewGuid();
            var entry = new Slot
            {
                Id = id,
                StartTime= DateTime.Now,
                EndTime= DateTime.Now,

            };
            // Add Slot into db context
            _slotRepository.Add(entry);
            // Add Slot into database
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetSlot(id);
            }
            return null!;
        }

        public async Task<SlotViewModel> GetSlot(Guid id)
        {
            return await _slotRepository
                //.GetMany(slot => slot.Id.Equals(id))
                .GetAll()
                .Select(slot => new SlotViewModel
                {
                    Id = id,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now,
                }).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<IEnumerable<SlotViewModel>> GetSlots(DateTime? startTime, DateTime? endTime)
        {
            return await _slotRepository
                .GetMany(slot => slot.StartTime >= startTime && slot.EndTime <= endTime)
                .Select(slot => new SlotViewModel
                {
                    Id = slot.Id,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now,

                }).ToListAsync();
        }



        public async Task<SlotViewModel> UpdateSlot(Guid id, SlotUpdateModel slot)
        {
            var currentSlot = await _slotRepository.GetMany(currentSlot => currentSlot.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentSlot != null)
            {
                if (slot!.StartTime != null)
                {
                    currentSlot!.StartTime = slot.StartTime;
                }
                // more...

                _slotRepository.Update(currentSlot!);

            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetSlot(id);
            }
            return null!;
        }
    }
}
