using Agremate.ApplicationContracts.Dtos.Sample;
using Agremate.ApplicationContracts.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Agremate.HttpApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SampleController : ControllerBase
{
    private readonly ISampleService _sampleService;

    public SampleController(ISampleService sampleService)
    {
        _sampleService = sampleService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> PostAsync(SampleDto sampleDto)
    {
        var result = await _sampleService.CreateAsync(sampleDto);
        return result.Status ? Ok(result) : BadRequest(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, SampleDto sampleDto)
    {
        var result = await _sampleService.UpdateAsync(id, sampleDto);
        return result.Status ? Ok(result) : NotFound(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _sampleService.DeleteAsync(id);
        return result.Status ? Ok(result) : NotFound(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _sampleService.GetAllAsync();
        return result.Status ? Ok(result) : StatusCode(500, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _sampleService.GetByIdAsync(id);
        return result.Status ? Ok(result) : NotFound(result);
    }
}
