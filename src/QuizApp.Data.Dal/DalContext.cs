using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data.Dal.Base;
using QuizApp.Data.Dal.Models;
using QuizApp.Data.Dal.Static;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Data.Dal
{
	public class DalContext : IdentityDbContext<IdentityUser>
	{
		public DalContext(DbContextOptions<DalContext> options) : base(options) { }
		public DbSet<Quiz> Quiz { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<Answer> Answers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.HasDefaultSchema(schema: DbGlobals.SchemaName);
			modelBuilder.Entity<Quiz>()
				.HasMany(p => p.Questions);

			modelBuilder.Entity<Question>()
				.HasMany(p => p.Answers)
				.WithOne(p => p.Question)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Answer>()
				.HasOne(p => p.Question)
				.WithMany(p => p.Answers)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<QuizResult>()
				.HasOne(p => p.User);
				
			base.OnModelCreating(modelBuilder);

			const string ADMIN_ID = "c5713835-f70b-4fbb-ab7e-6e6320bb59ee";
			const string ROLE_ID = "b0dabe9b-f8b7-48f4-b74a-6a6671130765";
			const string USER_ID = "009dc675-6328-4f92-b206-b3311908e306";
			const string USER_ROLE_ID = "402b9b75-2f6d-4f40-8d59-26ef95c51744";
			modelBuilder.Entity<IdentityRole>().HasData(
				new IdentityRole
				{
					Id = ROLE_ID,
					Name = "Admin",
					NormalizedName = "Admin"
				}
			);

			modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = USER_ROLE_ID,
				Name = "QuizUser",
				NormalizedName = "Quiz User"
			});

			PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
			modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
			{
				Id = ADMIN_ID,
				UserName = "admin",
				NormalizedUserName = "Admin",
				Email = "russell.griffith+quizapp+admin@gmail.com",
				NormalizedEmail = "russell.griffith+quizapp+admin@gmail.com",
				EmailConfirmed = true,
				PasswordHash = hasher.HashPassword(null, "sys_admin"),
				SecurityStamp = string.Empty
			});

			modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
			{
				Id = USER_ID,
				UserName = "russdawgbass",
				NormalizedUserName = "Russ Dawg Bass",
				Email = "russell.griffith@gmail.com",
				NormalizedEmail = "russell.griffith@gmail.com",
				EmailConfirmed = true,
				PasswordHash = hasher.HashPassword(null, "logcabin"),
				SecurityStamp = string.Empty
			});

			modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				RoleId = ROLE_ID,
				UserId = ADMIN_ID,
			});
			modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				RoleId = USER_ROLE_ID,
				UserId = USER_ID,
			});


		}

		public override int SaveChanges()
		{
			Audit();
			return base.SaveChanges();
		}

		public async Task<int> SaveChangesAsync()
		{
			Audit();
			return await base.SaveChangesAsync();
		}

		private void Audit()
		{
			Validate();
			var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseModel && (x.State == EntityState.Added || x.State == EntityState.Modified));
			foreach (var entry in entries)
			{
				if (entry.State == EntityState.Added)
				{
					((BaseModel)entry.Entity).Created = DateTime.UtcNow;
				}
			((BaseModel)entry.Entity).Modified = DateTime.UtcNow;
			}
		}

		private void Validate()
		{
			var entities = from e in ChangeTracker.Entries()
						   where e.State == EntityState.Added
							   || e.State == EntityState.Modified
						   select e.Entity;
			foreach (var entity in entities)
			{
				var validationContext = new ValidationContext(entity);
				Validator.ValidateObject(entity, validationContext);
			}
		}
	}
}
