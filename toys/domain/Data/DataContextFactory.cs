using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace toys.Data;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        var path = GetDbPath.Get(); 
        // var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "bank.db");
        optionsBuilder.UseSqlite($"Data Source={path}");

        return new DataContext(optionsBuilder.Options);
    }
}