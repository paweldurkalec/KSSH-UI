using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SSH_Configurer_UI.Model;
using SSH_Configurer_UI.Services;
using SSH_Configurer_UI.Services.Interfaces;
using Syncfusion.Blazor;

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
            builder.Services.AddSingleton<IContentService<Device>, DeviceService>(provider =>
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri("http://127.0.0.1:8000/api/devices/")
                };
                return new DeviceService(httpClient);
            });
            builder.Services.AddSingleton<IContentService<Group>, GroupService>(provider =>
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri("http://127.0.0.1:8000/api/groups/")
                };
                return new GroupService(httpClient);
            });
            builder.Services.AddSingleton<IContentService<Script>, ScriptService>(provider =>
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri("http://127.0.0.1:8000/api/scripts/")
                };
                return new ScriptService(httpClient);
            });
            builder.Services.AddSingleton<IContentService<KeyPair>, KeyPairService>(provider =>
            {
                var httpClient = new HttpClient
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


            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}