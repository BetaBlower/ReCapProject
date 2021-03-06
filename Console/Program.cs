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

        }


        /// <summary>
        /// Rentals bilgileri girilen rentalsi günceller
        /// </summary>
        /// <param name="rentals">rentals nesnesi verilmeli</param>
        private static void UppdateRentals(Rental rentals)
        {
            RentalManager rentalsManager = new RentalManager(new EfRentalDal());
            var result = rentalsManager.UppdateRental(rentals);

        }

        #region Metotlar 


        private static void AddRentals(Rental rentals)
        {
            RentalManager rentalsManager = new RentalManager(new EfRentalDal());
            var result = rentalsManager.AddRental(rentals);
            Console.WriteLine(result.Message);
            
        }
        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            if (carManager.GetCarDetails().Success)
            {
                foreach (var CarD in carManager.GetCarDetails().Data)
                {

                    Console.WriteLine($"ürün Id={CarD.CarId} ürün adi={CarD.CarName} markası={CarD.BrandName} rengi={CarD.ColorName} günlük fiyati={CarD.DailyPrice}");
                }
            }
            else
            {
                Console.WriteLine(carManager.GetCarDetails().Message);
            }
            
        }

        private static void GetById(int id)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine(carManager.GetById(id));
            
        }

        public static void ListAllColors()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var x = colorManager.GetAll();
            if (x.Success)
            {
                foreach (var color in x.Data)
                {
                    Console.Write("{0} : id   {1} : rengi\n\n", color.ColorId, color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(x.Message);
            }
        }

        private static void AddBrand(Brand brand)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.AddBrand(brand);
        }

        private static void UppdateColor(Color color)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.UppdateColor(color);
        }

        private static void AddColor(Color color)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.AddColor(color);
        }

        private static void ListAllCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var car in result.Data)
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
            else
            {
                Console.WriteLine(result.Message);
            }
           
        }

        private static void UppdateCar(Car car)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.UppdateCar(car);
        }

        private static void DeleteCar(Car car)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.DeleteCar(car);
        }

        private static void AddCar(Car car)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.AddCar(car);
        }
        #endregion
    }
}
