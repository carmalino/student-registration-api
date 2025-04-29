using studentRegistration.Application.Students.UseCases;
using studentRegistration.Domain.Repositories;
using studentRegistration.Infrastructure.Repositories;

namespace studentRegistration.API.studentRegistration.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            // Agrega aquí los otros repositorios
            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<GetAllStudents>();
            services.AddScoped<CreateStudent>();
            // Aquí vas agregando más casos de uso según los implementes
            return services;
        }
    }
}
