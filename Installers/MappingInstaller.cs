using AnnouncementProject.Service.Mappers;
using AutoMapper;

namespace AnnouncementProject.Installers
{
  public static class MappingInstaller
  {
    public static void AddMapping(this IServiceCollection services)
    {
      var mapperConfiguration = new MapperConfiguration(configuration =>
      {
        configuration.AddProfile<AnnouncementMapper>();
      });

      var mapper = mapperConfiguration.CreateMapper();
      services.AddSingleton(mapper);
    }
  }
}
