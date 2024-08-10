using Microsoft.EntityFrameworkCore;

namespace API;

class AppDbContext: DbContext
{
    // Uma tabela
    public DbSet<Todo> Todos { get; set; }


    // dizer que vai usar sqlite
     protected override void OnConfiguring(DbContextOptionsBuilder options) => 
                options.UseSqlite("DataSource=app.db;Cache=Shared")
                    .UseModel(AppDbContextModel.Instance); 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
    }
}