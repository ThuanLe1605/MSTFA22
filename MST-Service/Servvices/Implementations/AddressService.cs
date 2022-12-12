using Microsoft.EntityFrameworkCore;
using MST_Service.Entities;
using MST_Service.Repositories.Implementations;
using MST_Service.Repositories.Interfaces;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Interfaces;
using MST_Service.UnitOfWorks;
using MST_Service.ViewModels;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace MST_Service.Servvices.Implementations
{
    public class AddressService : BaseService, IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _addressRepository = unitOfWork.Address;
        }

        public async Task<AddressViewModel> CreateAddress(AddressCreateModel address)
        {
            var id = Guid.NewGuid();
            var entry = new Address
            {
                Id = id,
                City = address.City,
                District = address.District,
                Street = address.Street,
                ApartmentNumber = address.ApartmentNumber,
            };
  
            _addressRepository.Add(entry);
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetAddress(id);
            }
            return null!;
        }

        public async Task<AddressViewModel> GetAddress(Guid id)
        {
            return await _addressRepository
                .GetMany(address => address.Id!.Equals(id))
                .Select(address => new AddressViewModel
                {
                    Id = address.Id,
                    City = address.City,
                    Street = address.Street,
                    District = address.District,
                    ApartmentNumber = address.ApartmentNumber
                }).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<IEnumerable<AddressViewModel>> GetAddresss(string? searchLocation)
        {
            return await _addressRepository
                .GetMany(address => address.District!.Contains(searchLocation!) || address.City!.Contains(searchLocation!) || address.Street!.Contains(searchLocation!))
                .Select(address => new AddressViewModel
                {
                    Id = address.Id,
                    City = address.City,
                    Street= address.Street,
                    District= address.District,
                    ApartmentNumber = address.ApartmentNumber
                }).ToListAsync();
        }

        public async Task<AddressViewModel> UpdateAddress(Guid id, AddressUpdateModel address)
        {
            var currentAddress = await _addressRepository.GetMany(currentAddress => currentAddress.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentAddress != null)
            {
                if (address.City is not null) currentAddress!.City = address.City;
                // more...

                _addressRepository.Update(currentAddress!);

            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetAddress(id);
            }
            return null!;
        }
    }
}
