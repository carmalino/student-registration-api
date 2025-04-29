using Microsoft.EntityFrameworkCore;
using studentRegistration.Domain.Entities;

namespace studentRegistration.Infrastructure.Persistence
{
    public class StudentRegistrationDbContext : DbContext
    {
        public StudentRegistrationDbContext(DbContextOptions<StudentRegistrationDbContext> options)
            : base(options) { }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Professor> Professors => Set<Professor>();
        public DbSet<Subject> Subjects => Set<Subject>();
        public DbSet<StudentSubject> StudentSubjects => Set<StudentSubject>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Student)
                .WithMany(s => s.Subjects)
                .HasForeignKey(ss => ss.StudentId);

            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Subject)
                .WithMany(s => s.Students)
                .HasForeignKey(ss => ss.SubjectId);

            modelBuilder.Entity<Subject>()
                .HasOne(s => s.Professor)
                .WithMany(p => p.Subjects)
                .HasForeignKey(s => s.ProfessorId);
        }
    }
}
