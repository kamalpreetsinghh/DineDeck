using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DineDeck.Api.Controllers;

[ApiController]
[Authorize]
public class ApiController : ControllerBase
{

}
