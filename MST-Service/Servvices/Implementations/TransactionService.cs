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
    public class TransactionService : BaseService, ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _transactionRepository = unitOfWork.Transaction;
        }

        public async Task<IEnumerable<TransactionViewModel>> GetTransactions(string? search)
        {
            return await _transactionRepository
                .GetMany(transaction => transaction.Transform.Equals(search!))
                .Select(transaction => new TransactionViewModel
                {
                    Id = transaction.Id,
                    Description= transaction.Description,
                    Transform= transaction.Transform,
                    
                    Wallet = new WalletViewModel
                    {
                        Id = transaction.Wallet!.Id,
                        Balance = transaction.Wallet.Balance,
                    }
                }).ToListAsync();
        }

        public async Task<TransactionViewModel> GetTransaction(Guid id)
        {
            return await _transactionRepository
                .GetMany(transaction => transaction.Id.Equals(id))
                .Select(transaction => new TransactionViewModel
                {
                    Id = transaction.Id,
                    Description = transaction.Description,
                    Transform = transaction.Transform,
                    Wallet = new WalletViewModel
                    {
                        Id = transaction.Wallet!.Id,
                        Balance = transaction.Wallet.Balance,
                    }
                }).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<TransactionViewModel> CreateTransaction(TransactionCreateModel transaction)
        {
            var id = Guid.NewGuid();
            var entry = new Transaction
            {
                Id = id,
                Description = transaction.Description,
                Transform = transaction.Transform,

            };
            // Add transaction into db context
            _transactionRepository.Add(entry);
            // Add transaction into database
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetTransaction(id);
            }
            return null!;
        }

        public async Task<TransactionViewModel> UpdateTransaction(Guid id, TransactionUpdateModel transaction)
        {
            var currentTransaction = await _transactionRepository.GetMany(currentTransaction => currentTransaction.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentTransaction != null)
            {
                if (transaction.Transform != null) currentTransaction!.Transform = (double)transaction.Transform;
                if (transaction.Description != null) currentTransaction!.Description = transaction.Description;

                _transactionRepository.Update(currentTransaction!);

            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetTransaction(id);
            }
            return null!;
        }
    }
}

