using System.Text.Json.Serialization;
using API;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateSlimBuilder(args);


//ligar o db a minha API
//cuida de gerenciar as instancias (só uma, abre e fecha sozinho)

builder.Services.AddDbContext<AppDbContext>();





builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();






app.MapGet("/v1/todos", (AppDbContext context) => {
    var todos = context.Todos.ToList(); // Verifique se existem itens na lista
    if (todos == null)
    {
        return Results.NotFound("No todos found");
    }

    return Results.Ok(todos); 
});





app.Run();


[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
