using Microsoft.AspNetCore.Mvc;
using studentRegistration.Application.Interfaces;

namespace studentRegistration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var professors = await _professorService.GetAllAsync();
            return Ok(professors);
        }
    }
}
