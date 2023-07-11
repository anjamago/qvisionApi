using Application.Autores;
using Application.Autores.Command.Update;
using Application.Autores.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutoresController : ControllerBase
{
   private readonly IAutorBusiness _business;

   public AutoresController(IAutorBusiness business)
   {
      _business = business;
   }


   [HttpPost]
   public async Task<IActionResult> Create(CreateAutorCommand request)
   {
      var result = await _business.Create(request);
      return StatusCode(result.Code, result);
   }
   
   [HttpPut]
   public async Task<IActionResult> Update(UpdateAutorCommand request)
   {
      var result = await _business.Update(request);
      return StatusCode(result.Code, result);
   }
   
   [HttpDelete]
   public async Task<IActionResult> Delete(DeleteAutorCommand request)
   {
      var result = await _business.Delete(request);
      return StatusCode(result.Code, result);
   }
   
   [HttpGet("{id}")]
   public async Task<IActionResult> Find(int id)
   {
        var result = await _business.Find(id);
        return StatusCode(result.Code, result);
    }

   [HttpGet]
   public async Task<IActionResult> All()
   {
        var result = await _business.All();
        return StatusCode(result.Code, result);
   }
}