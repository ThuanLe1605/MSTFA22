using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MST_Service.Entities;
using MST_Service.Repositories.Implementations;
using MST_Service.Repositories.Interfaces;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Interfaces;
using MST_Service.UnitOfWorks;
using MST_Service.ViewModels;
using System.Reflection.Metadata;

namespace MST_Service.Servvices.Implementations
{
    public class EventService : BaseService, IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _eventRepository = unitOfWork.Event;
        }

        public async Task<EventViewModel> CreateEvent(EventCreateModel events)
        {
            var id = Guid.NewGuid();
            var entry = new Event
            {
                Id = id,
                Name = events.Name,
                Thumbnail = events.Thumbnail,
                Description = events.Description,
                CreateDate = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            };
            _eventRepository.Add(entry);

            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetEvent(id);
            }
            return null!;
        }

        public async Task<EventViewModel> GetEvent(Guid id)
        {
            return await _eventRepository
                .GetMany(events => events.Id.Equals(id))
                .Select(events => new EventViewModel
                {
                    Id = events.Id,
                    Name = events.Name,
                    Thumbnail = events.Thumbnail,
                    Description = events.Description,
                    CreateDate = events.CreateDate,
                    StartDate = events.StartDate,
                    EndDate = events.EndDate,
                    Promotion = new PromotionViewModel
                    {
                        Id = events.Promotion!.Id,
                        Name = events.Promotion.Name,
                        Description = events.Promotion.Description,
                        CreateDate = events.Promotion.CreateDate,
                        Ratio = events.Promotion.Ratio,
                    }
                }).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<IEnumerable<EventViewModel>> GetEvents(string? search)
        {
            return await _eventRepository
                .GetMany(events => events.Name!.Contains(search ?? "") || events.Description!.Contains(search ?? ""))
                .Select(events => new EventViewModel
                {
                    Id = events.Id,
                    Name = events.Name,
                    Thumbnail = events.Thumbnail,
                    Description = events.Description,
                    CreateDate = events.CreateDate,
                    StartDate = events.StartDate,
                    EndDate = events.EndDate,
                    
                    Promotion = new PromotionViewModel
                    {
                        Id = events.Promotion!.Id,
                        Name = events.Promotion.Name,
                        Description= events.Promotion.Description,
                        CreateDate = events.Promotion.CreateDate,
                        Ratio= events.Promotion.Ratio,
                    },
                }).ToListAsync();
        }

        public async Task<EventViewModel> UpdateEvent(Guid id, EventUpdateModel events)
        {
            var currentEvent = await _eventRepository.GetMany(currentEvent => currentEvent.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentEvent != null)
            {
                if (events.Name != null) currentEvent!.Name = events.Name;
                if (events.Thumbnail != null) currentEvent!.Thumbnail = events.Thumbnail;
                if (events.Description != null) currentEvent!.Description = events.Description;
                if (events.StartDate != null) currentEvent!.StartDate = events.StartDate;
                if (events.EndDate != null) currentEvent!.EndDate = events.EndDate;

                _eventRepository.Update(currentEvent!);
            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetEvent(id);
            }
            return null!;
        }
    }
}
