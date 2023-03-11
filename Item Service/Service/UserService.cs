using API.Data;
using API.DTO;
using API.Model;
using API.Response;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Microsoft.AspNetCore.Identity;
using Item_Service.DTO;

namespace API.Service
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }
        public ServiceResponse<UserDTO> AddUser(UserDTO userDTO)
        {
            ServiceResponse<UserDTO> serviceResponse = new();
            string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(userDTO.Password);
            User user = new(userDTO.Name, passwordHash, userDTO.Admin);
            if(_context.Find<User>(userDTO.Name) is null) { 
               _context.Add(user);
            if (_context.SaveChanges() > 0)
            {
                serviceResponse.Data = userDTO;
            }
            }
            return serviceResponse;
        }

        public ServiceResponse<UserLogDTO> LogUser(UserLogDTO userDTO)
        {
            ServiceResponse<UserLogDTO> serviceResponse = new();
            User? user = _context.Find<User>(userDTO.Name);
            if (user is not null)
            {
                if (BCrypt.Net.BCrypt.EnhancedVerify(userDTO.Password, user.Password)) {
                    serviceResponse.Data = userDTO;
                }
            }
            return serviceResponse;
        }
    }
}
