using Microsoft.EntityFrameworkCore;
using PlatecBackend.Domain;

namespace PlatecBackend.Persistence;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
    }


    public DbSet<BlogPost>? BlogPosts { get; set; }

    public DbSet<PostComment>? PostComments { get; set; }
}
