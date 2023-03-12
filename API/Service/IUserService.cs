using API.DTO;
using API.Response;
using Item_Service.DTO;

namespace API.Service
{
    public interface IUserService
    {
        public ServiceResponse<string> AddUser(UserDTO userDTO);
        public ServiceResponse<string> LogUser(UserLogDTO userDTO);
    }
}
