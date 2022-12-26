using Azure.Identity;
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
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _userRepository = unitOfWork.User;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsers(string? search)
        {
            return await _userRepository
                .GetMany(user => user.FirstName!.Contains(search ?? "") || user.LastName!.Contains(search ?? "") || user.Username!.Contains(search ?? ""))
                //.GetAll()
                .Select(user => new UserViewModel
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    AvatarUrl = user.AvatarUrl,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Status = user.Status,
                    Address = new AddressViewModel
                    {
                        Id = user.Address!.Id,
                        City = user.Address.City,
                        District = user.Address.District,
                        Street = user.Address.Street,
                        ApartmentNumber = user.Address.ApartmentNumber,
                    },
                }).ToListAsync();

        }

        public async Task<UserViewModel> GetUser(Guid id)
        {
            return await _userRepository
                .GetMany(user => user.Id.Equals(id))
                .Select(user => new UserViewModel
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    AvatarUrl = user.AvatarUrl,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Status = user.Status,
                    Address = new AddressViewModel
                    {
                        Id = user.Address!.Id,
                        City = user.Address.City,
                        District = user.Address.District,
                        Street = user.Address.Street,
                        ApartmentNumber = user.Address.ApartmentNumber,
                    },
                }).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<UserViewModel> CreateUser(UserCreateModel user)
        {
            var id = Guid.NewGuid();
            var entry = new User
            {
                Id = id,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                AvatarUrl = user.AvatarUrl,
                FirstName = user.FirstName,
                LastName = user.LastName,                
                Status = true,
                Address = new Address
                {
                    Id = Guid.NewGuid(),
                    City = user.Address!.City, 
                    District = user.Address.District, 
                    Street= user.Address.Street,
                    ApartmentNumber= user.Address.ApartmentNumber,
                }
            };
            // Add lecture into db context
            _userRepository.Add(entry);
            // Add lecture into database
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetUser(id);
            }
            return null!;
        }

        public async Task<UserViewModel> UpdateUser(Guid id, UserUpdateModel user)
        {
            var currentUser = await _userRepository.GetMany(currentUser => currentUser.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentUser != null)
            {
                if (user.Email is not null) currentUser!.Email = user.Email;
                if (user.Password is not null) currentUser!.Password = user.Password;
                if (user.AvatarUrl is not null) currentUser!.AvatarUrl = user.AvatarUrl;
                if (user.FirstName is not null) currentUser!.FirstName = user.FirstName;
                if (user.LastName is not null) currentUser!.LastName = user.LastName;
                //if (user.Address.City is not null) currentUser!.Address.City = user.Address.City;
                //if (user.Address.District is not null) currentUser!.Address.District = user.Address.District;
                //if (user.Address.Street is not null) currentUser!.Address.Street = user.Address.Street;
                //if (user.Address.ApartmentNumber is not null) currentUser!.Address.ApartmentNumber = user.Address.ApartmentNumber;

                _userRepository.Update(currentUser!);

            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetUser(id);
            }
            return null!;
        }
    }
}
