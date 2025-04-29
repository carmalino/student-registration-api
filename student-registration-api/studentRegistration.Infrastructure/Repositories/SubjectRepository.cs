using Microsoft.EntityFrameworkCore;
using studentRegistration.Domain.Entities;
using studentRegistration.Domain.Repositories;
using studentRegistration.Infrastructure.Persistence;

namespace studentRegistration.Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly StudentRegistrationDbContext _context;

        public SubjectRepository(StudentRegistrationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Subject>> GetByIdsWithProfessorsAsync(List<int> ids)
        {
            return await _context.Subjects
                .Include(s => s.Professor)
                .Where(s => ids.Contains(s.Id))
                .ToListAsync();
        }
    }
}
