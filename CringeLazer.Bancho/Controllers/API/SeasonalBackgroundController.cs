using Microsoft.AspNetCore.Mvc;

namespace CringeLazer.Bancho.Controllers.API;

[ApiController]
[Route("api/v2/seasonal-backgrounds")]
public class SeasonalBackgroundController : ControllerBase
{
    [HttpGet]
    public IActionResult GetMock()
    {
        return Ok(new object());
    }
}
