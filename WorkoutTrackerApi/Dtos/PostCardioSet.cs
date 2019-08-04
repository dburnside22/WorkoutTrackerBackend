using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutTrackerApi.Dtos
{
	public class PostCardioSet
	{
		[Range(1, int.MaxValue)]
		public int ExerciseId { get; set; }
		public DateTime Timestamp { get; set; }
		[Range(1,int.MaxValue)]
		public int? DurationInMilliseconds { get; set; }
		[Range(1, int.MaxValue)]
		public int? DistanceInFeet { get; set; }
	}
}
