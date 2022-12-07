//Projects
using MyIoT.Core.Utilities.Security.UserEntity;

namespace MyIoT.Core.Utilities.Security.JWT;

public interface ITokenHelper
{
    Task<AccessToken> CreateToken(User user, List<Role> roles);
    Task<string> CreateRefreshToken();
}
