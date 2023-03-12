using API.DTO;
using API.Response;
using API.Service;
using Item_Service.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<ServiceResponse<string>> SignUp(UserDTO userDTO)
        {
            ServiceResponse<string> response = _userService.AddUser(userDTO);
            response.Success = false;
            response.Message = "Error creating a new user";
            if (response.Data is not null)
            {
                response.Success = true;
                response.Message = "User created";
            }
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<ServiceResponse<string>> LogIn(UserLogDTO userDTO)
        {
            ServiceResponse<string> response = _userService.LogUser(userDTO);
            response.Success = false;
            response.Message = "Failed to login";
            if (response.Data is not null) {
                response.Success = true;
                response.Message = "Login success";
            }
            return Ok(response);
        }
    }
}
