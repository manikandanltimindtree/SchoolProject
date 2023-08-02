namespace SchoolProject.DTO.Students
{
    public class UpdateStudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
