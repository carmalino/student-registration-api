using Microsoft.AspNetCore.Mvc;
using studentRegistration.Application.Students.UseCases;
using studentRegistration.Application.Students.DTOs;
using studentRegistration.Domain.Entities;

namespace studentRegistration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly GetAllStudents _getAllStudents;
        private readonly CreateStudent _createStudent;

        public StudentsController(GetAllStudents getAllStudents, CreateStudent createStudent)
        {
            _getAllStudents = getAllStudents;
            _createStudent = createStudent;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAll()
        {
            var students = await _getAllStudents.ExecuteAsync();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDto dto)
        {
            var id = await _createStudent.ExecuteAsync(dto);
            return Ok(id);
        }
    }
}
