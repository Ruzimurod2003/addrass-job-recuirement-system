using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AdrasJRS.Data.DataContext;
public class DataDbContextFactory : IDesignTimeDbContextFactory<DataDbContext>
{
    public DataDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("AdrasJRSContextConnection");

        var optionsBuilder = new DbContextOptionsBuilder<DataDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new DataDbContext(optionsBuilder.Options);
    }
}