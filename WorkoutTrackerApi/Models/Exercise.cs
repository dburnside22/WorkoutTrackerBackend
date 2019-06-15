using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WorkoutTrackerApi.Models
{
	public class Exercise
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
	}
}
