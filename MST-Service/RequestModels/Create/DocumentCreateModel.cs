namespace MST_Service.RequestModels.Create
{
    public class DocumentCreateModel
    {

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string Url { get; set; } = null!;

        public bool? Status { get; set; }
    }
}
