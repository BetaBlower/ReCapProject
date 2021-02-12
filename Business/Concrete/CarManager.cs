using Business.Abstract;
using Business.Constants;
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

        public IResult AddCar(Car car)
        {
            if (car.CarName.Length >= 2)
            {
                if (car.DailyPrice > 0)
                {
                    _carDal.Add(car);
                    return new SuccessResult(Messages.Success);
                }
                return new ErrorResult(Messages.PriceError);
            }
            return new ErrorResult(Messages.CharacterError);
           
        }

        public IResult DeleteCar(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Success);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id), Messages.Success);
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id),Messages.Success);
        }

        public IDataResult<List<Car>> GetByDailyPrice(double min, double max)
        {
           

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max),Messages.Success);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=> c.Id==id), Messages.Success);
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(),Messages.Success);
        }

        public IResult UppdateCar(Car car)
        {
            _carDal.Uppdate(car);
            return new SuccessResult(Messages.Success);
        }

       
    }
}
