using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetAllByCarId(int id);
        IDataResult<List<CarImage>> GetAllByDateTime(DateTime Min,DateTime Max);
        IDataResult<CarImage> GetById(int id);
        IResult AddCarImage(CarImage carImage,IFormFile file);
        IResult DeleteCarImage(CarImage carImage);
        IResult UppdateCarImage(CarImage carImage, IFormFile file);
    }
}
