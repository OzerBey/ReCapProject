using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        //CRUD operations
        void Add(Color color);
        void Update(Color color);
        void Delete(Color color);
        List<Color> GetAll();

        //filtered
        Color GetById(int id);
        // List<Car> GetCarsByColorId(int id); // for color id
    }
}
