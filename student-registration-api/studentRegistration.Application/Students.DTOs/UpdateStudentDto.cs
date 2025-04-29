namespace studentRegistration.Application.Students.DTOs
{
    public class UpdateStudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Program { get; set; } = default!;
    }
}
