using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        List<Brand> GetAllByBrandId(int id);
        List<Brand> GetById(int id);
        void AddBrand(Brand car);
        void DeleteBrand(Brand car);
        void UppdateBrand(Brand car);
    }
}
