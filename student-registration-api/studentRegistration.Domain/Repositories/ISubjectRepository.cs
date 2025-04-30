using studentRegistration.Domain.Entities;

namespace studentRegistration.Domain.Repositories
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetAllAsync();
        Task<List<Subject>> GetByIdsWithProfessorsAsync(List<int> ids);
    }
}
