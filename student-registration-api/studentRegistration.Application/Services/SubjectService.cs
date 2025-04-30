using studentRegistration.Application.Interfaces;
using studentRegistration.Application.Students.DTOs;
using studentRegistration.Domain.Repositories;

namespace studentRegistration.Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repository;

        public SubjectService(ISubjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SubjectDto>> GetAllAsync()
        {
            var subjects = await _repository.GetAllAsync();

            return subjects.Select(s => new SubjectDto
            {
                Id = s.Id,
                Name = s.Name,
                ProfessorId = s.ProfessorId,
                ProfessorName = s.Professor.Name
            }).ToList();
        }
    }
}
