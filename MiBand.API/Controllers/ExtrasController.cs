using MiBand.API.Domain.Models;
using MiBand.API.Domain.Services.Communications;
using MiBand.API.Domain.Services;
using MiBand.API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;

namespace MiBand.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtrasController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;
        public ExtrasController(IConfiguration config, ISessionService sessionService, IMapper mapper)
        {
            _config = config;
            _sessionService = sessionService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] SaveLoginResource userLogin)
        {
            var user = await Authenticate(userLogin);
            if (user != null)
            {
                SaveLoginResource resource = new SaveLoginResource() { 
                    Username = user.Resource.Username,
                    Email = user.Resource.Email,
                    Password = user.Resource.Password
                };
                var token = GenerateToken(resource);
                return Ok(token);
            }

            return NotFound("user not found");
        }

        //To generate token
        private string GenerateToken(SaveLoginResource user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            { 
                new Claim(ClaimTypes.NameIdentifier,user.Username)
                //new Claim(ClaimTypes.NameIdentifier,user.Email)
                //new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        //To authenticate user
        private Task<SessionResponse> Authenticate(SaveLoginResource userLogin)
        {
            var currentUser = _sessionService.FindByUsernameOrEmailAndPasswordAsync(userLogin.Username, userLogin.Email, userLogin.Password);
            //var resource = _mapper.Map<Task<SessionResponse>, SaveLoginResource>(currentUser);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }
    }
}
