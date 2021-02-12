using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customers>> GetAll();
        IDataResult<List<Customers>> GetAllBy(Customers customers);
        IDataResult<Customers> GetById(int id);
        IResult AddCustomer(Customers customers);
        IResult DeleteCustomer(Customers customers);
        IResult UppdateCustomer(Customers customers);
    }
}
