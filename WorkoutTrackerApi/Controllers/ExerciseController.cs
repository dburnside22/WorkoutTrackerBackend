using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkoutTrackerApi.Models;

namespace WorkoutTrackerApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ExerciseController : ControllerBase
	{
		WtDbContext db;

		public ExerciseController(WtDbContext db)
		{
			this.db = db;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Exercise>> Get()
		{
			return db.Exercises.ToArray();
		}
	}
}
