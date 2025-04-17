using DDDLesson.Common;
using DDDLesson.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DDDLesson.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<WorkerEntity> Workers { get; init; }
    public DbSet<PackagingTypeEntity> PackagingTypes { get; init; }
    public DbSet<WorkDayEntity> WorkDays { get; init; }
    public DbSet<WorkUnitEntity> WorkUnits { get; init; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = GetSolutionDirectory() + "\\DDDLesson.Presentation\\quadrature.db";

        optionsBuilder.UseSqlite($"Data Source={path}")
            .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.AmbientTransactionWarning));
    }

    public static string GetSolutionDirectory()
    {
        var directory = AppDomain.CurrentDomain.BaseDirectory;

        while (directory != null)
        {
            if (Directory.GetFiles(directory, "*.sln").Length > 0)
            {
                return directory;
            }

            directory = Path.GetDirectoryName(directory);
        }

        throw new Exception("Solution directory could not be found");
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<PackagingTypeId>().HaveConversion<PackagingTypeIdConverter>();
        configurationBuilder.Properties<WorkerId>().HaveConversion<WorkerIdConverter>();
        configurationBuilder.Properties<WorkUnitId>().HaveConversion<WorkUnitIdConverter>();
        configurationBuilder.Properties<WorkDayId>().HaveConversion<WorkDayIdConverter>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PackagingTypeEntity>(b =>
        {
            b.HasKey(p => p.Id);
            b.Property(p => p.Id).HasConversion<PackagingTypeIdConverter>();
            b.Property(p => p.PricePerSquareMeter).HasConversion<double>();
            b.Property(p => p.PricePerSquareMeterOnWeekend).HasConversion<double>();
        });

        modelBuilder.Entity<WorkerEntity>(b =>
        {
            b.HasKey(w => w.Id);
            b.Property(w => w.Id).HasConversion<WorkerIdConverter>();
        });

        modelBuilder.Entity<WorkDayEntity>(b =>
        {
            b.HasKey(w => w.Id);
            b.Property(w => w.Id).HasConversion<WorkDayIdConverter>();

            //b.HasMany(w => w.WorkUnits)
            //    .WithOne()
            //    .HasForeignKey(wu => wu.WorkDayId)
            //    .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<WorkUnitEntity>(b =>
        {
            b.HasKey(w => w.Id);
            b.Property(w => w.Id).HasConversion<WorkUnitIdConverter>();
            b.Property(w => w.Area).HasConversion<double>();

            b.Property(w => w.WorkerId).HasConversion<WorkerIdConverter>();
            b.Property(w => w.PackagingTypeId).HasConversion<PackagingTypeIdConverter>();
            b.Property(w => w.WorkDayId).HasConversion<WorkDayIdConverter>();

            b.HasOne(w => w.WorkDay).WithMany(d => d.WorkUnits).HasForeignKey(w => w.WorkDayId).OnDelete(DeleteBehavior.Cascade);


            //b.HasOne(w => w.Worker)
            //    .WithMany()
            //    .HasForeignKey(w => w.WorkerId);
            //b.HasOne(w => w.PackagingType)
            //    .WithMany()
            //    .HasForeignKey(w => w.PackagingTypeId);
            //b.HasOne(w => w.WorkDay)
            //    .WithMany()
            //    .HasForeignKey(w => w.WorkDayId);
        });
    }
}
