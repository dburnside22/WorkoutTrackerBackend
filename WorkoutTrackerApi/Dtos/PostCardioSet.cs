using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutTrackerApi.Dtos
{
	public class PostCardioSet
	{
		public int ExerciseId { get; set; }
		public DateTime Timestamp { get; set; }
		public int? DurationInMilliseconds { get; set; }
		public int? DistanceInFeet { get; set; }
	}
}
