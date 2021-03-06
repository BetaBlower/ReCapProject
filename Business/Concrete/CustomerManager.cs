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
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        #region ctor
        ICustomersDal _customersDal;

        public CustomerManager(ICustomersDal customersDal)
        {
            _customersDal = customersDal;
        }
        #endregion

        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.get")]
        [SecuredOperation("admin")]
        public IResult AddCustomer(Customer customers)
        {
            _customersDal.Add(customers);
            return new SuccessResult(Messages.Success);
        }
        [CacheRemoveAspect("ICustomerService.get")]
        [SecuredOperation("admin")]
        public IResult DeleteCustomer(Customer customers)
        {
            _customersDal.Delete(customers);
            return new SuccessResult(Messages.Success);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customersDal.GetAll(),Messages.Success);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Customer>> GetAllBy(Customer customers)
        {
            return new SuccessDataResult<List<Customer>>(_customersDal.GetAll(c=> c == customers),Messages.Success);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customersDal.Get(c=> c.UserId == id),Messages.Success);
        }
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.get")]
        [SecuredOperation("admin")]
        public IResult UppdateCustomer(Customer customers)
        {
            _customersDal.Uppdate(customers);
            return new SuccessResult(Messages.Success);
        }
    }
}
