using M1092242.Common.CustomException;
using M1092242.Models;
using M1092242.Repository.UserAuth;
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

namespace M1092242.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IUserAuthRepository userAuthRepository;
        private readonly ILogger<UserAuthController> logger;

        public UserAuthController(IUserAuthRepository userAuthRepository, ILogger<UserAuthController> logger)
        {
            this.userAuthRepository = userAuthRepository;
            this.logger = logger;
        }
        [HttpPost("login")]
        public async Task<ActionResult<PersonModel>> Login(LoginRequestModel credentials)
        {
            try
            {
                var person = await userAuthRepository.Login(credentials);
                var claims = new List<Claim> {
                                                new Claim(type: ClaimTypes.Email, value: person.EmailId),
                                                new Claim(type: ClaimTypes.Name, value: person.PersonName),
                                                new Claim(type: ClaimTypes.Role, value: person.Role.RoleName)
                                              };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity),
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(50),
                    });
                return Ok(new { Message = "Login successfull...", PersonDetails = person });

            }//Custom exception for empty requests
            catch (RequestEmptyException rex)
            {
                //Logging the error
                logger.LogError(rex.Message);
                return BadRequest(rex.Message);
            }//Custom exception for invalid credentials
            catch (InvalidCredentialException icx)
            {
                //Logging the error
                logger.LogError(icx.Message);
                return BadRequest(icx.Message);
            }
            catch (Exception ex)
            {
                //Logging the error
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong at server end. Sorry for the inconvenience...");
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<PersonModel>> Register(PersonModel newPerson)
        {
            try
            {
                await userAuthRepository.CheckEmailExist(newPerson.EmailId);
                var person = await userAuthRepository.Register(newPerson);
                return Ok(new { Message = "Registration successfull...", PersonDetails = person });

            }//Custom exception for empty requests
            catch (RequestEmptyException rex)
            {
                //Logging the error
                logger.LogError(rex.Message);
                return BadRequest(rex.Message);
            }//Custom exception for database insert exception
            catch (DbInsertException dix)
            {
                //Logging the error
                logger.LogError(dix.Message);
                return BadRequest(dix.Message);
            }//Custom exception for duplicate mail id
            catch (DuplicateMailIdException dmx)
            {
                //Logging the error
                logger.LogError(dmx.Message);
                return BadRequest(dmx.Message);
            }
            catch (Exception ex)
            {
                //Logging the error
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong at server end. Sorry for the inconvenience...");
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
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong at server end. Sorry for the inconvenience...");
            }
        }

    }
}
