using Microsoft.AspNetCore.Mvc;
using RaefTech.Server.Auth;
using RaefTech.Server.Services;
using RaefTech.Shared.Entities;

namespace RaefTech.Server.API;

[Route("api/[controller]")]
[ApiController]
public class SavedScriptsController : ControllerBase
{
    private readonly IDataService _dataService;

    public SavedScriptsController(IDataService dataService)
    {
        _dataService = dataService;
    }

    [ServiceFilter(typeof(ExpiringTokenFilter))]
    [HttpGet("{scriptId}")]
    public async Task<ActionResult<SavedScript>> GetScript(Guid scriptId)
    {
        var result =  await _dataService.GetSavedScript(scriptId);
        if (!result.IsSuccess)
        {
            return NotFound();
        }

        return result.Value;
    }
}
