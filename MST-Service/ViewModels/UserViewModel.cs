using MST_Service.Entities;

namespace MST_Service.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? AvatarUrl { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool? Status { get; set; }

        public AddressViewModel? Address { get; set; }

        public ICollection<string> Roles { get; set; } = null!;
        public string Token { get; set; } = null!;

    }
}
