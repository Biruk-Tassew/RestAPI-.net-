using Microsoft.EntityFrameworkCore;
using restAPI.Models; 
namespace restAPI.Data;

public class ApiDbContext : DbContext
{
    public virtual DbSet<Team> Teams {get;set;}
    public virtual DbSet<Driver> Drivers {get;set;}
    public virtual DbSet<DriverMedia> DriverMedias {get;set;}
    public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Driver>(entity =>{
            // 1 - many
            entity.HasOne(t => t.Team)
            .WithMany(d => d.Drivers)
            .HasForeignKey(x=> x.TeamId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Driver_Team");

            // 1-1
            entity.HasOne(dm => dm.DriverMedia)
            .WithOne(d => d.Driver)
            .HasForeignKey<DriverMedia>(x=> x.DriverId); 
        });
    }

}

