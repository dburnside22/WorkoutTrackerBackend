using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutTrackerApi.Dtos
{
	public class PostStrengthSet
	{
		public int ExerciseId { get; set; }
		public DateTime Timestamp { get; set; }
		public int WeightInGrams { get; set; }
		public int Reps { get; set; }
	}
}
