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
            // 1. Cargar estudiante con sus inscripciones
            var student = await _repository.GetByIdWithSubjectsAsync(dto.StudentId);
            if (student == null)
            {
                return new EnrollSubjectsResultDto
                {
                    Success = false,
                    Message = "Estudiante no encontrado."
                };
            }

            // 2. Validar número máximo de materias
            if (dto.SubjectIds.Count > 3)
            {
                return new EnrollSubjectsResultDto
                {
                    Success = false,
                    Message = "No se pueden inscribir más de 3 materias."
                };
            }

            // 3. Obtener las materias solicitadas (con su profesor)
            var allSubjects = await _subjectRepository.GetByIdsWithProfessorsAsync(dto.SubjectIds);

            // 4. Validar que no haya profesor repetido entre las nuevas
            var professorIds = allSubjects.Select(s => s.ProfessorId).ToList();
            if (professorIds.Distinct().Count() != professorIds.Count)
            {
                return new EnrollSubjectsResultDto
                {
                    Success = false,
                    Message = "No se pueden inscribir materias con el mismo profesor."
                };
            }

            // 5. Reemplazar inscripciones existentes:
            //    - Limpiar todas las materias actuales
            student.Subjects.Clear();

            //    - Agregar las nuevas
            foreach (var subj in allSubjects)
            {
                student.Subjects.Add(new StudentSubject
                {
                    StudentId = student.Id,
                    SubjectId = subj.Id
                });
            }

            // 6. Persistir cambios
            await _repository.UpdateAsync(student);

            return new EnrollSubjectsResultDto
            {
                Success = true,
                Message = "Inscripción actualizada exitosamente."
            };
        }


        public async Task<List<EnrolledSubjectDto>> GetSubjectsByStudentIdAsync(int studentId)
        {
            var student = await _repository.GetStudentWithSubjectsAsync(studentId);
            if (student == null) return new List<EnrolledSubjectDto>();

            var result = student.Subjects.Select(ss => new EnrolledSubjectDto
            {
                SubjectId = ss.Subject.Id,
                SubjectName = ss.Subject.Name,
                ProfessorName = ss.Subject.Professor.Name,
                Classmates = ss.Subject.Students
                    .Where(s => s.StudentId != studentId)
                    .Select(s => s.Student.Name)
                    .ToList()
            }).ToList();

            return result;
        }

    }

}
