using Microsoft.AspNetCore.Mvc;
using studentRegistration.Application.Interfaces;
using studentRegistration.Application.Students.DTOs;

namespace studentRegistration.API.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateDto dto)
        {
            var id = await _studentService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var result = await _studentService.UpdateAsync(dto);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _studentService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }

        [HttpPost("{id}/enroll-subjects")]
        public async Task<IActionResult> EnrollSubjects(int id, EnrollSubjectsDto dto)
        {
            if (id != dto.StudentId) return BadRequest("El ID del estudiante no coincide con el cuerpo de la solicitud.");

            var result = await _studentService.EnrollSubjectsAsync(dto);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Message);
        }

    }
}

