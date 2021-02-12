using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalsManager : IRentalService
    {
        #region ctor
        IRentalsDal _rentalDal;

        public RentalsManager(IRentalsDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        #endregion

        public IResult AddRental(Rentals rentals)
        {
            
            if (true)
            {
                _rentalDal.Add(rentals);
                return new SuccessResult(Messages.Success);
            }
            return new ErrorResult(Messages.TimeError);
           
        }

        public IResult DeleteRental(Rentals rentals)
        {
            _rentalDal.Delete(rentals);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(_rentalDal.GetAll(),Messages.Success);
        }

        public IDataResult<List<Rentals>> GetAllByCustomerId(int id)
        {
            return new SuccessDataResult<List<Rentals>>(_rentalDal.GetAll(p=> p.Id==id),Messages.Success);
        }

        public IDataResult<Rentals> GetById(int id)
        {
            return new SuccessDataResult<Rentals>(_rentalDal.Get(p=> p.Id == id),Messages.Success);
        }

        public IResult UppdateRental(Rentals rentals)
        {
            _rentalDal.Uppdate(rentals);
            return new SuccessResult(Messages.Success);
        }
    }
}
