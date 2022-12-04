//System
using System.Threading.Tasks;
using System.Collections.Generic;

//Projects
using MyIoT.Core.DataAccess.EntityFramework;
using MyIoT.Core.Utilities.Security.UserEntity;


namespace MyIoT.DataAccess.Interfaces;

public interface IUserDal : IEntityRepository<User>
{
    Task<List<Role>> GetRoles(User user);
}
