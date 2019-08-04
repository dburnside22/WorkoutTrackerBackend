using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutTrackerApi.Models
{
	public class Set
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public virtual User User { get; set; }
		public int ExerciseId { get; set; }
		public virtual Exercise Exercise { get; set; }
		public int? WeightInGrams { get; set; }
		public int? DurationInMilliseconds { get; set; }
		public int? Reps { get; set; }
		public int? DistanceInFeet { get; set; }
		public DateTime Timestamp { get; set; }
	}
}
