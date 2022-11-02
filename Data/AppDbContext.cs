using auten.Entities;
using Microsoft.EntityFrameworkCore;

namespace auten.Data;

public class AppDbContext:DbContext
{
    public DbSet<User>? Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> option):base(option) { }
}