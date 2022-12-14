using Microsoft.EntityFrameworkCore;
using MST_Service.Entities;
using MST_Service.Repositories.Implementations;
using MST_Service.Repositories.Interfaces;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Interfaces;
using MST_Service.UnitOfWorks;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Implementations
{
    public class PaymentService: BaseService, IPaymentService
    {
        private readonly IPaymentRepository _payRepository;

        public PaymentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _payRepository = unitOfWork.Payment;
        }

        public async Task<PaymentViewModel> CreatePayment(PaymentCreateModel pay)
        {
            var id = Guid.NewGuid();
            var entry = new Payment
            {
                Id = id,
                Fee = pay.Fee,
                IsPayment = pay.IsPayment,
                Description = pay.Description,

            };
            // Add lecture into db context
            _payRepository.Add(entry);
            // Add lecture into database
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetPayment(id);
            }
            return null!;
        }

        public async Task<PaymentViewModel> GetPayment(Guid id)
        {
            return await _payRepository
                .GetMany(pay => pay.Id.Equals(id))
                .Select(pay => new PaymentViewModel
                {
                    Id = id,
                    Fee = pay.Fee,
                    IsPayment = pay.IsPayment,
                    Description = pay.Description,

                }).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<IEnumerable<PaymentViewModel>> GetPayments()
        {
            return await _payRepository
                //.GetMany(pay => pay.Fee!.Contains(search!) || pay.Description!.Contains(search!))
                .GetAll()
                .Select(pay => new PaymentViewModel
                {
                    Id = pay.Id,
                    Fee = pay.Fee,
                    IsPayment = pay.IsPayment,
                    Description = pay.Description,
                    
                }).ToListAsync();
        }

        public async Task<PaymentViewModel> UpdatePayment(Guid id, PaymentUpdateModel pay)
        {
            var currentPay = await _payRepository.GetMany(currentPay => currentPay.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentPay != null)
            {
                if (pay.Fee != null) currentPay!.Fee = (double)pay.Fee;
                if (pay.IsPayment != null) currentPay!.IsPayment = pay.IsPayment;
                if (pay.Description != null) currentPay!.Description = pay.Description;

                _payRepository.Update(currentPay!);
            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetPayment(id);
            }
            return null!;
        }
    }
}
