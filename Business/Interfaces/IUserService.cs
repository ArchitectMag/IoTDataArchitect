using Core.Utilities.Result;
using Core.Utilities.Security.UserEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<IDataResult<List<User>>> GetUsers();
        Task<IDataResult<List<Role>>> GetRoles(User user);
        Task<IDataResult<User>> GetUserByMail(string mail);
        Task<IDataResult<User>> GetUserByRefreshToken(string refreshToken);
        Task<IResult> AddUser(User user);
        Task<IResult> UpdateUser(User user);
        Task<IResult> DeleteUser(int id);
    }
}
