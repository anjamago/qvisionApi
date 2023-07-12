using Application.Editoriales;
using Application.Editoriales.Command.Update;
using Application.Editoriales.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class EditorialController:ControllerBase
{

    private readonly IEditorialBusiness _business;

    public EditorialController(IEditorialBusiness business)
    {
        _business = business;
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateEditorialCommand request)
    {
        var result = await _business.Create(request);
        return StatusCode(result.Code, result);
    }
   
    [HttpPut]
    public async Task<IActionResult> Update(UpdateEditorialCommand request)
    {
        var result = await _business.Update(request);
        return StatusCode(result.Code, result);
    }
   
    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteEditorialCommand request)
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