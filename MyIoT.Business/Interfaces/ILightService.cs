﻿//Projects
using MyIoT.Entities.Models;
using MyIoT.Core.Utilities.Result;

namespace MyIoT.Business.Interfaces;

public interface ILightService
{
    Task<IDataResult<Light>> GetLight(int id);
    Task<IDataResult<List<Light>>> GetLightList();
    Task<IDataResult<List<Light>>> GetLightListByTime(DateTime date);
    Task<IResult> AddLight(int lightSensorValue);
    Task<IResult> UpdateLight(Light light);
    Task<IResult> DeleteLight(int id);
}
