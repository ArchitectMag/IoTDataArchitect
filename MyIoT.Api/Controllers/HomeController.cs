//System
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

//Projects
using MyIoT.Entities.Models;
using MyIoT.Business.Interfaces;
using MyIoT.Core.Utilities.Result;

namespace MyIoT.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArduinoController : ControllerBase
{
    private readonly ILogger<ArduinoController> _logger;
    private readonly ILightService _lightService;

    public ArduinoController(ILogger<ArduinoController> logger, ILightService lightService)
    {
        _logger = logger; _lightService = lightService;
    }

    [HttpGet("getlight")]
    public async Task<(Light,string)> GetLight(int id)
    {
        return ResultManager.ReturnApiDataResult(await _lightService.GetLight(id));
    }

    [HttpGet("getlightlistbytime")]
    public async Task<(List<Light>, string)> GetLightListByTime(DateTime date)
    {
        return ResultManager.ReturnApiDataResult(await _lightService.GetLightListByTime(date));
    }

    [Authorize]
    [HttpGet("getlightlist")]
    public async Task<(List<Light>,string)> GetLightList()
    {
        return ResultManager.ReturnApiDataResult(await _lightService.GetLightList());
    }

    [HttpPost("addlight")]
    public async Task<string> AddLight(int lightSensorValue)
    {
        return ResultManager.ReturnApiResult(await _lightService.AddLight(lightSensorValue));
    }

    [HttpDelete("deletelight")]
    public async Task<string> DeleteLight(int id)
    {
        return ResultManager.ReturnApiResult(await _lightService.DeleteLight(id));
    }

    [HttpPut("updatelight")]
    public async Task<string> UpdateLight(Light light)
    {
        return ResultManager.ReturnApiResult(await _lightService.UpdateLight(light));
    }
}