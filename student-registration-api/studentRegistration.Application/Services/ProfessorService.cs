using studentRegistration.Application.Interfaces;
using studentRegistration.Domain.Entities;
using studentRegistration.Domain.Repositories;

namespace studentRegistration.Application.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _repository;

        public ProfessorService(IProfessorRepository repository)
        {
            _repository = repository;
        }
        public Task<List<Professor>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }
    }
}
