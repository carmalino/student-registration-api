using studentRegistration.Application.Students.DTOs;

namespace studentRegistration.Application.Interfaces
{
    public interface ISubjectService
    {
        Task<List<SubjectDto>> GetAllAsync();
    }
}
