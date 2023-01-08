namespace MST_Service.ViewModels
{
    public class LectureViewModel
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? AvatarUrl { get; set; }
        public string? Phone { get; set; }
        public string? Bio { get; set; }

        public double Price { get; set; }

        public bool? Status { get; set; }

        public GenderViewModel? Gender { get; set; }
        public ICollection<SubjectViewModel>? Subjects { get; set; }
        public ICollection<GradeViewModel>? Grades { get; set; }
    }
}
