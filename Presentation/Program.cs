using Presentation.Extensions;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.InjectServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddHttpClient();

builder.Services.AddOpenApi();

WebApplication webApplication = builder.Build();

if (webApplication.Environment.IsDevelopment())
{
    webApplication.MapOpenApi();
    webApplication.MapScalarApiReference("/docs", options =>
    {
        options.WithTitle("My API Documentation");
    });
}

webApplication.UseHttpsRedirection();

webApplication.UseAuthorization();

webApplication.MapControllers();

webApplication.Run();
