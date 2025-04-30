namespace studentRegistration.Application.Students.DTOs
{
    public class EnrolledSubjectDto
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = default!;
        public string ProfessorName { get; set; } = default!;
        public List<string> Classmates { get; set; } = new();
    }
}
