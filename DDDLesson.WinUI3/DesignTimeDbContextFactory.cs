using DDDLesson.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.IO;

namespace DDDLesson.WinUI3;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        string path = GetSolutionDirectory() + "\\DDDLesson.Infrastructure\\quadrature.db";
        var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionBuilder.UseSqlite($"Data Source={path}")
            .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.AmbientTransactionWarning));
        return new AppDbContext(optionBuilder.Options);
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
}
