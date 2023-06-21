namespace CarriotTest.Db.Entities;

public class HasWarning
{
    public Guid Id { get; set; }

    public HasWarning() {
    Id = Guid.NewGuid();
    }

    public string DeviceID { get; set; }
    public DateTime WarningTime { get; set; }
    public int WarningType { get; set; }
}
