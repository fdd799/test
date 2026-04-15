using Microsoft.EntityFrameworkCore;
using backend.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<UsersEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UsersEntity>().HasData(
            new UsersEntity
            {
                Id = 1,
                Name = "Hank",
                Email = "hank@example.com"
            }
        );
    }
}