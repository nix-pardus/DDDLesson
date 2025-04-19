using DDDLesson.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DDDLesson.Infrastructure;

public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionBuilder.UseSqlite("Data Source=quadrature.db")
            .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.AmbientTransactionWarning));
        return new AppDbContext(optionBuilder.Options);
    }
}
