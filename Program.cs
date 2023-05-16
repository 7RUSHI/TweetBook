using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using TweetBook.Installers;
using TweetBook.Options;
using SwaggerOptions = TweetBook.Options.SwaggerOptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServicesInAssembly(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    var swaggerOptions = new TweetBook.Options.SwaggerOptions();
    builder.Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
    app.UseSwagger(options => {
        options.RouteTemplate = swaggerOptions.JsonRoute;
    });
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
