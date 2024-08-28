using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using SimpleCMS.Data;
using SimpleCMS.Seed;
using SimpleCMS.Service;

namespace SimpleCMS.Extension
{
    public static class WebAppExtension
    {

        public static async void SeedDataAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope()) {

                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var registerService = scope.ServiceProvider.GetRequiredService <IRegisterUserService>();


                try
                {
                    await SeedData.InitAsync(context, registerService);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
        
    }
}
