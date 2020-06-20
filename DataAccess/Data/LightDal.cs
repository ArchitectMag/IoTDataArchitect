using Core.DataAccess.EntityFramework;
using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;

namespace DataAccess.Data
{
    public class LightDal : EntityRepositoryBase<Light, AppDbContext>, ILightDal
    {
       
    }
}
