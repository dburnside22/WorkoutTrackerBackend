using Microsoft.AspNetCore.Authorization;
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
using WorkoutTrackerApi.Dtos;
using WorkoutTrackerApi.Models;

namespace WorkoutTrackerApi.Controllers
{
	[Route("api/[controller]/[action]")]
	public class AccountController : ControllerBase
	{
		IConfiguration config;
		WtDbContext db;

		public AccountController(IConfiguration config, WtDbContext db)
		{
			this.db = db;
			this.config = config;
		}

		[AllowAnonymous]
		[HttpPost]
		public IActionResult Login([FromBody]Login request)
		{
			if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var user = Authenticate(request);

			if (user != null)
			{
				var tokenString = BuildToken(user);
				return Ok(new { token = tokenString });
			}

			return Unauthorized();
		}

		string BuildToken(User user)
		{
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var claims = new Claim[] { new Claim("UserId", user.Id.ToString()) };
			var token = new JwtSecurityToken(config["Jwt:Issuer"],
			  config["Jwt:Issuer"],
			  expires: DateTime.Now.AddMinutes(30),
			  signingCredentials: creds,
			  claims: claims);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		User Authenticate(Login login)
		{
			return db.Users.FirstOrDefault(x => login.Username == x.Username);			
		}
	}
}