using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<List<Brand>> GetAllByBrandId(int id);
        IDataResult<List<Brand>> GetById(int id);
        IResult AddBrand(Brand car);
        IResult DeleteBrand(Brand car);
        IResult UppdateBrand(Brand car);
    }
}
