using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutTrackerApi.Models
{
	public class WtDbContext : DbContext
	{
		public WtDbContext(DbContextOptions<WtDbContext> options)
			: base(options)
		{
			
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Set> Sets { get; set; }
		public DbSet<Exercise> Exercises { get; set; }
	}
}
