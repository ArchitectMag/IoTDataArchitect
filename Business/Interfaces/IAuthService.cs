using Core.Utilities.Result;
using Core.Utilities.Security.JWT;
using Core.Utilities.Security.UserEntity;
using Entities.ViewModels;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAuthService
    {
        Task<IDataResult<User>> Register(UserRegister userRegister);
        Task<IDataResult<User>> Login(UserLogin userLogin);
        Task<IResult> UserExists(string mail);
        Task<IDataResult<AccessToken>> CreateAccessToken(User user);
        Task<IDataResult<AccessToken>> RefreshTokenLogin(string refreshToken);
    }
}
