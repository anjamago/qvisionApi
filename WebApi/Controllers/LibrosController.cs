using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class LibrosController:ControllerBase
{
    [HttpGet]
    public IActionResult Get() => StatusCode(202);
}