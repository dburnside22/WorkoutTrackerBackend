using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutTrackerApi.Dtos
{
	public class PostSet
	{
		public int ExerciseId { get; set; }
		public int? WeightInGrams { get; set; }
		public int? DurationInMilliseconds { get; set; }
		public int? Reps { get; set; }
	}
}
