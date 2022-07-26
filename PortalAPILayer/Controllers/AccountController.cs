using ApplicationServices.Implementation.Identity;
using Entities.Models;
using Infrastructures.Implementation.DataAccess.Oracle.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace PortalAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtHandler _jwtHandler;

        public AccountController(ModelContext context, UserManager<ApplicationUser> userManager, JwtHandler jwtHandler)
        {
            _context = context;
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.Email);
            if (user == null
            || !await _userManager.CheckPasswordAsync(user, loginRequest.
           Password))
                ///Выдаем результат в случае неуспешного входа
                return Unauthorized(new LoginResult()
                {
                    Success = false,
                    Message = "Invalid Email or Password."
                });

            var secToken = await _jwtHandler.GetTokenAsync(user);
            //создаем json-представление токена
            var jwt = new JwtSecurityTokenHandler().WriteToken(secToken);
            //Выдаем результат в случае успеха
            return Ok(new LoginResult()
            {
                Success = true,
                Message = "Login successful",
                Token = jwt
            });
        }
    }
}
