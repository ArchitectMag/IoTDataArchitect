//Projects
using MyIoT.Entities.ViewModels;
using MyIoT.Business.Interfaces;
using MyIoT.Core.Utilities.Result;
using MyIoT.Core.Utilities.Localization;
using MyIoT.Core.Utilities.Security.JWT;
using MyIoT.Core.Utilities.Security.Hashing;
using MyIoT.Core.Utilities.Security.UserEntity;

namespace MyIoT.Business.Managers;

public class AuthManager : IAuthService
{
    private IUserService _userService;
    private ITokenHelper _tokenHelper;
    private ILocalizationHelper _sharedLocalizer;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper, ILocalizationHelper sharedLocalizer)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _sharedLocalizer = sharedLocalizer;
    }

    public async Task<IDataResult<AccessToken>> CreateAccessToken(User user)
    {
        IDataResult<List<Role>> roles = await _userService.GetRoles(user);
        var accessToken = await _tokenHelper.CreateToken(user, roles.Data);
        await SaveRefreshToken(user, await _tokenHelper.CreateRefreshToken());
        return new SuccessDataResult<AccessToken>(accessToken, _sharedLocalizer.GetString("TokenCreat"));
    }

    public async Task<IDataResult<User>> Login(UserLogin userLogin)
    {
        var existUser = await _userService.GetUserByMail(userLogin.Email);
        if (existUser == null)
        {
            return new ErrorDataResult<User>(_sharedLocalizer.GetString("ExistUser"));
        }

        if (!HashingHelper.VerifyPasswordHash(userLogin.Password, existUser.Data.PasswordHash, existUser.Data.PasswordSalt))
        {
            return new ErrorDataResult<User>(_sharedLocalizer.GetString("PasswordError"));
        }

        await SaveRefreshToken(existUser.Data, await _tokenHelper.CreateRefreshToken());

        return new SuccessDataResult<User>(existUser.Data);
    }

    public async Task<IDataResult<AccessToken>> RefreshTokenLogin(string refreshToken)
    {
        var user = await _userService.GetUserByRefreshToken(refreshToken);
        if (user.Data != null)
        {
            var token = await CreateAccessToken(user.Data);
            await SaveRefreshToken(user.Data, await _tokenHelper.CreateRefreshToken());
            return token;
        }
        return null;
    }

    public async Task<IDataResult<User>> Register(UserRegister userRegister)
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(userRegister.Password, out passwordHash, out passwordSalt);
        var user = new User
        {
            Email = userRegister.Email,
            FistName = userRegister.FirstName,
            LastName = userRegister.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            RefreshToken = await _tokenHelper.CreateRefreshToken(),
            RefreshTokenEndDate = DateTime.UtcNow.AddMonths(1),
            Status = true
        };
        await _userService.AddUser(user);
        return new SuccessDataResult<User>(user, _sharedLocalizer.GetString("SuccessfullyRegistered"));
    }

    public async Task<IResult> SaveRefreshToken(User user, string refreshToken)
    {
        var model = await _userService.GetUserByMail(user.Email);
        if (model.Data != null)
        {
            user.RefreshToken = refreshToken;
            user.RefreshTokenEndDate = DateTime.UtcNow.AddMonths(1);
            await _userService.UpdateUser(user);
            return new SuccessResult(_sharedLocalizer.GetString("SuccessSaveRefreshToken"));
        }
        return new ErrorResult(_sharedLocalizer.GetString("NotSuccessSaveRefreshToken"));
    }

    public async Task<IResult> UserExists(string mail)
    {
        if (await _userService.GetUserByMail(mail) != null)
        {
            return new ErrorResult(_sharedLocalizer.GetString("UserAlreadyRegister"));
        }
        return new SuccessResult();
    }
}
