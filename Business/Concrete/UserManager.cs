using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValiDationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        #region Ctor
        IUserDal _UsersDal;

        public UserManager(IUserDal usersDal)
        {
            _UsersDal = usersDal;
        }
        #endregion

        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.get")]
        public IResult AddUser(User user)
        {
            _UsersDal.Add(user);
            return new SuccessResult(Messages.Success);
        }
        [CacheRemoveAspect("IUserService.get")]
        public IResult DeleteUser(User users)
        {
            _UsersDal.Delete(users);
            return new SuccessResult(Messages.Success);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_UsersDal.GetAll(),Messages.Success);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_UsersDal.Get(u=> u.Id== id), Messages.Success);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_UsersDal.Get(u => u.Email == email),Messages.Success);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_UsersDal.GetClaims(user));
        }

        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.get")]
        public IResult UppdateUser(User users)
        {
            _UsersDal.Uppdate(users);
            return new SuccessResult(Messages.Success);
        }
    }
}
