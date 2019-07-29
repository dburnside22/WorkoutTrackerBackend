using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutTrackerApi.Dtos
{
	public class JwtToken
	{
		public string Token { get; set; }
		public DateTime Expiration { get; set; }
	}
}
