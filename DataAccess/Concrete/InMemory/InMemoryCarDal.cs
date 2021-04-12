using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.Dto;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars; //_cars türünde liste tanımla

        public InMemoryCarDal() // listeye alanlar ata
        {
            _cars = new List<Car>
            {
                new Car{Id = 1,BrandId = 1,ColorId = 0,DailyPrice = 50, ModelYear = "2010", Decription = "1.Model Araba"},
                new Car{Id = 2,BrandId = 1,ColorId = 12,DailyPrice = 14549, ModelYear = "2020", Decription ="2.Model Araba" },
                new Car{Id = 3,BrandId = 2,ColorId = 0,DailyPrice = 20, ModelYear = "2005", Decription = "3.model araba"},
                new Car{Id = 4,BrandId = 2,ColorId = 3,DailyPrice = 40,ModelYear = "2021" , Decription ="4.model araba"},
                new Car{Id = 5,BrandId = 2,ColorId = 4,DailyPrice = 60, ModelYear = "2011" , Decription = "5.model araba"},
                new Car{Id = 6,BrandId = 3,ColorId = 1,DailyPrice = 100, ModelYear = "2019", Decription = "6.model araba"},
                new Car{Id = 7,BrandId = 3,ColorId = 9,DailyPrice = 70, ModelYear = "2015", Decription = "7.model araba"},
                new Car{Id = 8,BrandId = 4,ColorId = 10,DailyPrice = 200, ModelYear = "2010" , Decription = "8.model araba"}
            };
        }
        public void Add(Car car) //yeni araba ekle
        {
            _cars.Add(car);
        }

        public void Delete(Car car) //araba sil
        {
            Car carDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()//bütün arabaları seç
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();

        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Uppdate(Car car)
        {
            Car carUppdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            car.BrandId = car.BrandId;
            car.ColorId = car.ColorId;
            car.DailyPrice = car.DailyPrice;
            car.ModelYear = car.ModelYear;
            car.Decription = car.Decription;
        }
    }
}
