using Microsoft.EntityFrameworkCore;
using studentRegistration.Domain.Entities;
using studentRegistration.Domain.Repositories;
using studentRegistration.Infrastructure.Persistence;

namespace studentRegistration.Infrastructure.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly StudentRegistrationDbContext _context;

        public ProfessorRepository(StudentRegistrationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Professor>> GetAllAsync()
        {
            return await _context.Professors
                .Include(r =>r.Subjects)
                .ToListAsync();
        }
    }
}
