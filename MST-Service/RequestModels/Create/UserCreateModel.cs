using MST_Service.Entities;

namespace MST_Service.RequestModels.Create
{
    public class UserCreateModel
    {
        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
        public string? Phone { get; set; }

        public string? AvatarUrl { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool? Status { get; set; }

        public virtual Address? Address { get; set; }
        //public ICollection<string> Roles { get; set; } = null!;
    }
}
