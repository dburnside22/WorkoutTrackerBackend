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
using WorkoutTrackerApi.Dtos;
using WorkoutTrackerApi.Models;

namespace WorkoutTrackerApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		IConfiguration config;
		WtDbContext db;
		IPasswordHasher<User> passwordHasher;

		public AccountController(IConfiguration config, WtDbContext db, IPasswordHasher<User> passwordHasher)
		{
			this.passwordHasher = passwordHasher;
			this.db = db;
			this.config = config;
		}

		[AllowAnonymous]
		[HttpPost]
		public ActionResult Register([FromBody]Login request)
		{
			var user = new User { Username = request.Username };
			user.Password = passwordHasher.HashPassword(user, request.Password);
			db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Added;
			db.SaveChanges();
			return Ok();
		}

		[AllowAnonymous]
		[HttpPost]
		public ActionResult<JwtToken> Login([FromBody]Login request)
		{
			var user = authenticate(request);

			if (user != null)
			{
				return Ok(buildToken(user));
			}

			return Unauthorized();
		}

		JwtToken buildToken(User user)
		{
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var claims = new Claim[] { new Claim("UserId", user.Id.ToString()) };
			var token = new JwtSecurityToken(config["Jwt:Issuer"],
			  config["Jwt:Issuer"],
			  expires: DateTime.Now.AddMinutes(30),
			  signingCredentials: creds,
			  claims: claims);

			return new JwtToken { Token = new JwtSecurityTokenHandler().WriteToken(token), Expiration = token.ValidTo };
		}

		User authenticate(Login login)
		{
			var user = db.Users.FirstOrDefault(x => login.Username == x.Username);
			if (user == null)
				return null;
			var result = passwordHasher.VerifyHashedPassword(user, user.Password, login.Password);
			switch(result)
			{
				case PasswordVerificationResult.Success:
				case PasswordVerificationResult.SuccessRehashNeeded:
					return user;
				case PasswordVerificationResult.Failed:
				default:
					return null;
			}
		}
	}
}