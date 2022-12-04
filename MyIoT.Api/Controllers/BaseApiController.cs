//System
using Microsoft.AspNetCore.Mvc;

//Projects
using Utilities = MyIoT.Core.Utilities.Result;

namespace MyIoT.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    public IActionResult ReturnApiResult(Utilities.IResult result)
    {
        if (result.Success)
        {
            return Ok(result.Message);
        }
        else
        {
            return BadRequest(result.Message);
        }

    }

    public IActionResult ReturnApiDataResult<T>(Utilities.IDataResult<T> result)
    {
        if (result.Success)
        {
            return Ok(result.Data);
        }
        else
        {
            return BadRequest(result.Message);
        }

    }
}
