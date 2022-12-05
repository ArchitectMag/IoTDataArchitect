//System
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

//Project
using MyIoT.Entities.Context;
using MyIoT.DataAccess.Interfaces;
using MyIoT.Core.DataAccess.EntityFramework;
using MyIoT.Core.Utilities.Security.UserEntity;

namespace MyIoT.DataAccess.Concrete;

public class UserDal : EntityRepositoryBase<User, AppDbContext>, IUserDal
{
    public async Task<List<Role>> GetRoles(User user)
    {
        using (var context = new AppDbContext())
        {
            var result = from role in context.Roles
                         join userRole in context.UserRoles on role.Id equals userRole.RoleId
                         where userRole.UserId == user.Id
                         select new Role { Id = role.Id, Name = role.Name };
            return await Task.Run(() => result.ToList());
        }
    }
}