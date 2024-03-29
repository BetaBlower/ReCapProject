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
    public class CustomerController:ControllerBase
    {
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customers)
        {
            var result = _customerService.AddCustomer(customers);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Customer customers)
        {
            var result = _customerService.DeleteCustomer(customers);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("uppdate")]
        public IActionResult Uppdate(Customer customers)
        {
            var result = _customerService.UppdateCustomer(customers);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }



        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _customerService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getallby")]
        public IActionResult GetAllBy(Customer customers)
        {
            var result = _customerService.GetAllBy(customers);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
