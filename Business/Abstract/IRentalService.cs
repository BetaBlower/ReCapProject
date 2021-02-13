using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rentals>> GetAll();
        IDataResult<List<Rentals>> GetAllByCustomerId(int id);
        IDataResult<Rentals> GetById(int id);
        IResult AddRental(Rentals rentals);
        IResult DeleteRental(Rentals rentals);
        IResult UppdateRental(Rentals rentals);
        IResult ControlReturnTime(int id);
    }
}
