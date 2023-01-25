using MedicalShopManagementSystem.Models;
using MedicalShopManagementSystem.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MedicalShopManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<UserController> logger;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserModel>> CreateUser(UserModel newUser)
        {
            try
            {
                if (newUser == null)
                {
                    return BadRequest("Request contains no data");
                }
                if (await userRepository.CheckEmailExist(newUser.Email) != null)
                {
                    return BadRequest("Email id is already in use");
                }
                var addedUser = await userRepository.AddUser(newUser);
                return Ok(addedUser);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Somethig went wrong!!! Registration failed");
            }
        }
        [HttpPut]
        public async Task<ActionResult<UserModel>> UpdateUser(UserModel updatedUser)
        {
            try
            {
                if (updatedUser == null)
                {
                    return BadRequest();
                }
                if (await userRepository.GetUser(updatedUser.Id) == null)
                {
                    return BadRequest("User not present");
                }
                if (await userRepository.CheckEmailExist(updatedUser.Email) != null)
                {
                    return BadRequest("Email id already in use");
                }
                var result = await userRepository.UpdateUser(updatedUser);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //[BindProperty]
        //public string Name { get; set; }

        [HttpPost("login")]
        public async Task<ActionResult<UserModel>> Login([FromForm] LoginRequestModel login)
        {
            try
            {

                var loggedUser = await userRepository.Login(login);
                if (loggedUser == null)
                {
                    return BadRequest("Invalid credentials");
                }

                var claims = new List<Claim> {
                                                new Claim(type: ClaimTypes.Email, value: loggedUser.Email),
                                                new Claim(type: ClaimTypes.Name, value: loggedUser.Name),
                                                new Claim(type: ClaimTypes.Role, value: loggedUser.UserRole.RoleType)
                                              };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity),
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    });
                return Ok(loggedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                var users = await userRepository.GetUsers();
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetUser(int id)
        {
            try
            {
                var user = await userRepository.GetUser(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await userRepository.GetUser(id);
                if (user == null)
                {
                    return BadRequest($"User with id: {id} not present");
                }
                await userRepository.DeleteUser(id);
                return Ok($"User with id: {id} deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpGet("logout")]
        public async Task<ActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Ok("Logged out successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
