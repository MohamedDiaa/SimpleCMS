using SimpleCMS.Data;
using SimpleCMS.Seed;

namespace SimpleCMS.Extension
{
    public static class WebAppExtension
    {

        public static async void SeedDataAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope()) {

                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                try
                {
                    SeedData.InitAsync(context);
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
