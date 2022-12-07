//Projects
using MyIoT.Entities.ViewModels;
using MyIoT.Core.Utilities.Result;
using MyIoT.Core.Utilities.Security.JWT;
using MyIoT.Core.Utilities.Security.UserEntity;

namespace MyIoT.Business.Interfaces;

public interface IAuthService
{
    Task<IDataResult<User>> Register(UserRegister userRegister);
    Task<IDataResult<User>> Login(UserLogin userLogin);
    Task<IResult> UserExists(string mail);
    Task<IDataResult<AccessToken>> CreateAccessToken(User user);
    Task<IDataResult<AccessToken>> RefreshTokenLogin(string refreshToken);
}
