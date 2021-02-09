//using Business.Concrete;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //Araba ekleme
            //carManager.AddCar(new Car {CarName = "Doblo" ,BrandId = 1, ColorId = 0, DailyPrice = 50, ModelYear = "2010", Decription = "1.Model Araba" });

            //Araba silme
            //carManager.DeleteCar(new Car { Id = 12, CarName = "Doblo", BrandId = 1, ColorId = 0, DailyPrice = 50, ModelYear = "2010", Decription = "1.Model Araba" });

            //Araba Güncelleme
            //carManager.UppdateCar(new Car{Id = 12, CarName = "Fiorino", BrandId = 1, ColorId = 0, DailyPrice = 50, ModelYear = "2010", Decription = "1.Model Araba" });
            foreach (var car in carManager.GetAll())
            {
                Console.Write("araba ID'si : {0}\n" +
                              "Araba marka Id'si : {1}\n" +
                              "araba renk Id'si : {2}\n" +
                              "araba adı : {3}\n" +
                              "arabanın günlük fiyatı : {4}\n" +
                              "arabanın model yılı : {5}\n" +
                              "arabanın açıklaması : {6}\n\n"
                              ,car.Id, car.BrandId, car.ColorId, car.CarName, car.DailyPrice, car.ModelYear, car.Decription);
            }

        }
    }
}
