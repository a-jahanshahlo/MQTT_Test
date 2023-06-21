 
using CarriotTest.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarriotTest.Db;

public partial class CarriotDbContext : DbContext
{
    public CarriotDbContext()
    {
    }

    public CarriotDbContext(DbContextOptions<CarriotDbContext> options)
        : base(options)
    {
    }

     public virtual DbSet<HasWarning> HasWarnings { get; set; }

     public virtual DbSet<TempLog> TempLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CarriotDb;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HasWarning>(entity =>
        {
            entity.ToTable("HasWarning");
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("uniqueidentifier") ;

            entity.Property(x => x.DeviceID).HasColumnName(@"DeviceID").IsRequired().HasColumnType("nvarchar(50)");
            entity.Property(x => x.WarningTime).HasColumnName(@"WarningTime").IsRequired().HasColumnType("datetime");
            entity.Property(x => x.WarningType).HasColumnName(@"WarningType").IsRequired().HasColumnType("int");


        });

        modelBuilder.Entity<TempLog>(entity =>
        {
            entity.ToTable("TempLog");
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("uniqueidentifier") ;
            entity.Property(x => x.DeviceID).HasColumnName(@"DeviceID").IsRequired().HasColumnType("nvarchar(50)");


            entity.Property(x => x.DeviceID).HasColumnName(@"DeviceID").IsRequired().HasColumnType("nvarchar(50)");
            entity.Property(x => x.DeviceTime).HasColumnName(@"DeviceTime").IsRequired().HasColumnType("datetime");

            entity.Property(x => x.Latitude).HasColumnName(@"Latitude").IsRequired().HasColumnType("decimal(18, 0)");
            entity.Property(x => x.Longitude).HasColumnName(@"Longitude").IsRequired(). HasColumnType("decimal(18, 0)");
            entity.Property(x => x.Altitude).HasColumnName(@"Altitude").IsRequired(). HasColumnType("decimal(18, 0)");
            entity.Property(x => x.Course).HasColumnName(@"Course").IsRequired(). HasColumnType("decimal(18, 0)");

            entity.Property(x => x.Satellites).HasColumnName(@"Satellites").IsRequired().HasColumnType("int");

            entity.Property(x => x.SpeedOTG).HasColumnName(@"SpeedOTG").IsRequired().HasColumnType("decimal(18, 0)");
            entity.Property(x => x.AccelerationX1).HasColumnName(@"AccelerationX1").IsRequired().HasColumnType("decimal(18, 0)");
            entity.Property(x => x.AccelerationY1).HasColumnName(@"AccelerationY1").IsRequired().HasColumnType("decimal(18, 0)");


            entity.Property(x => x.Signal).HasColumnName(@"Signal").IsRequired().HasColumnType("int");
            entity.Property(x => x.PowerSupply).HasColumnName(@"PowerSupply").IsRequired().HasColumnType("int");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
