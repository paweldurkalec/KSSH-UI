using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SSH_Configurer_UI.Model;
using SSH_Configurer_UI.Services;
using SSH_Configurer_UI.Handlers;
using SSH_Configurer_UI.Services.Interfaces;
using Syncfusion.Blazor;
using Blazored.SessionStorage;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using SSH_Configurer_UI.Pages.List;
using Microsoft.Extensions.DependencyInjection;

namespace SSH_Configurer_UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var backend_uri = builder.Configuration["BACKEND_URI"];

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddBlazoredSessionStorage();

            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<IContentService<Device>, DeviceService>(provider =>
            {
                var httpClient = new HttpClient(new AuthenticationHandler(provider.GetService<IAuthenticationService>(), provider.GetService<IConfiguration>()))
                {
                    BaseAddress = new Uri($"{backend_uri}/api/devices/")
                };
                return new DeviceService(httpClient);
            });
            builder.Services.AddScoped<IContentService<Group>, GroupService>(provider =>
            {
                var httpClient = new HttpClient(new AuthenticationHandler(provider.GetService<IAuthenticationService>(), provider.GetService<IConfiguration>()))
                {
                    BaseAddress = new Uri($"{backend_uri}/api/groups/")
                };
                return new GroupService(httpClient);
            });
            builder.Services.AddScoped<IContentService<Script>, ScriptService>(provider =>
            {
                var httpClient = new HttpClient(new AuthenticationHandler(provider.GetService<IAuthenticationService>(), provider.GetService<IConfiguration>()))
                {
                    BaseAddress = new Uri($"{backend_uri}/api/scripts/")
                };
                return new ScriptService(httpClient);
            });
            builder.Services.AddScoped<IContentService<KeyPair>, KeyPairService>(provider =>
            {
                var httpClient = new HttpClient(new AuthenticationHandler(provider.GetService<IAuthenticationService>(), provider.GetService<IConfiguration>()))
                {
                    BaseAddress = new Uri($"{backend_uri}/api/keys/")
                };
                return new KeyPairService(httpClient);
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseWebSockets();


            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
        .UseStartup<ApplicationBuilder>()
        .UseUrls("http://*:80")
        .ConfigureAppConfiguration((context, config) =>
        {
            var env = context.HostingEnvironment;
            config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
        });
    }
}