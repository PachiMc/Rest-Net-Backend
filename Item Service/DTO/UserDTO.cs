namespace API.DTO
{
    public class UserDTO
    {
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool Admin { get; set; } = false;
    }
}
