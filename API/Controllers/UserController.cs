using API.DTO;
using API.Response;
using API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

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
                CookieOptions cookieOptions = new()
                {
                    Secure = true,
                    Path = "/",
                    HttpOnly = false,
                    Expires = DateTime.Now.AddDays(1),
                };
                Response.Cookies.Append("jwt", response.Data, cookieOptions);
            }
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<ServiceResponse<string>> Logout()
        {
            ServiceResponse<string> response = new() { Success = true, Message = "Logout sucess" };
            Response.Cookies.Delete("jwt", new CookieOptions
            {
                HttpOnly = false,
                SameSite = SameSiteMode.None,
                Secure = true
            });
            return Ok(response);
        }
        [Authorize]
        [HttpGet]
        public ActionResult<ServiceResponse<UserDTO>> GetPayload()
        {
            string name = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)!.Value;
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)!.Value;
            UserDTO userDTO = new()
            {
                Name = name,
                Admin = role == "admin" ? true : false
            };
            return new ServiceResponse<UserDTO> { Success = true, Data = userDTO, Message = "Payload jwt sucess" };
        }


        [HttpPost]
        public ActionResult<ServiceResponse<string>> SignIn(UserLogDTO userDTO)
        {
            ServiceResponse<string> response = _userService.LogUser(userDTO);
            response.Success = false;
            response.Message = "Failed to login";
            if (response.Data is not null)
            {
                response.Success = true;
                response.Message = "Login success";
                CookieOptions cookieOptions = new()
                {
                    Secure = true,
                    Path = "/",
                    HttpOnly = false,
                    Expires = DateTime.Now.AddDays(1),
                };
                Response.Cookies.Append("jwt", response.Data, cookieOptions);
            }
            return Ok(response);
        }
    }
}
