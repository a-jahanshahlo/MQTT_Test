namespace CarriotTest.Db.Entities;

public class TempLogDto
{

    public string DeviceID { get; set; }
    public DateTime DeviceTime { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Altitude { get; set; }
    public double Course { get; set; }
    public int Satellites { get; set; }
    public double SpeedOTG { get; set; }
    public double AccelerationX1 { get; set; }
    public double AccelerationY1 { get; set; }
    public int Signal { get; set; }
    public int PowerSupply { get; set; }
}
