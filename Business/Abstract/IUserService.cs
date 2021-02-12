using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<Users>> GetAll();
        IDataResult<Users> GetById(int id);
        IResult AddUser(Users users);
        IResult DeleteUser(Users users);
        IResult UppdateUser(Users users);
    }
}
