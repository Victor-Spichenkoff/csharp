using Microsoft.EntityFrameworkCore;
using Teddy;
using Teddy.Data;
using Teddy.Interfaces;
using Teddy.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

///dependency injection
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();



//sedding
builder.Services.AddTransient<Seed>();
//transient == adiciona coisas no começo (inicio do projeto e não start)
//adicionar automapper (DTO)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//Context
builder.Services.AddDbContext<DataContext>(options =>
{
    //vou usar sql, e essa é a connection string
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});






var app = builder.Build();

//sedding
if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory?.CreateScope())
    {
        var service = scope?.ServiceProvider.GetService<Seed>();
        service?.SeedDataContext();
    }
}





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
