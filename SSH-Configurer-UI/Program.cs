using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SSH_Configurer_UI.Model;
using SSH_Configurer_UI.Services;
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
            builder.Services.AddSingleton<IDeviceService, DeviceService>(provider =>
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri("http://127.0.0.1:8000/api/devices/")
                };

                // You can also configure other HttpClient settings here if needed.

                return new DeviceService(httpClient);
            });
            builder.Services.AddSingleton<GroupService>();
            builder.Services.AddSingleton<ScriptService>();
            builder.Services.AddSingleton<KeyPairService>();
            //builder.Services.AddHttpClient<IDeviceService, DeviceService>(client =>
            //{
            //    client.BaseAddress = new Uri("http://127.0.0.1:8000/api/devices/");
            //});

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