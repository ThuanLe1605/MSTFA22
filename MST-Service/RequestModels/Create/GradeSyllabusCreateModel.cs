namespace MST_Service.RequestModels.Create
{
    public class GradeSyllabusCreateModel
    {
        public Guid GradeId { get; set; } 

        public Guid SyllabusId { get; set; } 

        public double Ratio { get; set; } 
    }
}
