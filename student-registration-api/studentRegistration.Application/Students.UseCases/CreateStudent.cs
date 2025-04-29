using studentRegistration.Application.Students.DTOs;
using studentRegistration.Application.Students.Mappers;
using studentRegistration.Domain.Repositories;

namespace studentRegistration.Application.Students.UseCases;

public class CreateStudent
{
    private readonly IStudentRepository _repository;

    public CreateStudent(IStudentRepository repository)
    {
        _repository = repository;
    }

    public async Task<StudentDto> ExecuteAsync(CreateStudentDto dto)
    {
        // Validación básica (opcional, podrías moverlo a otro lugar si usas FluentValidation u otra técnica)
        if (string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(dto.Program))
            throw new ArgumentException("Nombre y programa son requeridos.");

        var student = StudentMapper.ToEntity(dto);
        await _repository.AddAsync(student);
        return StudentMapper.ToDto(student);
    }
}
