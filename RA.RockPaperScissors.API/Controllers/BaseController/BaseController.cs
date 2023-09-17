using Microsoft.AspNetCore.Mvc;

namespace RA.RockPaperScissors.API.Controllers.BaseController;

[ApiController]
[Route("api/[controller]")]
[ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
public abstract class BaseController : ControllerBase
{
}