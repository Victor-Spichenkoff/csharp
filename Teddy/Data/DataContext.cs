using Microsoft.EntityFrameworkCore;
using Teddy.Models;

namespace Teddy.Data;

public class DataContext : DbContext
{
    //no final (base), chama o contrutor do pai (DbContext)
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {}


    public DbSet<Category> Categories { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Pokemon> Pokemon { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Reviewer> Reviewers { get; set; }
    //n-n
    public DbSet<PokemonOwner> PokemonOwners { get; set; }
    public DbSet<PokemonCategory> PokemonCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PokemonCategory>()
            .HasKey(pc => new { pc.PokemonId, pc.CategoryId });

        modelBuilder.Entity<PokemonCategory>()
            .HasOne(p => p.Pokemon)
            .WithMany(pc => pc.PokemonCategories)
            .HasForeignKey(p => p.PokemonId);


        modelBuilder.Entity<PokemonCategory>()
            .HasOne(c => c.Category)
            .WithMany(pc => pc.PokemonCategories)
            .HasForeignKey(c => c.CategoryId);



        //pokemon-owner
        modelBuilder.Entity<PokemonOwner>()
            .HasKey(po => new { po.PokemonId, po.OwnerId });

        modelBuilder.Entity<PokemonOwner>()
            .HasOne(p => p.Pokemon)//PO tem relação 1-n/n-n com pokemon
            .WithMany(pc => pc.PokemonOwners)
            .HasForeignKey(p => p.PokemonId);


        modelBuilder.Entity<PokemonOwner>()
            .HasOne(o => o.Owner)
            .WithMany(pc => pc.PokemonOwners)
            .HasForeignKey(o => o.OwnerId);
    }
}