//Projects
using MyIoT.Entities.Models;
using MyIoT.Core.DataAccess.EntityFramework;

namespace MyIoT.DataAccess.Interfaces
{
    public interface ILightDal : IEntityRepository<Light>
    {
    }
}
