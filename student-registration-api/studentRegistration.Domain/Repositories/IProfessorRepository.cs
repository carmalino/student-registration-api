using studentRegistration.Domain.Entities;

namespace studentRegistration.Domain.Repositories
{
    public interface IProfessorRepository
    {
        Task<List<Professor>> GetAllAsync();
    }
}
