namespace MST_Service.RequestModels.Create
{
    public class SlotCreateModel
    {
        public Guid Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
