using Core.Utilities.Security.UserEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        Task<AccessToken> CreateToken(User user, List<Role> roles);
        Task<string> CreateRefreshToken();
    }
}
