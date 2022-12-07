//Projects
using MyIoT.Business.Interfaces;
using MyIoT.Core.Utilities.Result;
using MyIoT.DataAccess.Interfaces;
using MyIoT.Core.Utilities.Localization;
using MyIoT.Core.Utilities.Security.UserEntity;

namespace MyIoT.Business.Managers;

public class UserManager : IUserService
{
    private IUserDal _userDal;
    private ILocalizationHelper _sharedLocalizer;

    public UserManager(IUserDal userDal, ILocalizationHelper sharedLocalizer)
    {
        _userDal = userDal;
        _sharedLocalizer = sharedLocalizer;
    }

    public async Task<IResult> AddUser(User user)
    {
        await _userDal.AddAsync(user);
        return new SuccessResult(_sharedLocalizer.GetString("AddedSucced"));
    }

    public async Task<IResult> DeleteUser(int id)
    {
        User model = await _userDal.GetAsync(u => u.Id == id);
        await _userDal.DeleteAsync(model);
        return new SuccessResult(_sharedLocalizer.GetString("DeletedSucced"));
    }

    public async Task<IDataResult<List<Role>>> GetRoles(User user)
    {
        return new SuccessDataResult<List<Role>>(await _userDal.GetRoles(user));
    }

    public async Task<IDataResult<User>> GetUserByMail(string mail)
    {
        return new SuccessDataResult<User>(await _userDal.GetAsync(u => u.Email == mail));
    }

    public async Task<IDataResult<User>> GetUserByRefreshToken(string refreshToken)
    {
        return new SuccessDataResult<User>(await _userDal.GetAsync(u => u.RefreshToken == refreshToken && u.RefreshTokenEndDate > DateTime.UtcNow));
    }

    public async Task<IDataResult<List<User>>> GetUsers()
    {
        return new SuccessDataResult<List<User>>(await _userDal.GetListAsync());
    }

    public async Task<IResult> UpdateUser(User user)
    {
        await _userDal.UpdateAsync(user);
        return new SuccessResult(_sharedLocalizer.GetString("UpdatedSucced"));
    }
}
