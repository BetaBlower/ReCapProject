using Core.Utilities.Results;
using System.Collections.Generic;
using Business.Constants;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

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

        public IResult AddColor(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.başarılı);
        }

        public IResult DeleteColor(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.başarılı);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.başarılı);
        }

        public IDataResult<List<Color>>  GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c=> c.ColorId == id),Messages.başarılı);
        }

       
        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c=> c.ColorId == id),Messages.başarılı);
        }

        public IResult UppdateColor(Color color)
        {
            _colorDal.Uppdate(color);
            return new SuccessResult(Messages.başarılı);
        }
    }
}
