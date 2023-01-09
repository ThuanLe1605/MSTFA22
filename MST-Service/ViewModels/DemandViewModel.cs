using MST_Service.Entities;

namespace MST_Service.ViewModels
{
    public class DemandViewModel
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        //public LectureViewModel? Lecture { get; set; } = null;
        public GenderViewModel? Gender { get; set; }

        public GradeViewModel Grade { get; set; } = null!;

        public SubjectViewModel Subject { get; set; } = null!;

        public SyllabusViewModel Syllabus { get; set; } = null!;

    }
}
