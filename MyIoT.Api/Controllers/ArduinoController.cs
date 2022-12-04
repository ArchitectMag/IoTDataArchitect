//System
using System;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

//Projects
using MyIoT.Entities.Models;
using MyIoT.Business.Interfaces;

namespace MyIoT.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArduinoController : BaseApiController
{
    private readonly ILogger<ArduinoController> _logger;
    private readonly ILightService _lightService;

    public ArduinoController(ILogger<ArduinoController> logger, ILightService lightService)
    {
        _logger = logger; _lightService = lightService;
    }


    [HttpGet("getlight")]
    public async Task<IActionResult> GetLight(int id)
    {
        return ReturnApiDataResult(await _lightService.GetLight(id));
    }

    [HttpGet("getlightlistbytime")]
    public async Task<IActionResult> GetLightListByTime(DateTime date)
    {
        return ReturnApiDataResult(await _lightService.GetLightListByTime(date));
    }

    [Authorize]
    [HttpGet("getlightlist")]
    public async Task<IActionResult> GetLightList()
    {
        return ReturnApiDataResult(await _lightService.GetLightList());
    }

    [HttpPost("addlight")]
    public async Task<IActionResult> AddLight(int lightSensorValue)
    {
        Light light = new Light
        {
            Date = DateAndTime.Now,
            LightSensorValue = lightSensorValue
        };

        return ReturnApiResult(await _lightService.AddLight(light));
    }

    [HttpDelete("deletelight")]
    public async Task<IActionResult> DeleteLight(int id)
    {
        return ReturnApiResult(await _lightService.DeleteLight(id));
    }

    [HttpPut("updatelight")]
    public async Task<IActionResult> UpdateLight(Light light)
    {
        return ReturnApiResult(await _lightService.UpdateLight(light));
    }
}
