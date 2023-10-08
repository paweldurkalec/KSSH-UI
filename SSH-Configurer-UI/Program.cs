using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SSH_Configurer_UI.Model;
using SSH_Configurer_UI.Services;
using SSH_Configurer_UI.Handlers;
using SSH_Configurer_UI.Services.Interfaces;
using Syncfusion.Blazor;
using Blazored.SessionStorage;
using Microsoft.JSInterop;

namespace SSH_Configurer_UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<IContentService<Device>, DeviceService>(provider =>
            {
                var httpClient = new HttpClient(new AuthenticationHandler(provider.GetService<IAuthenticationService>()))
                {
                    BaseAddress = new Uri("http://127.0.0.1:8000/api/devices/")
                };
                return new DeviceService(httpClient);
            });
            builder.Services.AddScoped<IContentService<Group>, GroupService>(provider =>
            {
                var httpClient = new HttpClient(new AuthenticationHandler(provider.GetService<IAuthenticationService>()))
                {
                    BaseAddress = new Uri("http://127.0.0.1:8000/api/groups/")
                };
                return new GroupService(httpClient);
            });
            builder.Services.AddScoped<IContentService<Script>, ScriptService>(provider =>
            {
                var httpClient = new HttpClient(new AuthenticationHandler(provider.GetService<IAuthenticationService>()))
                {
                    BaseAddress = new Uri("http://127.0.0.1:8000/api/scripts/")
                };
                return new ScriptService(httpClient);
            });
            builder.Services.AddScoped<IContentService<KeyPair>, KeyPairService>(provider =>
            {
                var httpClient = new HttpClient(new AuthenticationHandler(provider.GetService<IAuthenticationService>()))
                {
                    BaseAddress = new Uri("http://127.0.0.1:8000/api/keys/")
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
    }
}