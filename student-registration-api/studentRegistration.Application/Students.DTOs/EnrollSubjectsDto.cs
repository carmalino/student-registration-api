namespace studentRegistration.Application.Students.DTOs
{
    public class EnrollSubjectsDto
    {
        public int StudentId { get; set; }
        public List<int> SubjectIds { get; set; } = new();
    }
}
