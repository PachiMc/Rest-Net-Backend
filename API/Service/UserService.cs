using API.Data;
using API.DTO;
using API.Model;
using API.Response;
using API.Controllers;

namespace API.Service
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }
        public ServiceResponse<string> AddUser(UserDTO userDTO)
        {
            ServiceResponse<string> serviceResponse = new();
            string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(userDTO.Password);
            User user = new(userDTO.Name, passwordHash, userDTO.Admin);
            if (_context.Find<User>(userDTO.Name) is null)
            {
                _context.Add(user);
                if (_context.SaveChanges() > 0)
                {
                    serviceResponse.Data = TokenGenerator.GenerateToken(user);
                }
            }
            return serviceResponse;
        }

        public ServiceResponse<string> LogUser(UserLogDTO userDTO)
        {
            ServiceResponse<string> serviceResponse = new();
            User? user = _context.Find<User>(userDTO.Name);
            if (user is not null)
            {
                if (BCrypt.Net.BCrypt.EnhancedVerify(userDTO.Password, user.Password))
                {
                    serviceResponse.Data = TokenGenerator.GenerateToken(user);
                }
            }
            return serviceResponse;
        }
    }
}
