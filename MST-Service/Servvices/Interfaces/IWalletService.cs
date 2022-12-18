using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface IWalletService
    {
        Task<IEnumerable<WalletViewModel>> GetWallets(string? search);
        Task<WalletViewModel> GetWallet(Guid id);
        Task<WalletViewModel> CreateWallet(WalletCreateModel wallet);
        Task<WalletViewModel> UpdateWallet(Guid id, WalletUpdateModel wallet);
    }
}
