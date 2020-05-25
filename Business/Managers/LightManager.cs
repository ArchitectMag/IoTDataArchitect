using Business.Interfaces;
using Core.Utilities.Result;
using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Managers
{
    public class LightManager : ILightService
    {
        private ILightDal _lightDal;

        public LightManager(ILightDal lightDal)
        {
            _lightDal = lightDal;
        }

        public async Task<IResult> AddLight(Light light)
        {
            await _lightDal.Add(light);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteLight(int id)
        {
            Light model = await _lightDal.Get(l=>l.Id == id);
            await _lightDal.Delete(model);
            return new SuccessResult();
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
            return new SuccessResult();
        }
    }
}
