using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentViewModel>> GetPayments();
        Task<PaymentViewModel> GetPayment(Guid id);
        Task<PaymentViewModel> CreatePayment(PaymentCreateModel pay);
        Task<PaymentViewModel> UpdatePayment(Guid id, PaymentUpdateModel pay);
    }
}
