using Microsoft.EntityFrameworkCore;
using studentRegistration.Domain.Entities;
using studentRegistration.Domain.Repositories;
using studentRegistration.Infrastructure.Persistence;

namespace studentRegistration.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentRegistrationDbContext _context;

        public StudentRepository(StudentRegistrationDbContext context)
        {
            _context = context;
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task AddAsync(Student student)
        {
            _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
        public async Task<Student?> GetByIdWithSubjectsAsync(int id)
        {
            return await _context.Students
                .Include(s => s.Subjects)
                    .ThenInclude(ss => ss.Subject)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<Student?> GetStudentWithSubjectsAsync(int studentId)
        {
            return await _context.Students
                .Include(s => s.Subjects)
                    .ThenInclude(ss => ss.Subject)
                        .ThenInclude(sub => sub.Professor)
                .Include(s => s.Subjects)
                    .ThenInclude(ss => ss.Subject)
                        .ThenInclude(sub => sub.Students)
                            .ThenInclude(ss2 => ss2.Student)
                .FirstOrDefaultAsync(s => s.Id == studentId);
        }
    }
}
