using AnnouncementProject.Installers;
using StackExchange.Redis;

namespace AnnouncementProject
{
  public class Program
  {
    public static void Main()
    {
      var builder = WebApplication.CreateBuilder();
      var services = builder.Services;

      //builder.Services.AddSingleton<IConnectionMultiplexer>(provider =>
      //{
      //  string redisConnectionString = "localhost:6379";

      //  return ConnectionMultiplexer.Connect(redisConnectionString);
      //});

      services.AddDatabase();
      services.AddServices();
      services.AddMapping();

      services.AddControllers();
      services.AddSwaggerGen();

      var application = builder.Build();

      if (application.Environment.IsDevelopment())
      {
        application.UseSwagger();
        application.UseSwaggerUI();
      }

      application.UseHttpsRedirection();

      application.UseAuthorization();

      application.MapControllers();

      application.Run();
    }
  }
}