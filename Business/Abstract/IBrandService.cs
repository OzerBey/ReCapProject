using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        //before IResult and IDataResult
        //CRUD operations
        //void Add(Brand brand);
        //void Update(Brand brand);
        //void Delete(Brand brand);
        //List<Brand> GetAll();

        ////filtered
        //Brand GetById(int id);

        //------------------------------------------------------------------

        //after IResult and IDataResult
        //CRUD operations
        IResult Add(Brand brand);
        IResult Update(Brand brand); 
        IResult Delete(Brand brand);
        IDataResult<List<Brand>> GetAll();


        //filtered
        IDataResult<Brand> GetById(int id);
    }
}
