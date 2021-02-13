using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        //GetById,GetAll,Add,Update,Delete : Buraya nesneye(arabaya) ait özel operasyonları koyarız (for example Car details)
        // !!! interface in operasyonlari default olarak public tir ama kendisi public degildir..
        List<CarDetailDto> GetCarDetails();

    }
}
//Code refactoring : kod iyilestirilmesi