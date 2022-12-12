namespace MST_Service.RequestModels.Update
{
    public class AddressUpdateModel
    {

        public string City { get; set; } = null!;

        public string District { get; set; } = null!;

        public string Street { get; set; } = null!;

        public string? ApartmentNumber { get; set; }
    }
}
