using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void AddColor(Color color)
        {
            _colorDal.Add(color);
        }

        public void DeleteColor(Color color)
        {
            _colorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public List<Color> GetAllByColorId(int id)
        {
            return _colorDal.GetAll(p => p.ColorId == id);
        }

       
        public List<Color> GetById(int id)
        {
            return _colorDal.GetAll(p=> p.ColorId == id);
        }

        public void UppdateColor(Color color)
        {
            _colorDal.Uppdate(color);
        }
    }
}
