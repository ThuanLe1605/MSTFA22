using MST_Service.Entities;

namespace MST_Service.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? AvatarUrl { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public Guid? AddressId { get; set; }

        public bool? Status { get; set; }

        public AddressViewModel? Address { get; set; }
    }
}
