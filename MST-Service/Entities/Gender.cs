namespace MST_Service.Entities;

public partial class Gender
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Demand> Demands { get; } = new List<Demand>();

    public virtual ICollection<Lecture> Lectures { get; } = new List<Lecture>();
}
