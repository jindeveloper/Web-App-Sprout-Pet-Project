namespace Sprout.Exam.Persistence
{
    public static class   DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                                                        configuration.GetConnectionString("DefaultConnection")));

            services
                    .AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer().AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication().AddIdentityServerJwt();

           

            return services;
        }

        public static IServiceCollection AddPersistenceForTransactions(this IServiceCollection services, 
                                                                        IConfiguration configuration)
        {
           
            services.AddDbContext<ApplicationEmployeeContext>(options => options.UseSqlServer(configuration.GetConnectionString("EmployeeDbContextConnection")));
            services.AddTransient<IUnitOfWork, Sprout.Exam.Persistence.UnitOfWork.UnitOfWork>();
            services.AddTransient<IEmployeeRepository<Employee>, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
