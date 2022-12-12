namespace MST_Service.RequestModels.Update
{
    public class LectureUpdateModel
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? AvatarUrl { get; set; }

        public Guid? GenderId { get; set; }

        public string? Bio { get; set; }

        public double? Price { get; set; }

        public bool? Status { get; set; }
    }
}
