using studentRegistration.Domain.Entities;

namespace studentRegistration.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<Student?> GetByIdAsync(int id);
        Task<List<Student>> GetAllAsync();
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(Student student);
        Task<Student?> GetByIdWithSubjectsAsync(int id);
        Task<Student?> GetStudentWithSubjectsAsync(int studentId);
    }
}
