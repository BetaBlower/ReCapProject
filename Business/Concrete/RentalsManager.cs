using Business.Abstract;
using Business.Constants;
using Business.ValiDationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(RentalsValidator))]
        public IResult AddRental(Rentals rentals)
        {
            if (ControlReturnTime(rentals.CarId).Success) 
            {
                _rentalDal.Add(rentals);
                return new SuccessResult(Messages.Success);
            }
            return new ErrorResult(Messages.TimeError);
           
        }

        public IResult ControlReturnTime(int id)
        {
          
            if (_rentalDal.GetAll(r=> r.CarId== id && r.RentDate > r.ReturnDate ).Count == 0)
            {
                return new SuccessResult();

            }
            return new ErrorResult();
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
            return new SuccessDataResult<List<Rentals>>(_rentalDal.GetAll(r=> r.Id==id),Messages.Success);
        }

        public IDataResult<Rentals> GetById(int id)
        {
            return new SuccessDataResult<Rentals>(_rentalDal.Get(r=> r.Id == id),Messages.Success);
        }


        public IResult UppdateRental(Rentals rentals)
        {
            _rentalDal.Uppdate(rentals);
            return new SuccessResult(Messages.Success);
        }
    }
}
