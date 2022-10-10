using AutoMapper;
using HotelListing.DataAccess.AuthService;
using HotelListing.Models;
using HotelListing.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelListingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public AccountController(UserManager<ApplicationUser> userManager, ILogger<AccountController> logger, IMapper mapper, IAuthManager authManager)
        {
            _userManager = userManager;            
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Registration Attempt for {userDTO.Email}");
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _mapper.Map<ApplicationUser>(userDTO);
                user.UserName = userDTO.Email; //Storing the Email as Username also

                var result = await _userManager.CreateAsync(user, userDTO.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                } 
                else
                {
                    await _userManager.AddToRoleAsync(user, userDTO.Role);
                    return Accepted();
                }   
            }   
            catch (Exception Ex)
            {
                _logger.LogError(Ex, $"Something went wrong in {nameof(Register)}");
                return Problem($"Something went wrong in {nameof(Register)}", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDTO)
        {
            _logger.LogInformation($"Login Attempt for {loginUserDTO.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if(!await _authManager.ValidateUser(loginUserDTO))
                {
                    return Unauthorized();
                }
                return Accepted(new { Token = await _authManager.GenerateToken() });
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, $"Something went wrong in {nameof(Login)}");
                return Problem($"Something went wrong in {nameof(Login)}", statusCode: 500);
            }
        }
    }
}
