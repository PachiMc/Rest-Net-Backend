using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class User
    {
        [Key]
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
        public User(string name, string password, bool admin)
        {
            Name = name;
            Password = password;
            Admin = admin;

        }

    }
}
