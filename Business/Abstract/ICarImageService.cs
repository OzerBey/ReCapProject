using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImage entity);
        IResult Update(IFormFile file, CarImage entity);
        IResult Delete(CarImage entity);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> Get(int carImageId);
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
    }
}
