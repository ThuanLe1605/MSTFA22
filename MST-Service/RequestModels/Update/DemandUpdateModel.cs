namespace MST_Service.RequestModels.Update
{
    public class DemandUpdateModel
    {
        public string? Status { get; set; }
        public string? Address { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Monday { get; set; }
        public bool? Tuesday { get; set; }
        public bool? Wednesday { get; set; }
        public bool? Thursday { get; set; }
        public bool? Friday { get; set; }
        public bool? Saturday { get; set; }
        public bool? Sunday { get; set; }

        public Guid? LectureId { get; set; }
        public Guid? GradeId { get; set; }

        public Guid? SubjectId { get; set; }

        public Guid? SyllabusId { get; set; }

        public Guid? GenderId { get; set; }
    }
}
