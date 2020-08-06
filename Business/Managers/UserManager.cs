using System;
using Business.Interfaces;
using Core.Utilities.Messages;
using Core.Utilities.Result;
using Core.Utilities.Security.UserEntity;
using DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Managers
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private IMessage _message;

        public UserManager(IUserDal userDal, IMessage message)
        {
            _userDal = userDal;
            _message = message;
        }

        public async Task<IResult> AddUser(User user)
        {
            await _userDal.Add(user);
            return new SuccessResult(_message.GetMessage("AddedSucced"));
        }

        public async Task<IResult> DeleteUser(int id)
        {
            User model = await _userDal.Get(u => u.Id == id);
            await _userDal.Delete(model);
            return new SuccessResult(_message.GetMessage("DeletedSucced"));
        }

        public async Task<IDataResult<List<Role>>> GetRoles(User user)
        {
            return new SuccessDataResult<List<Role>>(await _userDal.GetRoles(user));
        }

        public async Task<IDataResult<User>> GetUserByMail(string mail)
        {
            return new SuccessDataResult<User>(await _userDal.Get(u => u.Email == mail));
        }

        public async Task<IDataResult<User>> GetUserByRefreshToken(string refreshToken)
        {
            return new SuccessDataResult<User>(await _userDal.Get(u => u.RefreshToken == refreshToken && u.RefreshTokenEndDate > DateTime.UtcNow));
        }

        public async Task<IDataResult<List<User>>> GetUsers()
        {
            return new SuccessDataResult<List<User>>(await _userDal.GetList());
        }

        public async Task<IResult> UpdateUser(User user)
        {
            await _userDal.Update(user);
            return new SuccessResult(_message.GetMessage("UpdatedSucced"));
        }
    }
}
