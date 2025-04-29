using studentRegistration.Domain.Entities;
using studentRegistration.Domain.Repositories;

namespace studentRegistration.Application.Students.UseCases
{
    public class GetAllStudents
    {
        private readonly IStudentRepository _repository;

        public GetAllStudents(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Student>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
