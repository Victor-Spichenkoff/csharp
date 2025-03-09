using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using toys.banco;

namespace toys.Data;

public class DataContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transference> Transferences { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bank.db");
            var path = GetDbPath.Get();
            Console.WriteLine("PATH base: " + path);
            optionsBuilder.UseSqlite($"Data Source={path}");
        }
    }
}