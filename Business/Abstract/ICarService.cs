using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetAllByBrandId(int id);
        List<Car> GetAllByColorId(int id);
        List<Car> GetByDailyPrice(Double min,double max);
        List<CarDetailsDto> GetCarDetails();
        Car GetById(int id);
        void AddCar(Car car);
        void DeleteCar(Car car);
        void UppdateCar(Car car);
    }
}
