﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController:ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.AddCar(car);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.DeleteCar(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("uppdate")]
        public IActionResult Uppdate(Car car)
        {
            var result = _carService.UppdateCar(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }



        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getallbycolorid")]
        public IActionResult GetAllByColorId(int id)
        {
            var result = _carService.GetAllByColorId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getallbybrandid")]
        public IActionResult GetAllByBrandId(int id)
        {
            var result = _carService.GetAllByBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getdailyprice")]
        public IActionResult GetByDailyPrice(decimal min,decimal max)
        {
            var result = _carService.GetByDailyPrice(min,max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("cardetails")]
        public IActionResult CarDetailsDto()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
