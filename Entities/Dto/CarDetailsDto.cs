using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class CarDetailsDto:IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public String ColorName { get; set; }
        public double DailyPrice { get; set; }


    }
}
