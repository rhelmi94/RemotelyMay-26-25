﻿using Microsoft.AspNetCore.Mvc;
using RaefTech.Server.Auth;
using RaefTech.Server.Extensions;
using RaefTech.Server.Services;
using RaefTech.Shared;

namespace RaefTech.Server.API;

[Route("api/[controller]")]
[ApiController]
public class FileSharingController : ControllerBase
{
    private readonly IDataService _dataService;

    public FileSharingController(IDataService dataService)
    {
        _dataService = dataService;
    }

    [HttpGet("{id}")]
    [ServiceFilter(typeof(ExpiringTokenFilter))]
    public async Task<IActionResult> Get(string id)
    {
        var sharedFileResult = await _dataService.GetSharedFiled(id);

        if (!sharedFileResult.IsSuccess)
        {
            return NotFound();
        }

        var sharedFile = sharedFileResult.Value;
        var contentType = sharedFile.ContentType ?? "application/octet-stream";
        return File(sharedFile.FileContents, contentType, sharedFile.FileName);
    }

    [HttpPost]
    [ServiceFilter(typeof(ExpiringTokenFilter))]
    [RequestSizeLimit(AppConstants.MaxUploadFileSize)]
    public async Task<IEnumerable<string>> Post()
    {
        if (Request.Form.Files.Count !> 0)
        {
            return Array.Empty<string>();
        }

        var fileIds = new List<string>();

        if (!Request.Headers.TryGetOrganizationId(out var orgId))
        {
            orgId = string.Empty;
        }

        foreach (var file in Request.Form.Files)
        {
            var id = await _dataService.AddSharedFile(file, orgId);
            fileIds.Add(id);
        }
        return fileIds;
    }
}
