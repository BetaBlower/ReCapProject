using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, NewDataBaseContext>, IRentalDal
    {

        public List<RentalDetailDto> GetRentalDetails()
        {
            using (NewDataBaseContext context = new NewDataBaseContext())
            {
                var result = from re in context.Rentals

                             join ca in context.Cars
                             on re.CarId equals ca.Id

                             join br in context.Brands
                             on ca.BrandId equals br.BrandId

                             join cu in context.Customers
                             on re.CustomerId equals cu.Id

                             join us in context.Users
                             on cu.UserId equals us.Id

                             select new RentalDetailDto
                             {
                                 Id = re.Id,
                                 BrandName = br.BrandName,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
