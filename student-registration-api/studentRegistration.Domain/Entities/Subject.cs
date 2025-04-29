namespace studentRegistration.Domain.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int Credits { get; set; } = 3;

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; } = default!;

        public ICollection<StudentSubject> Students { get; set; } = new List<StudentSubject>();
    }
}
