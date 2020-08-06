using Core.DataAccess.EntityFramework;
using DataAccess.Interfaces;
using Entities.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Core.Utilities.Security.UserEntity;

namespace DataAccess.Data
{
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
}
