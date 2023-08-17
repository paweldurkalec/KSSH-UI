using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SSH_Configurer_UI.Model;
using SSH_Configurer_UI.Services;

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
            builder.Services.AddSingleton<DeviceService>();
            builder.Services.AddSingleton<GroupService>();
            builder.Services.AddSingleton<ScriptService>();
            builder.Services.AddSingleton<PublicKeyService>();

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