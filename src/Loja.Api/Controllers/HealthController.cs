using Microsoft.AspNetCore.Mvc;

namespace Loja.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class HealthController : ControllerBase
{
    /// <summary>Usado pelo front (e futuramente pelo deploy) para saber se a API está no ar.</summary>
    [HttpGet]
    public IActionResult Get() => Ok(new { status = "online", horario = DateTime.UtcNow });
}
