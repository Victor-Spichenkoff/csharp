using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using toys.banco;

namespace toys.Data;

public class DataContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=bank.db");
}