using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DineDeck.Api.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class ApiController : ControllerBase
{

}
