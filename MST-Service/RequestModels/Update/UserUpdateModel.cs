using MST_Service.Entities;
using MST_Service.ViewModels;

namespace MST_Service.RequestModels.Update
{
    public class UserUpdateModel
    {
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? AvatarUrl { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Phone { get; set; }


        public AddressViewModel? Address { get; set; }
        //public ICollection<string> Roles { get; set; } = null!;
    }
}
