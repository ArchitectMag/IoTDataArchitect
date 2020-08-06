using System;
using Entities.Models;
using Business.Interfaces;
using Core.Utilities.Result;
using DataAccess.Interfaces;
using System.Threading.Tasks;
using Core.Utilities.Messages;
using System.Collections.Generic;
using Business.VaidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;

namespace Business.Managers
{
    public class LightManager : ILightService
    {
        private ILightDal _lightDal;
        private IMessage _message;

        public LightManager(ILightDal lightDal, IMessage message)
        {
            _lightDal = lightDal;
            _message = message;
        }

        [ValidationAspect(typeof(LightValidation),Priority = 1)]
        public async Task<IResult> AddLight(Light light)
        {
            await _lightDal.Add(light);
            return new SuccessResult(_message.GetMessage("AddedSucced"));
        }

        public async Task<IResult> DeleteLight(int id)
        {
            Light model = await _lightDal.Get(l=>l.Id == id);
            await _lightDal.Delete(model);
            return new SuccessResult(_message.GetMessage("DeletedSucced"));
        }

        public async Task<IDataResult<Light>> GetLight(int id)
        {
            return new SuccessDataResult<Light>(await _lightDal.Get(l=>l.Id == id));
        }

        public async Task<IDataResult<List<Light>>> GetLightList()
        {
            return new SuccessDataResult<List<Light>>(await _lightDal.GetList());
        }

        public async Task<IDataResult<List<Light>>> GetLightListByTime(DateTime date)
        {
            return new SuccessDataResult<List<Light>>(await _lightDal.GetList(l => l.Date == date));
        }

        public async Task<IResult> UpdateLight(Light light)
        {
            await _lightDal.Update(light);
            return new SuccessResult(_message.GetMessage("UpdatedSucced"));
        }
    }
}
