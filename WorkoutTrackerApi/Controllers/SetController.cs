using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkoutTrackerApi.Dtos;
using WorkoutTrackerApi.Models;

namespace WorkoutTrackerApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	[Authorize]
	public class SetController : ControllerBase
	{
		WtDbContext db;

		public SetController(WtDbContext db)
		{
			this.db = db;
		}

		[HttpGet]
		public ActionResult<IEnumerable<GetSet>> Get([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
		{
			var userId = int.Parse(User.FindFirst("UserId").Value);
			return db.Sets.Where(s => s.UserId == userId && s.Timestamp >= startDate && s.Timestamp <= endDate)
				.Select(s => new GetSet
				{
					Id = s.Id,
					DurationInMilliseconds = s.DurationInMilliseconds,
					DistanceInFeet = s.DistanceInFeet,
					Reps = s.Reps,
					ExerciseName = s.Exercise.Name,
					Timestamp = s.Timestamp,
					WeightInGrams = s.WeightInGrams
				}).ToArray();
		}

		[HttpPost]
		public ActionResult<GetSet> PostStrengthSet([FromBody]PostStrengthSet request)
		{
			var userId = int.Parse(User.FindFirst("UserId").Value);
			var exercise = db.Exercises.Find(request.ExerciseId);
			if (exercise == null)
				return BadRequest("Invalid ExerciseId");
			var newSet = new Set
			{
				UserId = userId,
				ExerciseId = request.ExerciseId,
				Reps = request.Reps,
				WeightInGrams = request.WeightInGrams,
				Timestamp = request.Timestamp
			};
			db.Entry(newSet).State = Microsoft.EntityFrameworkCore.EntityState.Added;
			db.SaveChanges();
			newSet.Exercise = exercise;
			return Ok(new GetSet(newSet));
		}

		[HttpPost]
		public ActionResult<GetSet> PostCardioSet([FromBody]PostCardioSet request)
		{
			var userId = int.Parse(User.FindFirst("UserId").Value);
			var exercise = db.Exercises.Find(request.ExerciseId);
			if (exercise == null)
				return BadRequest("Invalid ExerciseId");
			var newSet = new Set
			{
				UserId = userId,
				ExerciseId = request.ExerciseId,
				DurationInMilliseconds = request.DurationInMilliseconds,
				DistanceInFeet = request.DistanceInFeet,
				Timestamp = request.Timestamp
			};
			db.Entry(newSet).State = Microsoft.EntityFrameworkCore.EntityState.Added;
			db.SaveChanges();
			newSet.Exercise = exercise;
			return Ok(new GetSet(newSet));
		}
	}
}
