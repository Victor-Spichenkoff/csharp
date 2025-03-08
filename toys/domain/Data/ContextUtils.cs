using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using toys.banco;

namespace toys.Data;

public class ContextUtils
{
    // public static void ConfigureDI()
    public static  IServiceScope? ConfigureDI()
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<DataContext>()
            // services e repos aqui
            .AddTransient<BankRepository>()
            .BuildServiceProvider();

        // Criar banco se não existir
        using (var scope = serviceProvider.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<DataContext>();
            db.Database.EnsureCreated();
            // db.Database.Migrate();
        }

        return serviceProvider.CreateScope();
    }
}