using studentRegistration.Application.Interfaces;
using studentRegistration.Application.Students.DTOs;
using studentRegistration.Domain.Entities;
using studentRegistration.Domain.Repositories;

namespace studentRegistration.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StudentDto>> GetAllAsync()
        {
            var students = await _repository.GetAllAsync();
            return students.Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Program = s.Program
            }).ToList();
        }

        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null) return null;

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Program = student.Program
            };
        }

        public async Task<int> CreateAsync(StudentCreateDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Program = dto.Program
            };

            await _repository.AddAsync(student);
            return student.Id;
        }

        public async Task<bool> UpdateAsync(StudentUpdateDto dto)
        {
            var student = await _repository.GetByIdAsync(dto.Id);
            if (student == null) return false;

            student.Name = dto.Name;
            student.Program = dto.Program;

            await _repository.UpdateAsync(student);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null) return false;

            await _repository.DeleteAsync(student);
            return true;
        }
    }

}
