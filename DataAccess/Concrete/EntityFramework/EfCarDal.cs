using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using System.Collections;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NewDataBaseContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (NewDataBaseContext context = new NewDataBaseContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands
                             on ca.BrandId equals b.BrandId
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId


                             select new CarDetailsDto { BrandName = b.BrandName, CarId = ca.Id, CarName = ca.CarName, ColorName = co.ColorName, DailyPrice = ca.DailyPrice,Decription = ca.Decription,ModelYear = ca.ModelYear };
                return result.ToList();
                            
            }
        }
    }
}
