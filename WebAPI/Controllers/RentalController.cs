using Business.Abstract;
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
    public class RentalController:ControllerBase
    {
        IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("add")]
        public IActionResult AddRental(Rental rentals)
        {
            var result = _rentalService.AddRental(rentals);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult DeleteRental(Rental rentals)
        {
            var result = _rentalService.DeleteRental(rentals);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("uppdate")]
        public IActionResult UppdateRental(Rental rentals)
        {
            var result = _rentalService.UppdateRental(rentals);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }



        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }
        [HttpGet("getallbycustomerid")]
        public IActionResult GetAllByCustomerId(int id)
        {
            var result = _rentalService.GetAllByCustomerId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }
        [HttpGet("getbyid")]
        public IActionResult GetAllById(int id)
        {
            var result = _rentalService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }
    }
}
