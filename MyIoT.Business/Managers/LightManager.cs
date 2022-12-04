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

    [ValidationAspect(typeof(LightValidation),Priority = 1)]
    public async Task<IResult> AddLight(Light light)
    {
        await _lightDal.AddAsync(light);
        return new SuccessResult(_sharedLocalizer.GetString("AddedSucced"));
    }

    public async Task<IResult> DeleteLight(int id)
    {
        Light model = await _lightDal.GetAsync(l=>l.Id == id);
        await _lightDal.DeleteAsync(model);
        return new SuccessResult(_sharedLocalizer.GetString("DeletedSucced"));
    }

    public async Task<IDataResult<Light>> GetLight(int id)
    {
        return new SuccessDataResult<Light>(await _lightDal.GetAsync(l=>l.Id == id));
    }

    [Authorize]
    public async Task<IDataResult<List<Light>>> GetLightList()
    {
        return new SuccessDataResult<List<Light>>(await _lightDal.GetListAsync(),_sharedLocalizer.GetString("Success"));
    }

    public async Task<IDataResult<List<Light>>> GetLightListByTime(DateTime date)
    {
        return new SuccessDataResult<List<Light>>(await _lightDal.GetListAsync(l => l.Date == date));
    }

    public async Task<IResult> UpdateLight(Light light)
    {
        await _lightDal.UpdateAsync(light);
        return new SuccessResult(_sharedLocalizer.GetString("UpdatedSucced"));
    }
}
