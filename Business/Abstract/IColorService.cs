using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll();
        List<Color> GetAllByColorId(int id);
        List<Color> GetById(int id);
        void AddColor(Color car);
        void DeleteColor(Color car);
        void UppdateColor(Color car);
    }
}
