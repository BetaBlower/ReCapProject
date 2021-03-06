using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        #region Constucter

        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        #endregion

        #region Business Methods

        [ValidationAspect(typeof(CarImage))]
        [CacheRemoveAspect("ICarImageService.get")]
        [SecuredOperation("admin")]
        public IResult AddCarImage(CarImage carImage,IFormFile file)
        {
            try
            {
                IResult result = BusinessRules.Run(CheckIfImageLimit(carImage.CarId));

                if (result == null)
                    return result;
                

                carImage.ImagePath = FileHelper.Add(file);
                carImage.Date = DateTime.Now;

                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.CarImageAdded);

            }
            catch (Exception)
            {

                return new ErrorResult(Messages.CarImageCouldNotBeAdded);
            }
        }
        [CacheRemoveAspect("ICarImageService.get")]
        public IResult DeleteCarImage(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Success);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<CarImage>> GetAllByCarId(int id)
        {
            var result = _carImageDal.GetAll(i => i.CarId == id);
            return new SuccessDataResult<List<CarImage>>(result);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<CarImage>> GetAllByDateTime(DateTime Min,DateTime Max)
        {
            var result = _carImageDal.GetAll(i=> i.Date >= Min || i.Date <= Max);
            
            return new SuccessDataResult<List<CarImage>>(result);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<CarImage> GetById(int id)
        {
           
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == id));
        }
        [CacheRemoveAspect("ICarImageService.get")]
        [ValidationAspect(typeof(CarImage))]
        public IResult UppdateCarImage(CarImage carImage, IFormFile file)
        {
            var oldpath = _carImageDal.Get(i => i.Id == carImage.Id).ImagePath;

            carImage.ImagePath = FileHelper.Update(oldpath, file);
            carImage.Date = DateTime.Now;

            _carImageDal.Uppdate(carImage);
            return new SuccessResult(Messages.Success);

        }
        #endregion

        #region Business Rules

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int carId)
        {
            try
            {
                string path = @"\Images\CarRentalLogo.jpg";
                var result = _carImageDal.GetAll(p => p.CarId == carId).Any();

                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }

            catch (Exception exception)
            {
                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId).ToList());
        }
        private IResult CheckIfImageLimit(int carId)
        {
            var imgCounter = _carImageDal.GetAll(p => p.CarId == carId).Count;

            if (imgCounter > 5)
            {
                return new ErrorResult(Messages.LimitCarImageError);
            }

            return new SuccessResult();
        }

        #endregion
    }
}
