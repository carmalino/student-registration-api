using studentRegistration.Application.Interfaces;
using studentRegistration.Application.Students.DTOs;
using studentRegistration.Domain.Entities;
using studentRegistration.Domain.Repositories;

namespace studentRegistration.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly ISubjectRepository _subjectRepository;

        public StudentService(IStudentRepository repository, ISubjectRepository subjectRepository)
        {
            _repository = repository;
            _subjectRepository = subjectRepository;
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

        public async Task<EnrollSubjectsResultDto> EnrollSubjectsAsync(EnrollSubjectsDto dto)
        {
            var student = await _repository.GetByIdWithSubjectsAsync(dto.StudentId);
            if (student == null)
            {
                return new EnrollSubjectsResultDto
                {
                    Success = false,
                    Message = "Estudiante no encontrado."
                };
            }

            if (student.Subjects.Count + dto.SubjectIds.Count > 3)
            {
                return new EnrollSubjectsResultDto
                {
                    Success = false,
                    Message = "No se pueden inscribir más de 3 materias."
                };
            }

            var allSubjects = await _subjectRepository.GetByIdsWithProfessorsAsync(dto.SubjectIds);

            var currentProfessors = student.Subjects.Select(s => s.Subject.ProfessorId).ToList();
            var newProfessors = allSubjects.Select(s => s.ProfessorId).ToList();

            if (newProfessors.Any(p => currentProfessors.Contains(p)))
            {
                return new EnrollSubjectsResultDto
                {
                    Success = false,
                    Message = "No se pueden inscribir materias con profesores ya asignados."
                };
            }

            foreach (var subject in allSubjects)
            {
                student.Subjects.Add(new StudentSubject
                {
                    StudentId = student.Id,
                    SubjectId = subject.Id
                });
            }

            await _repository.UpdateAsync(student);

            return new EnrollSubjectsResultDto
            {
                Success = true,
                Message = "Materias inscritas exitosamente."
            };
        }

    }

}
