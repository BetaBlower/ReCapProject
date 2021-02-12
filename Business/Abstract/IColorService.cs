using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<List<Color>> GetAllByColorId(int id);
        IDataResult<Color> GetById(int id);
        IResult AddColor(Color car);
        IResult DeleteColor(Color car);
        IResult UppdateColor(Color car);
    }
}
