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
    public class ColorsController:ControllerBase
    {
        IColorService _colorService;
        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }


        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var result = _colorService.AddColor(color);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Color color)
        {
            var result = _colorService.DeleteColor(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("uppdate")]
        public IActionResult Uppdate(Color color)
        {
            var result = _colorService.UppdateColor(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }



        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _colorService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }
    }
}
