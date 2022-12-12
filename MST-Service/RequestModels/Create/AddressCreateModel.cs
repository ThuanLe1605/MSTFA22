namespace MST_Service.RequestModels.Create
{
    public class AddressCreateModel
    {
        public Guid Id { get; set; }

        public string City { get; set; } = null!;

        public string District { get; set; } = null!;

        public string Street { get; set; } = null!;

        public string? ApartmentNumber { get; set; }
    }
}
