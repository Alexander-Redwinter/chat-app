using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChatApp.WebServer
{
    public class AuthorizeToken : AuthorizeAttribute
    {
        public AuthorizeToken()
        {
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }
    }

    public class ApiController : Controller
    {
        [Route("api/login")]
        public IActionResult Login()
        {
            var username = "Redwinter";

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, username),
                new Claim(ClaimsIdentity.DefaultNameClaimType, username)
            };

            var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Container.Configuration["Jwt:SecretKey"]))
                , SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: Container.Configuration["Jwt:Issuer"],
                audience: Container.Configuration["Jwt:audience"],
                claims: claims,
                expires: DateTime.Now.AddMonths(3),
                signingCredentials: credentials
                );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }


        [AuthorizeToken]
        [Route("api/private")]
        public IActionResult Private()
        {
            var user = HttpContext.User;
            
            return Ok(new { privateData= $"secrets"})
        }

    }
}
