using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        ////before IResult and IDataResult
        ////CRUD operations
        //void Add(Color color);
        //void Update(Color color);
        //void Delete(Color color);
        //List<Color> GetAll();

        ////filtered
        //Color GetById(int id);
        //// List<Car> GetCarsByColorId(int id); // for color id


        //after IResult and IDataResult
        //CRUD operations
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
        IDataResult<List<Color>> GetAll();

        //filtered
        IDataResult<Color> GetById(int id); 
        // List<Car> GetCarsByColorId(int id); // for color id
    }
}
