using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutTrackerApi.Dtos
{
	public class Login
	{
		[Required]
		public string Username { get; set; }
	}
}
