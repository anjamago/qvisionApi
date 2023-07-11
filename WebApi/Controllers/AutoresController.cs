using Application.Autores;
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
   public async Task<IActionResult> Update(CreateAutorCommand request)
   {
      var result = await _business.Create(request);
      return StatusCode(result.Code, result);
   }
   
   [HttpDelete]
   public async Task<IActionResult> Delete(CreateAutorCommand request)
   {
      var result = await _business.Create(request);
      return StatusCode(result.Code, result);
   }
   
   [HttpGet("{id}")]
   public async Task<IActionResult> Find(string id)
   {
      return await Task.FromResult(StatusCode(202));
   }
   [HttpGet]
   public async Task<IActionResult> All()
   {
      return await Task.FromResult(StatusCode(202));
   }
}