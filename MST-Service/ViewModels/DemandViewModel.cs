using MST_Service.Entities;

namespace MST_Service.ViewModels
{
    public class DemandViewModel
    {
        public Guid Id { get; set; }

        public GenderViewModel? Gender { get; set; }

        public GradeViewModel Grade { get; set; } = null!;

        public SubjectViewModel Subject { get; set; } = null!;

        public SyllabusViewModel Syllabus { get; set; } = null!;

    }
}
