using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API;

public static class AppDbContextModel
{
    public static readonly IModel Instance = BuildModel();

    private static IModel BuildModel()
    {
        var modelBuilder = new ModelBuilder();
        var entityBuilder = modelBuilder.Entity<Todo>();
        entityBuilder.HasKey(e => e.Id);

        return modelBuilder.FinalizeModel();
    }
}