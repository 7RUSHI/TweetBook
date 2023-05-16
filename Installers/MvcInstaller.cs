using Microsoft.OpenApi.Models;

namespace TweetBook.Installers;
public class MvcInstaller : IInstaller {
    public void InstallServices(IServiceCollection services, IConfiguration configuration) {
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(option => {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "TweekBook API Title" });
        });
    }
}
