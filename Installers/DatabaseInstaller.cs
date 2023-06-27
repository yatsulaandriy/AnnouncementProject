using AnnouncementProject.Data.Repository;
using AnnouncementProject.Data.Entities;
using AnnouncementProject.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementProject.Installers
{
  public static class DatabaseInstaller
  {
    private const string CONNECTION_KEY = "Database:AnnouncementConnection";
    private const string CREDENTIALS_PATH = "Credentials/Credentials.json";

    public static void AddDatabase(this IServiceCollection services)
    {
      AddDatabaseContext(services);
      AddRepositories(services);
    }

    private static void AddDatabaseContext(IServiceCollection services)
    {
      var configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile(CREDENTIALS_PATH)
      .Build();

      var databaseConnectionString = configuration[CONNECTION_KEY];

      services.AddDbContext<AnnouncementContext>(options =>
      {
        options.UseSqlServer(databaseConnectionString);
      });
    }

    private static void AddRepositories(IServiceCollection services)
    {
      services.AddScoped<IRepository<Announcement>, Repository<Announcement>>();
    }
  }
}
