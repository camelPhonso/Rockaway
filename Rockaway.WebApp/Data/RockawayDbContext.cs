using Microsoft.EntityFrameworkCore;
using Rockaway.WebApp.Data.Entities;
using Rockaway.WebApp.Data.Sample;

namespace Rockaway.WebApp.Data;

public class RockawayDbContext(DbContextOptions<RockawayDbContext> options) : DbContext(options)
{
	public DbSet<Artist> Artists { get; set; } = default!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<Artist>().HasData(SampleData.Artists.AllArtists);
	}
}
