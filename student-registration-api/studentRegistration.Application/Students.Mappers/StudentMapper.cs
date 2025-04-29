using studentRegistration.Application.Students.DTOs;
using studentRegistration.Domain.Entities;

namespace studentRegistration.Application.Students.Mappers;

public static class StudentMapper
{
    public static StudentDto ToDto(Student student)
    {
        return new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            Program = student.Program
        };
    }

    public static Student ToEntity(StudentCreateDto dto)
    {
        return new Student
        {
            Name = dto.Name,
            Program = dto.Program
        };
    }

    public static void UpdateEntity(Student student, StudentUpdateDto dto)
    {
        student.Name = dto.Name;
        student.Program = dto.Program;
    }
}
