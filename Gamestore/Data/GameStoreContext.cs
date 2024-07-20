using Gamestore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{

public DbSet<Game> Games => Set<Game>();
public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData( 
            new {Id=1,Name="War"},
            new {Id=2,Name="Shooting"},
            new {Id=3,Name="offline"},
            new {Id=4,Name="online"},
            new {Id=5,Name="open world"}
         );
    }

}
