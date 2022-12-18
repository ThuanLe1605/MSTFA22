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
    public class WalletService : BaseService, IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _walletRepository = unitOfWork.Wallet;
        }

        public async Task<IEnumerable<WalletViewModel>> GetWallets(string? search)
        {
            return await _walletRepository
                .GetMany(wallet => wallet.Balance!.Equals(search!))
                .Select(wallet => new WalletViewModel
                {
                    Id = wallet.Id,
                    Balance= wallet.Balance,
                    User = new UserViewModel    
                    {
                        Id = wallet.User!.Id,
                        Username = wallet.User.Username,
                        Email = wallet.User.Email,
                        AvatarUrl = wallet.User.AvatarUrl,
                        FirstName = wallet.User.FirstName,
                        LastName = wallet.User.LastName,
                    },
                }).ToListAsync();
        }

        public async Task<WalletViewModel> GetWallet(Guid id)
        {
            return await _walletRepository
                .GetMany(wallet => wallet.Id.Equals(id))
                .Select(wallet => new WalletViewModel
                {
                    Id = wallet.Id,
                    Balance = wallet.Balance,
                    User = new UserViewModel
                    {
                        Id = wallet.User!.Id,
                        Username = wallet.User.Username,
                        Email = wallet.User.Email,
                        AvatarUrl = wallet.User.AvatarUrl,
                        FirstName = wallet.User.FirstName,
                        LastName = wallet.User.LastName,
                    },
                }).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<WalletViewModel> CreateWallet(WalletCreateModel wallet)
        {
            var id = Guid.NewGuid();
            var entry = new Wallet
            {
                Id = id,
                Balance = wallet.Balance,
            };
            // Add wallet into db context
            _walletRepository.Add(entry);
            // Add wallet into database
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetWallet(id);
            }
            return null!;
        }

        public async Task<WalletViewModel> UpdateWallet(Guid id, WalletUpdateModel wallet)
        {
            var currentWallet = await _walletRepository.GetMany(currentWallet => currentWallet.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentWallet != null)
            {
                if (wallet.Balance != null) currentWallet!.Balance = (double)wallet.Balance;

                _walletRepository.Update(currentWallet!);

            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetWallet(id);
            }
            return null!;
        }
    }
}
