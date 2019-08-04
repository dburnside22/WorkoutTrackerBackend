using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTrackerApi.Models;

namespace WorkoutTrackerApi.Dtos
{
	public class GetSet
	{
		public GetSet()
		{

		}

		public GetSet(Set set)
		{
			Id = set.Id;
			WeightInGrams = set.WeightInGrams;
			DurationInMilliseconds = set.DurationInMilliseconds;
			Reps = set.Reps;
			Timestamp = set.Timestamp;
			ExerciseName = set.Exercise?.Name;
			DistanceInFeet = set.DistanceInFeet;
		}

		public int Id { get; set; }
		public string ExerciseName { get; set; }
		public int? WeightInGrams { get; set; }
		public int? DurationInMilliseconds { get; set; }
		public int? Reps { get; set; }
		public int? DistanceInFeet { get; set; }
		public DateTime Timestamp { get; set; }
		public bool WasCardio { get { return DistanceInFeet != null || DurationInMilliseconds != null; } }
		public bool WasStrength { get { return WeightInGrams != null && Reps != null; } }
	}
}
