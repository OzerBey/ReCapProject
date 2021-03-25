using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {

        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbycarid")]
        public IActionResult GetAllByCarId(int carId)
        {
            var result = _carImageService.GetAllByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //ÖNEMMMLİİİİİİİİİİİİİ
        //Microsoft.AspNetCore.Http ekledikten sonra postman'da int türünden parametre kabul etmiyor
        //ya int'in önüne [FromForm] koyacagız ya da nesne yollayacagız. Şunlar gibi = 
        // ([FromForm] int id) veya (CarImage carImage) eger fromform yaparsak postmanda form-data kısmından
        //deger yolamamız gerekiyor. Nesne yollayacaksak raw sekmesinden yollayabiliyoruz.
        //ÖÖÖNEMLİİİİİİİİİİİ
        [HttpGet("getbyid")]
        public IActionResult GetById(CarImage carImage)
        {
            var result = _carImageService.Get(carImage.Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(CarImage entity)
        {
            var result = _carImageService.Delete(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] CarImage entity)
        {
            var result = _carImageService.Update(file, entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
