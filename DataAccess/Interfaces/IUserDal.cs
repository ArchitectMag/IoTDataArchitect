using Core.DataAccess.EntityFramework;
using Core.Utilities.Security.UserEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUserDal : IEntityRepository<User>
    {
        Task<List<Role>> GetRoles(User user);
    }
}
