using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetAllBy(Customer customers);
        IDataResult<Customer> GetById(int id);
        IResult AddCustomer(Customer customers);
        IResult DeleteCustomer(Customer customers);
        IResult UppdateCustomer(Customer customers);
    }
}
