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
    public class UsersManager : IUserService
    {
        #region Ctor
        IUsersDal _UsersDal;

        public UsersManager(IUsersDal usersDal)
        {
            _UsersDal = usersDal;
        }
        #endregion

        [ValidationAspect(typeof(UserValidator))]
        public IResult AddUser(User users)
        {
            _UsersDal.Add(users);
            return new SuccessResult(Messages.Success);
        }

        public IResult DeleteUser(User users)
        {
            _UsersDal.Delete(users);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_UsersDal.GetAll(),Messages.Success);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_UsersDal.Get(u=> u.Id== id), Messages.Success);
        }

        public IResult UppdateUser(User users)
        {
            _UsersDal.Uppdate(users);
            return new SuccessResult(Messages.Success);
        }
    }
}
