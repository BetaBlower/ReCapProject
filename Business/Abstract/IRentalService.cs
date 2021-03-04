using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetAllByCustomerId(int id);
        IDataResult<Rental> GetById(int id);
        IResult AddRental(Rental rentals);
        IResult DeleteRental(Rental rentals);
        IResult UppdateRental(Rental rentals);
        IResult ControlReturnTime(int id);
    }
}
