using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public void AddCar(Car car)
        {
            if (car.CarName.Length >= 2)
            {
                if (car.DailyPrice > 0)
                {
                    _carDal.Add(car);

                    
                }
                
            }
           
        }

        public void DeleteCar(Car car)
        {
           _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetAll(p=> p.BrandId == id);
        }

        public List<Car> GetAllByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public List<Car> GetByDailyPrice(double min, double max)
        {
            return _carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max);
        }

        public List<Car> GetById(int id)
        {
            return _carDal.GetAll(p => p.Id == id);
        }

        public void UppdateCar(Car car)
        {
            _carDal.Uppdate(car);
        }
    }
}
