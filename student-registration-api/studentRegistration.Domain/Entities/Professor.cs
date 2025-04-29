namespace studentRegistration.Domain.Entities
{
    public class Professor
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
