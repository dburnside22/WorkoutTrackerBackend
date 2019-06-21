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

		protected override void OnModelCreating(ModelBuilder model)
		{
			base.OnModelCreating(model);
			model.Entity<User>().HasData(new User { Id = 1, Username = "Carson", Password = "AQAAAAEAACcQAAAAEM1tKYwnVagw1a1hzyiL+oKE8WaNQiiH779QXwtusa+w63GaUEHmaFanqJao4BCuKQ==" });
			model.Entity<User>().HasData(new User { Id = 2, Username = "Dan", Password = "AQAAAAEAACcQAAAAEM1tKYwnVagw1a1hzyiL+oKE8WaNQiiH779QXwtusa+w63GaUEHmaFanqJao4BCuKQ==" });
			model.Entity<Exercise>().HasData(new Exercise { Id = 1, Name = "Squat" });
			model.Entity<Exercise>().HasData(new Exercise { Id = 2, Name = "Deadlift" });
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Set> Sets { get; set; }
		public DbSet<Exercise> Exercises { get; set; }
	}
}
