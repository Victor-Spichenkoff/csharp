using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace toys.Data;

 public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
 {
     public DataContext CreateDbContext(string[] args)
     {
         var path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "bank.db");
         var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
         optionsBuilder.UseSqlite($"Data Source={path}");
 
         return new DataContext(optionsBuilder.Options);
     }
 }