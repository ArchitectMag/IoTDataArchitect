using System;
using Business.Interfaces;
using Core.Utilities.Messages;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Core.Utilities.Security.UserEntity;
using Entities.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Managers
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IMessage _message;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IMessage message)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _message = message;
        }

        public async Task<IDataResult<AccessToken>> CreateAccessToken(User user)
        {
            IDataResult<List<Role>> roles = await _userService.GetRoles(user);
            var accessToken = await _tokenHelper.CreateToken(user, roles.Data);
            await SaveRefreshToken(user, await _tokenHelper.CreateRefreshToken());
            return new SuccessDataResult<AccessToken>(accessToken, _message.GetMessage("TokenCreat"));
        }

        public async Task<IDataResult<User>> Login(UserLogin userLogin)
        {
            var existUser = await _userService.GetUserByMail(userLogin.Email);
            if (existUser == null)
            {
                return new ErrorDataResult<User>(_message.GetMessage("ExistUser"));
            }

            if (!HashingHelper.VerifyPasswordHash(userLogin.Password, existUser.Data.PasswordHash, existUser.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(_message.GetMessage("PasswordError"));
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
            return new SuccessDataResult<User>(user, _message.GetMessage("SuccessfullyRegistered"));
        }


        public async Task<IResult> SaveRefreshToken(User user, string refreshToken)
        {
            var model = await _userService.GetUserByMail(user.Email);
            if (model.Data != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = DateTime.UtcNow.AddMonths(1);
                await _userService.UpdateUser(user);
                return new SuccessResult(_message.GetMessage("SuccessSaveRefreshToken"));
            }
            return new ErrorResult(_message.GetMessage("NotSuccessSaveRefreshToken"));
        }

        public async Task<IResult> UserExists(string mail)
        {
            if (await _userService.GetUserByMail(mail) != null)
            {
                return new ErrorResult(_message.GetMessage("UserAlreadyRegister"));
            }
            return new SuccessResult();
        }
    }
}
