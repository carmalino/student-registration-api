using studentRegistration.Domain.Entities;

namespace studentRegistration.Application.Interfaces
{
    public interface IProfessorService
    {
        Task<List<Professor>> GetAllAsync();
    }
}
