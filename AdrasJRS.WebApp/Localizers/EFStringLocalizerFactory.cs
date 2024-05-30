using AdrasJRS.Data.DataContext;
using AdrasJRS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace AdrasJRS.Localizers;

public class EFStringLocalizerFactory : IStringLocalizerFactory
{
    public IStringLocalizer Create(Type resourceSource)
    {
        return CreateStringLocalizer();
    }

    public IStringLocalizer Create(string baseName, string location)
    {
        return CreateStringLocalizer();
    }

    private IStringLocalizer CreateStringLocalizer()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("AdrasJRSContextConnection");

        var optionsBuilder = new DbContextOptionsBuilder<DataDbContext>();
        optionsBuilder.UseSqlite(connectionString);

        var _db = new DataDbContext(optionsBuilder.Options);

        // инициализация базы данных
        if (!_db.Cultures.Any())
        {
            _db.AddRange(
                new Culture
                {
                    Name = "en",
                    Resources = new List<Resource>()
                },
                new Culture
                {
                    Name = "ru",
                    Resources = new List<Resource>()
                },
                new Culture
                {
                    Name = "uz",
                    Resources = new List<Resource>()
                },
                new Culture
                {
                    Name = "de",
                    Resources = new List<Resource>()
                }
            );
            _db.SaveChanges();
        }
        return new EFStringLocalizer(_db);
    }
}