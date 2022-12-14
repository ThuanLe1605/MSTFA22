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
    public class PromotionService : BaseService, IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;
        public PromotionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _promotionRepository = unitOfWork.Promotion;
        }

        public async Task<PromotionViewModel> CreatePromotion(PromotionCreateModel pro)
        {
            var id = Guid.NewGuid();
            var entry = new Promotion
            {
                Id = id,
                Name = pro.Name,
                Description = pro.Description,
                CreateDate = DateTime.Now,
                Ratio = pro.Ratio,
            };
            _promotionRepository.Add(entry);
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetPromotion(id);
            }
            return null!;

        }

        public async Task<PromotionViewModel> GetPromotion(Guid id)
        {
            return await _promotionRepository
                .GetMany(pro => pro.Id.Equals(id))
                .Select(pro => new PromotionViewModel
                {
                    Id = id,
                    Name = pro.Name,
                    Description = pro.Description,
                    CreateDate = DateTime.Now,
                    Ratio = pro.Ratio,
                }).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<IEnumerable<PromotionViewModel>> GetPromotions(string? search)
        {
            return await _promotionRepository
                .GetMany(pro => pro.Name!.Contains(search!) || pro.Description!.Contains(search!))
                //.GetAll()
                .Select(pro => new PromotionViewModel
                {
                    Id = pro.Id,
                    Name = pro.Name,
                    Description = pro.Description,
                    CreateDate = DateTime.Now,
                    Ratio = pro.Ratio,

                }).ToListAsync();
        }

        public async Task<PromotionViewModel> UpdatePromotion(Guid id, PromotionUpdateModel pro)
        {
            var currentPromotion = await _promotionRepository.GetMany(currentPromotion => currentPromotion.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentPromotion != null)
            {
                if (pro.Name != null) currentPromotion!.Name = pro.Name;
                if (pro.Description != null) currentPromotion!.Description = pro.Description;
                if (pro.Ratio != null) currentPromotion!.Ratio = (double)pro.Ratio;


                _promotionRepository.Update(currentPromotion!);
            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetPromotion(id);
            }
            return null!;
        }
    }
}
