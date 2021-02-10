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
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            

        }

        private static void GetByCar(CarManager carManager)
        {
            foreach (var car in carManager.GetById(10))
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void ListtoAllColors(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll())
            {
                Console.Write("{0} : id   {1} : rengi\n\n", color.ColorId, color.ColorName);
            }
        }

        private static void AddBrand(BrandManager brandManager)
        {
            brandManager.AddBrand(new Brand { BrandName = "renault" });
        }

        private static void UppdateColor(ColorManager colorManager)
        {
            colorManager.UppdateColor(new Color { ColorId = 1, ColorName = "Kırmızı" });
        }

        private static void AddColor(ColorManager colorManager)
        {
            colorManager.AddColor(new Color { ColorName = "Mavi" });
        }

        private static void ListToCar(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.Write("araba ID'si : {0}\n" +
                              "Araba marka Id'si : {1}\n" +
                              "araba renk Id'si : {2}\n" +
                              "araba adı : {3}\n" +
                              "arabanın günlük fiyatı : {4}\n" +
                              "arabanın model yılı : {5}\n" +
                              "arabanın açıklaması : {6}\n\n"
                    , car.Id, car.BrandId, car.ColorId, car.CarName, car.DailyPrice, car.ModelYear, car.Decription);
            }
        }

        private static void UppdateCar(CarManager carManager)
        {
            carManager.UppdateCar(new Car { Id = 12, CarName = "Fiorino", BrandId = 1, ColorId = 0, DailyPrice = 50, ModelYear = "2010", Decription = "1.Model Araba" });
        }

        private static void DeleteCar(CarManager carManager)
        {
            carManager.DeleteCar(new Car { Id = 12, CarName = "Doblo", BrandId = 1, ColorId = 0, DailyPrice = 50, ModelYear = "2010", Decription = "1.Model Araba" });
        }

        private static void AddCar(CarManager carManager)
        {
            carManager.AddCar(new Car { CarName = "araba200", BrandId = 10, ColorId = 4, DailyPrice = 400, ModelYear = "2020", Decription = "2.Model Araba" });
        }
    }
}
