//Project
using MyIoT.Entities.Models;
using MyIoT.Entities.Context;
using MyIoT.DataAccess.Interfaces;
using MyIoT.Core.DataAccess.EntityFramework;

namespace MyIoT.DataAccess.Data;

public class LightDal : EntityRepositoryBase<Light, AppDbContext>, ILightDal
{
   
}
