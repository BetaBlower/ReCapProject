using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetAllByColorId(int id);
        IDataResult<List<Car>> GetByDailyPrice(Double min,double max);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<Car> GetById(int id);
        IResult AddCar(Car car);
        IResult DeleteCar(Car car);
        IResult UppdateCar(Car car);
    }
}
