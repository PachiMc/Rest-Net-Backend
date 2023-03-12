using API.DTO;
using API.Response;

namespace API.Service
{
    public interface IUserService
    {
        public ServiceResponse<string> AddUser(UserDTO userDTO);
        public ServiceResponse<string> LogUser(UserLogDTO userDTO);
    }
}
