using ORM_Examples.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_Examples.Interfaces
{
    public interface IDataAccessService
    {
        public Car GetSimple(int id);
        public IEnumerable<Car> GetList();
        public string Create(Car car);
        public string Edit(Car car);
        public string Delete(int id);
    }
}
