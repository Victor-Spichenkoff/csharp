using Microsoft.AspNetCore.Mvc;

namespace Teddy.Controllers;

[ApiController]
[Route("/teste")]
public class TesteController
{
    [HttpGet]
    public string Get()
    {
        return "Olá";
    }

    [HttpGet("{id}")]
    public string GetById(int? id)
    {
        return $"ID é: {id}";
    }
}
