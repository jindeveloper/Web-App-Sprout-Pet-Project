
namespace Sprout.Exam.Infrastructure
{
    public static class MigrationManager
    {
        public static async Task<IApplicationBuilder> MigrateDatabaseAsync(this IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                userManager.Logger = logger.CreateLogger<UserManager<ApplicationUser>>();

                await SeedData.SeedAsync(userManager);

                return app;
            }
        }
    }
}