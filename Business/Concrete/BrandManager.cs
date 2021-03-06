using Core.Utilities.Results;
using System.Collections.Generic;
using Business.Constants;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Core.Aspects.Autofac.Validation;
using Business.ValiDationRules.FluentValidation;
using Business.BusinessAspect.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        #region Ctor
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        #endregion
        [CacheAspect]
        [SecuredOperation("admin,brand.list")]
        [PerformanceAspect(5)]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.Success);
        }
        [CacheAspect]
        [SecuredOperation("admin,brand.list")]
        [PerformanceAspect(5)]
        public IDataResult<List<Brand>> GetById(int id)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandId == id), Messages.Success);
        }
        [SecuredOperation("admin,brand.add")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.get")]
        public IResult AddBrand(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.Success);
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IBrandService.get")]
        public IResult DeleteBrand(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Success);
        }
        [SecuredOperation("admin,brand.add")]
        [CacheRemoveAspect("IBrandService.get")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult UppdateBrand(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Success);
        }
    }
}
