namespace MST_Service.ViewModels
{
    public class DocumentViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string Url { get; set; } = null!;

        public bool? Status { get; set; }

    }
}
