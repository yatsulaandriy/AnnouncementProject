using AnnouncementProject.Service.Services.AnnouncementService;
using AnnouncementProject.Service.Services.AnnouncementSimilarityService;

namespace AnnouncementProject.Installers
{
  public static class ServiceInstaller
  {
    public static void AddServices(this IServiceCollection services)
    {
      services.AddScoped<IAnnouncementService, AnnouncementService>();
      services.AddScoped<IAnnouncementSimilarityService, AnnouncementSimilarityService>();
    }
  }
}
