using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface IPromotionService
    {
        Task<IEnumerable<PromotionViewModel>> GetPromotions(string? search);
        Task<PromotionViewModel> GetPromotion(Guid id);
        Task<PromotionViewModel> CreatePromotion(PromotionCreateModel pro);
        Task<PromotionViewModel> UpdatePromotion(Guid id, PromotionUpdateModel pro);
    }
}
