namespace api_pi_2.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Surname { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Patronymic { get; set; } = null!;

        public string? Login { get; set; }

        public string? Password { get; set; }

        public int Role { get; set; }
    }
}
