using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ChatApp.Core;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ChatApp.WebServer
{




    public class ApiController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApiController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        [Route("api/login")]
        public async Task<ApiResponse<LoginResultApiModel>> LoginAsync([FromBody] LoginCredentialApiModel loginModel)
        {
            var invalidErrorMessage = "Invalid username or password";

            var errorResponse = new ApiResponse<LoginResultApiModel>()
            {
                //TODO Localize
                ErrorMessage = invalidErrorMessage
            };

            if (loginModel?.UsernameOrEmail == null || string.IsNullOrWhiteSpace(loginModel.UsernameOrEmail))
                return errorResponse;

            var isEmail = loginModel.UsernameOrEmail.Contains("@");

            var user = isEmail ?
                await _userManager.FindByEmailAsync(loginModel.UsernameOrEmail) :
                await _userManager.FindByNameAsync(loginModel.UsernameOrEmail);

            if (user == null)
                return errorResponse;

            var isValidPassword = await _userManager.CheckPasswordAsync(user, loginModel.Password);

            if (!isValidPassword)
                return errorResponse;

            var username = user.UserName;

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, username)
            };

            var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Container.Configuration["Jwt:SecretKey"]))
                , SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: Container.Configuration["Jwt:Issuer"],
                audience: Container.Configuration["Jwt:audience"],
                claims: claims,
                expires: DateTime.Now.AddMonths(1),
                signingCredentials: credentials
                );

            return new ApiResponse<LoginResultApiModel>
            {
                Response = new LoginResultApiModel()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Username = user.UserName,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                }
            };
        }


        [AuthorizeToken]
        [Route("api/private")]
        public IActionResult Private()
        {
            var user = HttpContext.User;

            return Ok(new { privateData = $"secrets" });
        }

        public class AuthorizeToken : AuthorizeAttribute
        {
            public AuthorizeToken()
            {
                AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
            }
        }

    }
}
