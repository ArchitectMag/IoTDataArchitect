using Core.Utilities.Result;
using Microsoft.AspNetCore.Mvc;

namespace IoT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        public IActionResult ReturnApiResult(IResult result)
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

        public IActionResult ReturnApiDataResult<T>(IDataResult<T> result)
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
}
