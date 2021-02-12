using Core.Utilities.Results;
using System.Collections.Generic;
using Business.Constants;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

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


        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.Success);
        }

        public IDataResult<List<Brand>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandId == id),Messages.Success);
        }

        public IDataResult<List<Brand>> GetById(int id)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandId == id), Messages.Success);
        }

        public IResult AddBrand(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.Success);
        }

        public IResult DeleteBrand(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Success);
        }

        public IResult UppdateBrand(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Success);
        }
    }
}
