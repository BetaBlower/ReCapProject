using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public List<Brand> GetAllByBrandId(int id)
        {
            return _brandDal.GetAll(p => p.BrandId == id);
        }

        public List<Brand> GetById(int id)
        {
            return _brandDal.GetAll(p => p.BrandId == id);
        }

        public void AddBrand(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public void DeleteBrand(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public void UppdateBrand(Brand brand)
        {
            _brandDal.Delete(brand);
        }
    }
}
