using studentRegistration.Application.Students.DTOs;

namespace studentRegistration.Application.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllAsync();
        Task<StudentDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(StudentCreateDto dto);
        Task<bool> UpdateAsync(StudentUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<EnrollSubjectsResultDto> EnrollSubjectsAsync(EnrollSubjectsDto dto);
    }
}
