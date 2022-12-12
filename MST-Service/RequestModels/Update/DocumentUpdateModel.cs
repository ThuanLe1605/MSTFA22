namespace MST_Service.RequestModels.Update
{
    public class DocumentUpdateModel
    {

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string Url { get; set; } = null!;

        public bool? Status { get; set; }
    }
}
