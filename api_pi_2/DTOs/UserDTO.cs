namespace api_pi_2.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Role { get; set; }
    }
}
