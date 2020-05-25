using Core.Utilities.Result;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILightService
    {
        Task<IDataResult<Light>> GetLight(int id);
        Task<IDataResult<List<Light>>> GetLightList();
        Task<IDataResult<List<Light>>> GetLightListByTime(DateTime date);
        Task<IResult> AddLight(Light light);
        Task<IResult> UpdateLight(Light light);
        Task<IResult> DeleteLight(int id);
    }
}
