namespace studentRegistration.Application.Students.DTOs
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int ProfessorId { get; set; }
        public string ProfessorName { get; set; } = default!;
    }
}
