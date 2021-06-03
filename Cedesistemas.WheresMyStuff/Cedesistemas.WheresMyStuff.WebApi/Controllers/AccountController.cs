using Cedesistemas.WheresMyStuff.Models;
using Cedesistemas.WheresMyStuff.WebApi.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDto register)
        {
            if(!TryValidateModel(register))
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
    }
}
