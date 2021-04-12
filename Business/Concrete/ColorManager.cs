using Core.Utilities.Results;
using System.Collections.Generic;
using Business.Constants;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Core.Aspects.Autofac.Validation;
using Business.ValiDationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Business.BusinessAspect.Autofac;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        #region Ctor
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        #endregion

        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.get")]
        [SecuredOperation("admin")]
        public IResult AddColor(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.Success);
        }
        [CacheRemoveAspect("IColorService.get")]
        [SecuredOperation("admin")]
        public IResult DeleteColor(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.Success);
        }
        //[SecuredOperation("admin,color.list")]
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.Success);
        }
        [SecuredOperation("admin,color.list")]
        [PerformanceAspect(5)]
        [CacheAspect]

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c=> c.ColorId == id),Messages.Success);
        }
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.get")]
        [SecuredOperation("admin")]
        public IResult UppdateColor(Color color)
        {
            _colorDal.Uppdate(color);
            return new SuccessResult(Messages.Success);
        }
    }
}
