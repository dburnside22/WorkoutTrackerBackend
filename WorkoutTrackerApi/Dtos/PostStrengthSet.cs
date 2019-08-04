using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutTrackerApi.Dtos
{
	public class PostStrengthSet
	{
		[Range(1,int.MaxValue)]
		public int ExerciseId { get; set; }
		public DateTime Timestamp { get; set; }
		[Range(1, int.MaxValue)]
		public int WeightInGrams { get; set; }
		[Range(1, int.MaxValue)]
		public int Reps { get; set; }
	}
}
