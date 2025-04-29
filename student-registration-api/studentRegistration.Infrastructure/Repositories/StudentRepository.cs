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

        public async Task<Student?> GetByIdAsync(Guid id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
        }

        public void Delete(Student student)
        {
            _context.Students.Remove(student);
        }
    }
}
