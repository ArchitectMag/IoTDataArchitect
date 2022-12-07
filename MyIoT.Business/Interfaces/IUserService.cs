//Projects
using MyIoT.Core.Utilities.Result;
using MyIoT.Core.Utilities.Security.UserEntity;

namespace MyIoT.Business.Interfaces;

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
