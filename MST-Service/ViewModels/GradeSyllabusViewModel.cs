using MST_Service.Entities;

namespace MST_Service.ViewModels
{
    public class GradeSyllabusViewModel
    {
        public Guid GradeId { get; set; }

        public Guid SyllabusId { get; set; }

        public double Ratio { get; set; }

        public GradeViewModel? Grade { get; set; }

        public SyllabusViewModel? Syllabus { get; set; }    }
}
