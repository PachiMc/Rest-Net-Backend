using API.DTO;
using API.Response;
using Item_Service.DTO;

namespace API.Service
{
    public interface IUserService
    {
        public ServiceResponse<UserDTO> AddUser(UserDTO userDTO);
        public ServiceResponse<UserLogDTO> LogUser(UserLogDTO userDTO);
    }
}
