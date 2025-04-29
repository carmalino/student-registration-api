namespace studentRegistration.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Program { get; set; } = default!;

        public ICollection<StudentSubject> Subjects { get; set; } = new List<StudentSubject>();
    }
}
