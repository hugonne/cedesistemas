using Cedesistemas.WheresMyStuff.Models;
using Cedesistemas.WheresMyStuff.WebApi.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cedesistemas.WheresMyStuff.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/{id?}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationUser> _roleManager;
        private readonly IConfiguration _config;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationUser> roleManager,
            IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            if (!TryValidateModel(login))
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(login.Email);

            if(user == null)
            {
                return BadRequest("Invalid username");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if(!result.Succeeded)
            {
                return BadRequest("Invalid password");
            }

            var token = GetJwtToken(user);
            return Ok(token);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDto register)
        {
            //var user = _userManager.FindByNameAsync(register.Email).Result;
            if (!TryValidateModel(register))
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser
            {
                UserName = register.Email,
                Email = register.Email
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if(!result.Succeeded)
            {
                string errorList = string.Empty;
                foreach(var error in result.Errors)
                {
                    errorList += error.Code + ", ";
                }
                return BadRequest(errorList);
            }

            return Ok();
        }

        public IActionResult ChangePassword()
        {
            return Ok();
        }

        private object GetJwtToken(ApplicationUser user)
        {
            //Create the token
            var claims = new List<Claim>
            {
                //This claim is needed so _userManager.GetUserId returns the Id instead of the username
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim("jugo", "mora")
            };

            //Get roles for user and add them to claims
            //var roles = _userManager.GetRolesAsync(user).Result;
            //claims.AddRange(roles.Select(a => new Claim(ClaimTypes.Role, a)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _config["Tokens:Issuer"], 
                _config["Tokens:Audience"], 
                claims,
                expires: DateTime.Now.AddYears(1), 
                signingCredentials: creds);
            var results = new { 
                Token = new JwtSecurityTokenHandler().WriteToken(token), 
                Expiration = token.ValidTo 
            };
            
            return results;
        }
    }
}
