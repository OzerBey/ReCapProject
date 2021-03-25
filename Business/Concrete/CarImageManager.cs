using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        public IResult Add(IFormFile file, CarImage entity)
        {
            throw new NotImplementedException();
        }

        public IResult Update(IFormFile file, CarImage entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CarImage entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImage> Get(int carImageId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
