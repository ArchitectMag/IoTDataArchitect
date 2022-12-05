//System
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Authorization;

//Projects
using MyIoT.Entities.Models;
using MyIoT.Business.Interfaces;
using MyIoT.Core.Utilities.Result;
using MyIoT.DataAccess.Interfaces;
using MyIoT.Core.Utilities.Localization;
using MyIoT.Core.Aspects.Autofac.Validation;
using MyIoT.Business.VaidationRules.FluentValidation;
using MyIoT.Core.Aspects.Autofac.Transaction;
using MyIoT.Core.Aspects.Autofac.Caching;

namespace MyIoT.Business.Managers;

public class LightManager : ILightService
{
    private ILightDal _lightDal;
    private ILocalizationHelper _sharedLocalizer;

    public LightManager(ILightDal lightDal, ILocalizationHelper sharedLocalizer)
    {
        _lightDal = lightDal;
        _sharedLocalizer = sharedLocalizer;
    }

    [Authorize]
    [TransactionAspect(Priority = 1)]
    [CacheClearAspect("ILightService.Get*",Priority = 2)]
    public async Task<IResult> AddLight(int lightSensorValue)
    {
        Light light = new Light
        {
            Date = DateTime.Now,
            LightSensorValue = lightSensorValue
        };
        await _lightDal.AddAsync(light);
        return new SuccessResult(_sharedLocalizer.GetString("AddedSucced"));
    }

    [Authorize]
    [ValidationAspect(typeof(LightValidation), Priority = 1)]
    [TransactionAspect(Priority = 2)]
    [CacheClearAspect("ILightService.Get*", Priority = 3)]
    public async Task<IResult> UpdateLight(Light light)
    {
        await _lightDal.UpdateAsync(light);
        return new SuccessResult(_sharedLocalizer.GetString("UpdatedSucced"));
    }

    [Authorize]
    [TransactionAspect(Priority = 1)]
    [CacheClearAspect("ILightService.Get*", Priority = 2)]
    public async Task<IResult> DeleteLight(int id)
    {
        Light model = await _lightDal.GetAsync(l=>l.Id == id);
        await _lightDal.DeleteAsync(model);
        return new SuccessResult(_sharedLocalizer.GetString("DeletedSucced"));
    }

    [Authorize]
    [CacheAspect]
    public async Task<IDataResult<Light>> GetLight(int id)
    {
        return new SuccessDataResult<Light>(await _lightDal.GetAsync(l=>l.Id == id));
    }

    [Authorize]
    [CacheAspect]
    public async Task<IDataResult<List<Light>>> GetLightList()
    {
        return new SuccessDataResult<List<Light>>(await _lightDal.GetListAsync(),_sharedLocalizer.GetString("Success"));
    }

    [Authorize]
    [CacheAspect]
    public async Task<IDataResult<List<Light>>> GetLightListByTime(DateTime date)
    {
        return new SuccessDataResult<List<Light>>(await _lightDal.GetListAsync(l => l.Date == date));
    }
}
