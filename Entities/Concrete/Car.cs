﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int Id { get; set; }//aracın ID si
        public int BrandId { get; set; }//aracın markasının ID si
        public int ColorId { get; set; }//aracın renginin ID si
        public string CarName { get; set; }
        public string ModelYear { get; set; }//aracın modeli
        public decimal DailyPrice { get; set; }//günlük kiralama bedeli
        public string Decription { get; set; }//araba açıklaması
    }
}
