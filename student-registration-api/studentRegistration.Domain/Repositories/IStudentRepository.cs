using studentRegistration.Domain.Entities;

namespace studentRegistration.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<Student?> GetByIdAsync(Guid id);
        Task<List<Student>> GetAllAsync();
        Task AddAsync(Student student);
        void Update(Student student);
        void Delete(Student student);
    }
}
