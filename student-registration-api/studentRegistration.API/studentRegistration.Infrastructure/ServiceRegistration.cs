using studentRegistration.Application.Interfaces;
using studentRegistration.Application.Services;
using studentRegistration.Domain.Repositories;
using studentRegistration.Infrastructure.Repositories;

namespace studentRegistration.API.studentRegistration.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            // Agrega aquí los otros repositorios
            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            // Aquí vas agregando más casos de uso según los implementes
            return services;
        }
    }
}
