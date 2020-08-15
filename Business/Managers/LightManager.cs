using System;
using Entities.Models;
using Business.Interfaces;
using Core.Utilities.Result;
using DataAccess.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Core.Aspects.Autofac.Validation;
using Business.VaidationRules.FluentValidation;
using Core.Utilities.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;

namespace Business.Managers
{
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
            await _lightDal.Add(light);
            return new SuccessResult(_sharedLocalizer.GetString("AddedSucced"));
        }

        public async Task<IResult> DeleteLight(int id)
        {
            Light model = await _lightDal.Get(l=>l.Id == id);
            await _lightDal.Delete(model);
            return new SuccessResult(_sharedLocalizer.GetString("DeletedSucced"));
        }

        public async Task<IDataResult<Light>> GetLight(int id)
        {
            return new SuccessDataResult<Light>(await _lightDal.Get(l=>l.Id == id));
        }

        [Authorize]
        public async Task<IDataResult<List<Light>>> GetLightList()
        {
            return new SuccessDataResult<List<Light>>(await _lightDal.GetList(),_sharedLocalizer.GetString("Fuck"));
        }

        public async Task<IDataResult<List<Light>>> GetLightListByTime(DateTime date)
        {
            return new SuccessDataResult<List<Light>>(await _lightDal.GetList(l => l.Date == date));
        }

        public async Task<IResult> UpdateLight(Light light)
        {
            await _lightDal.Update(light);
            return new SuccessResult(_sharedLocalizer.GetString("UpdatedSucced"));
        }
    }
}
