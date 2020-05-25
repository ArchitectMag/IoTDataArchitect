using Core.DataAccess.EntityFramework;
using Entities.Models;

namespace DataAccess.Interfaces
{
    public interface ILightDal : IEntityRepository<Light>
    {
    }
}
