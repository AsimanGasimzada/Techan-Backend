using Techan.Business.ServiceRegistrations;
using Techan.DataAccess.ServiceRegistrations;
using Techan.Presentation.Extensions;


namespace Techan.Presentation;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);



        builder.Services.AddControllers();

        builder.Services.AddCors(options => { options.AddPolicy("AllowAll", policy => { policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }); });






        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerConfiguration();


        builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

        builder.Services.AddDataAccessServices(builder.Configuration);


        builder.Services.AddBusinessServices(builder.Configuration);


        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        if (!app.Environment.IsDevelopment())
            app.UseMiddleware<GlobalExceptionHandler>();

        await app.InitDatabaseAsync();

        app.UseHttpsRedirection();

        app.UseCors("AllowAll");

        app.UseAuthentication();
        app.UseAuthorization();


        app.ConfigureLocalizerOptions();

        app.MapControllers();

        await app.RunAsync();
    }
}
