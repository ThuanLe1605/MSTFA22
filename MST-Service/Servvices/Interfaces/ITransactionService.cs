using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionViewModel>> GetTransactions(string? search);
        Task<TransactionViewModel> GetTransaction(Guid id);
        Task<TransactionViewModel> CreateTransaction(TransactionCreateModel transaction);
        Task<TransactionViewModel> UpdateTransaction(Guid id, TransactionUpdateModel transaction);
    }
}
