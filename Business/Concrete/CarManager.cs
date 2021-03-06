using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValiDationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        #region Ctor
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        #endregion

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin,car.add")]
        [CacheRemoveAspect("IcarService.get")]
        public IResult AddCar(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.Success);

        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IcarService.get")]
        public IResult DeleteCar(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Success);
        }
        [CacheAspect]
        //[SecuredOperation("admin,car.list")]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Success);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        [SecuredOperation("admin,car.list")]
        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id), Messages.Success);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("admin,car.list")]
        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id),Messages.Success);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("admin,car.list")]
        public IDataResult<List<Car>> GetByDailyPrice(double min, double max)
        {
           

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max),Messages.Success);
        }
        [SecuredOperation("admin,car.list")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=> c.Id==id), Messages.Success);
        }
        [SecuredOperation("admin,car.list")]
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(),Messages.Success);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IcarService.get")]
        [SecuredOperation("admin,car.add")]
        public IResult UppdateCar(Car car)
        {
            _carDal.Uppdate(car);
            return new SuccessResult(Messages.Success);
        }

       
    }
}
