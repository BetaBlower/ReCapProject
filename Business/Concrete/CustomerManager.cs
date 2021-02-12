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
    public class CustomerManager : ICustomerService
    {
        #region ctor
        ICustomersDal _customersDal;

        public CustomerManager(ICustomersDal customersDal)
        {
            _customersDal = customersDal;
        }
        #endregion


        public IResult AddCustomer(Customers customers)
        {
            _customersDal.Add(customers);
            return new SuccessResult(Messages.Success);
        }

        public IResult DeleteCustomer(Customers customers)
        {
            _customersDal.Delete(customers);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Customers>> GetAll()
        {
            return new SuccessDataResult<List<Customers>>(_customersDal.GetAll(),Messages.Success);
        }

        public IDataResult<List<Customers>> GetAllBy(Customers customers)
        {
            return new SuccessDataResult<List<Customers>>(_customersDal.GetAll(p=> p == customers),Messages.Success);
        }

        public IDataResult<Customers> GetById(int id)
        {
            return new SuccessDataResult<Customers>(_customersDal.Get(p=> p.UserId == id),Messages.Success);
        }

        public IResult UppdateCustomer(Customers customers)
        {
            _customersDal.Uppdate(customers);
            return new SuccessResult(Messages.Success);
        }
    }
}
