namespace Sprout.Exam.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMappingProfile(
            this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mapperConfig => mapperConfig.AddProfile(new MappingProfile()));
           
            services.AddTransient<IMapper>(x => mapperConfig.CreateMapper());

            return services;
        }

        public static IServiceCollection AddDtoValidations(
            this IServiceCollection services)
        {
            services.AddSingleton<IValidator<CreateEmployeeDto>, CreateEmployeeDtoValidator>();
            services.AddSingleton<IValidator<EditEmployeeDto>, EditEmployeeDtoValidator>();
            services.AddSingleton<IEmployeeFactory, EmployeeFactory>();

            return services;
        }

    }
}
