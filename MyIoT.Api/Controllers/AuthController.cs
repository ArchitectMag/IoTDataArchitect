//System
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

//Projects
using MyIoT.Business.Interfaces;
using MyIoT.Entities.ViewModels;
using MyIoT.Core.Utilities.Security.JWT;

namespace MyIoT.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLogin userLogin)
    {
        var login = await _authService.Login(userLogin);
        if (!login.Success)
        {
            return BadRequest(login.Message);
        }

        var result = await _authService.CreateAccessToken(login.Data);
        if (result.Success)
        {
            return Ok(result.Data);
        }

        return BadRequest(result.Message);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegister userRegister)
    {
        var userExist = await _authService.UserExists(userRegister.Email);
        if (!userExist.Success)
        {
            return BadRequest(userExist.Message);
        }

        var register = await _authService.Register(userRegister);
        var result = await _authService.CreateAccessToken(register.Data);
        if (result.Success)
        {
            return Ok(result.Data);
        }

        return BadRequest(result.Message);
    }

    [AllowAnonymous]
    [HttpPost("refreshtokenlogin")]
    public async Task<IActionResult> RefreshTokenLogin(AccessToken token)
    {
        var result = await _authService.RefreshTokenLogin(token.RefreshToken);
        if (result.Success)
        {
            return Ok(result.Data);
        }

        return BadRequest(result.Message);
    }
}
