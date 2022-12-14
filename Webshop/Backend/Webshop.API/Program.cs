using Webshop.API.Extensions;
using Webshop.DAL;
using Webshop.DAL.Configurations;
using Webshop.DAL.Configurations.Interfaces;
using Webshop.DAL.Domain;
using Hellang.Middleware.ProblemDetails;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "wwwroot"
});
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<WebshopDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), opt =>
    {
        opt.EnableRetryOnFailure();
    }).EnableSensitiveDataLogging();
});

builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ClaimsFactory>();
builder.Services.AddAutoMapperExtensions();
builder.Services.AddExceptionExtensions();
builder.Services.AddIdentityExtensions(configuration);

builder.Services.AddAuthenticationExtensions(configuration);

builder.Services.AddServiceExtensions();
builder.Services.AddConfigurations(configuration);
builder.Services.AddSwaggerExtension(configuration);

builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

builder.Configuration
    .SetBasePath(app.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{app.Environment.EnvironmentName}.json", true, true);

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<WebshopDbContext>();
    dbContext.Database.Migrate();
}

app.UseProblemDetails();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", configuration.GetValue<string>("IdentityServer:Name"));
        options.OAuthClientId(configuration.GetValue<string>("IdentityServer:ClientId"));
        options.OAuthClientSecret(configuration.GetValue<string>("IdentityServer:ClientSecret"));
        options.OAuthAppName(configuration.GetValue<string>("IdentityServer:Name"));
        options.OAuthUsePkce();
    });
}
app.UseHttpsRedirection();
var configService = app.Services.GetRequiredService<IWebshopConfigurationService>();
app.UseWhen(
    context => !context.Request.Path.StartsWithSegments($"/{configService.GetStaticFileRequestPath()}/{configService.GetCaffsSubdirectory()}"),
    appBuilder =>
        appBuilder.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider($"{configService.GetStaticFilePhysicalPath()}"),
            RequestPath = $"/{configService.GetStaticFileRequestPath()}"
        }));
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseIdentityServer();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Services.AddRoleSeedExtensionExtensions(configuration);

app.Run();
