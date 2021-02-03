using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            InMemoryCarDal carDal = new InMemoryCarDal();
            

            foreach (var car in carDal.GetAll())
            {
                Console.Write(" markası = " + car.BrandId);
                Console.Write(" rengi =" + car.ColorId);
                Console.Write(" Model Yılı =" + car.ModelYear + " ");
                Console.Write(" Günlük Ücreti = " + car.DailyPrice + " ");
                Console.WriteLine(" AÇıklama = " + car.Decription);
                
                
            }
            Console.WriteLine("");
            foreach (var car in carDal.GetById(6))
            {
                Console.Write(" markası = " + car.BrandId);
                Console.Write(" rengi =" + car.ColorId);
                Console.Write(" Model Yılı =" + car.ModelYear + " ");
                Console.Write(" Günlük Ücreti = " + car.DailyPrice + " ");
                Console.WriteLine(" AÇıklama = " + car.Decription);


            }
        }
    }
}
