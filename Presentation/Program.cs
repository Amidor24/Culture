using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddHttpClient();

builder.Services.AddOpenApi();

WebApplication webApplication = builder.Build();

if (webApplication.Environment.IsDevelopment())
{
    webApplication.MapOpenApi();
    webApplication.MapScalarApiReference();
}

webApplication.UseHttpsRedirection();

webApplication.UseAuthorization();

webApplication.MapControllers();

webApplication.Run();
