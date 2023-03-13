using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class User
    {
        [Key]
        public string Name { get; set; }
        public string Password { get; set; }
        [DefaultValue(false)]
        public bool Admin { get; set; } = false;
        public User(string name, string password, bool admin)
        {
            Name = name;
            Password = password;
            Admin = admin;

        }

    }
}
