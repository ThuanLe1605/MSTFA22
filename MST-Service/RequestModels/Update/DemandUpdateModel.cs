namespace MST_Service.RequestModels.Update
{
    public class DemandUpdateModel
    {
        public Guid GradeId { get; set; }

        public Guid SubjectId { get; set; }

        public Guid SyllabusId { get; set; }

        public Guid? GenderId { get; set; }
    }
}
