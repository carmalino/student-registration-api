using Microsoft.AspNetCore.Mvc;
using studentRegistration.Application.Students.UseCases;
using studentRegistration.Domain.Entities;

namespace studentRegistration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly GetAllStudents _getAllStudents;

        public StudentsController(GetAllStudents getAllStudents)
        {
            _getAllStudents = getAllStudents;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAll()
        {
            var students = await _getAllStudents.ExecuteAsync();
            return Ok(students);
        }
    }
}
