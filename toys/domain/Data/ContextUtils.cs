using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using toys.banco;

namespace toys.Data;

public static class ContextUtils
{
    public static IServiceProvider ConfigureDI()
    {
        var serviceCollection = new ServiceCollection();

        // Adicionar o DbContext
        serviceCollection.AddDbContext<DataContext>(options =>
        {
            var path = GetDbPath.Get();//Path.Combine(Directory.GetCurrentDirectory(), "Data", "bank.db");
            options.UseSqlite($"Data Source={path}");
        });

        // Adicionar Repositórios e Serviços
        serviceCollection.AddTransient<BankRepository>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        

        var scope = serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<DataContext>();
        
        
        // db.Database.EnsureDeleted();
        // db.Database.EnsureCreated();
        // db.Database.Migrate();
        
        // using (var scope = serviceProvider.CreateScope())
        // {
        //     var db = scope.ServiceProvider.GetRequiredService<DataContext>();
        //     // db.Database.Migrate();
        //     db.Database.EnsureCreated();
        // }

        return serviceProvider;
    }
}

public static class GetDbPath
{
    public static string Get()
    {
        var projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));

        // return Path.Combine(projectRoot, "Data", "bank.db");
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bank.db");
    }
}


// public class ContextUtils
// {
//     // public static void ConfigureDI()
//     public static  IServiceScope? ConfigureDI()
//     {
//         var serviceProvider = new ServiceCollection()
//             .AddDbContext<DataContext>()
//             // services e repos aqui
//             .AddTransient<BankRepository>()
//             .BuildServiceProvider();
//
//         // Criar banco se não existir
//         using (var scope = serviceProvider.CreateScope())
//         {
//             var db = scope.ServiceProvider.GetRequiredService<DataContext>();
//             db.Database.EnsureCreated();
//             // db.Database.Migrate();
//         }
//
//         return serviceProvider.CreateScope();
//     }
// }