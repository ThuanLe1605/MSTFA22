using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MST_Service.Repositories.Interfaces;
using MST_Service.RequestModels.Internal;
using MST_Service.Servvices.Interfaces;
using MST_Service.Settings;
using MST_Service.UnitOfWorks;
using MST_Service.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MST_Service.Servvices.Implementations
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly AppSetting _appSettings;
        public AuthService(IUnitOfWork unitOfWork, IOptions<AppSetting> appSettings) : base(unitOfWork)
        {
            _appSettings = appSettings.Value;
            _userRepository = unitOfWork.User;
        }

        public async Task<UserViewModel> AuthenticatedUser(AuthRequest auth)
        {
            var user = await _userRepository.GetMany(user => user.Username.Equals(auth.Username) && user.Password.Equals(auth.Password) || user.Email.Equals(auth.Email) && user.Password.Equals(auth.Password))
                .Include(user => user.UserRoles)
                .Include(user => user.Address)
                .FirstOrDefaultAsync();
            if (user != null)
            {
                var token = GenerateJwtToken(new AuthViewModel
                {
                    Id = user.Id,
                    Username = user.Username,
                    Status = true,
                    Roles = user.UserRoles.Select(role => role.Description!).ToArray()
                });
                return new UserViewModel
                {
                    Id = user.Id,
                    Username = user.Username,
                    AvatarUrl = user.AvatarUrl!,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = new AddressViewModel
                    {
                        Id = user.Address!.Id,
                        ApartmentNumber = user.Address.ApartmentNumber,
                        City = user.Address.City,
                        District = user.Address.District,
                        Street = user.Address.Street
                    },
                    Status = user.Status,
                    Roles = user.UserRoles.Select(role => role.Description!).ToArray(),
                    Token = token
                };
            }
            return null!;
        }

        public async Task<AuthViewModel> GetUserById(Guid id)
        {
            var user = await _userRepository.GetMany(user => user.Id.Equals(id)).FirstOrDefaultAsync();
            if (user != null)
            {
                return new AuthViewModel
                {
                    Id = user.Id,
                    Username = user.Username,
                    Roles = user!.UserRoles!.Select(role => role.Description!).ToArray(),
                    Status = true,
                };
            }
            return null;
        }

        private string GenerateJwtToken(AuthViewModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var aaa = _appSettings.Secret;
            var key = Encoding.ASCII.GetBytes(aaa);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim("roles", String.Join(",", user.Roles)),
                }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
