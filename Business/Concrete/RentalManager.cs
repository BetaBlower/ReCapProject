using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValiDationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        #region ctor
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        #endregion

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.get")]
        [SecuredOperation("admin")]
        public IResult AddRental(Rental rentals)
        {
            if (ControlReturnTime(rentals.CarId).Success) 
            {
                _rentalDal.Add(rentals);
                return new SuccessResult(Messages.Success);
            }
            return new ErrorResult(Messages.TimeError);
           
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IResult ControlReturnTime(int id)
        {
          
            if (_rentalDal.GetAll(r=> r.CarId== id && r.RentDate > r.ReturnDate ).Count == 0)
            {
                return new SuccessResult();

            }
            return new ErrorResult();
        }
        [CacheRemoveAspect("IRentalService.get")]
        [SecuredOperation("admin")]
        public IResult DeleteRental(Rental rentals)
        {
            _rentalDal.Delete(rentals);
            return new SuccessResult(Messages.Success);
        }
        //[PerformanceAspect(5)]
        //[CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.Success);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Rental>> GetAllByCustomerId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r=> r.Id==id),Messages.Success);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=> r.Id == id),Messages.Success);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.Success);
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.get")]
        [SecuredOperation("admin,rentals.uppdate")]
        public IResult UppdateRental(Rental rentals)
        {
            _rentalDal.Uppdate(rentals);
            return new SuccessResult(Messages.Success);
        }
    }
}
