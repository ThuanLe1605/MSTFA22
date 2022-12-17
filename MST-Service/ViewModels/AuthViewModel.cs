namespace MST_Service.ViewModels
{
    public class AuthViewModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public IEnumerable<string> Roles { get; set; } = null!;
        public bool Status { get; set; }
    }
}
