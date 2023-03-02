using Microsoft.AspNetCore.Mvc;

namespace DineDeck.Api.Controllers;

[Route("[controller]")]
public class DinnersController : ApiController
{
    [HttpPost]
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}