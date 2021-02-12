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
    public class UsersManager : IUserService
    {
        #region Ctor
        IUsersDal _UsersDal;

        public UsersManager(IUsersDal usersDal)
        {
            _UsersDal = usersDal;
        }
        #endregion

        public IResult AddUser(Users users)
        {
            _UsersDal.Add(users);
            return new SuccessResult(Messages.Success);
        }

        public IResult DeleteUser(Users users)
        {
            _UsersDal.Delete(users);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Users>> GetAll()
        {
            return new SuccessDataResult<List<Users>>(_UsersDal.GetAll(),Messages.Success);
        }

        public IDataResult<Users> GetById(int id)
        {
            return new SuccessDataResult<Users>(_UsersDal.Get(p=> p.Id== id), Messages.Success);
        }

        public IResult UppdateUser(Users users)
        {
            _UsersDal.Uppdate(users);
            return new SuccessResult(Messages.Success);
        }
    }
}
