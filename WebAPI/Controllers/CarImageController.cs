using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController:ControllerBase
    {
        #region Constucters
        ICarImageService _carImageService;

        public CarImageController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }
        #endregion

        #region HttpPost
        [HttpPost("add")]
        public IActionResult Add([FromForm]CarImage carImage,[FromForm(Name = "Image")] IFormFile file)
        {
            var result = _carImageService.AddCarImage(carImage,file);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

           
        }
        [HttpPost("Delete")]
        public IActionResult delete([FromForm]int id)
        {
            var carImage = _carImageService.GetById(id).Data;
            var deleteCarImage = _carImageService.DeleteCarImage(carImage);

            if (deleteCarImage.Success)
            {
                return Ok(deleteCarImage);
            }
            return BadRequest(deleteCarImage);
        }
        [HttpPost("uppdate")]
        public IActionResult uppdate([FromForm]int id,[FromForm(Name = "carImage")]IFormFile file)
        {
            var carImage = _carImageService.GetById(id).Data;
            var result = _carImageService.UppdateCarImage(carImage, file);

            if (result.Success)
            {
                return Ok(result);
            }


            return BadRequest(result);
        }
        #endregion

        #region HttpGet

        [HttpGet("getall")]
        public IActionResult Getall()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getbycarid")]
        public IActionResult GetByCarId([FromForm]int carId)
        {
            var result = _carImageService.GetAllByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getbyid")]
        public IActionResult GetByCarImageId([FromForm]int carImageId)
        {
            var result = _carImageService.GetById(carImageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        #endregion
    }
}
