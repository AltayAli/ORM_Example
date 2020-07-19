using Microsoft.Extensions.Configuration;
using ORM_Examples.Datas;
using ORM_Examples.Interfaces;
using ORM_Examples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM_Examples.Services
{
    public class DataAccessServiceEntityFramework : IDataAccessService
    {
        private readonly DataContextEntityFramework _context;
        public DataAccessServiceEntityFramework(IConfiguration config)
        {
            _context = new DataContextEntityFramework(config);
        }
        public string Create(Car car)
        {
            try
            {
                _context.Cars.Add(car);
                _context.SaveChanges();
                return "Created";
            }
            catch (Exception ex )
            {
                return $"Error : {ex.Message}";
            }
        }

        public string Delete(int id)
        {
            try
            {
                var car = GetSimple(id);
                if (car == null)
                    throw new Exception("Model tapılmadı!!!");

                _context.Cars.Remove(car);
                _context.SaveChanges();
                return "Deleted";
            }
            catch (Exception ex)
            {
                return $"Error : {ex.Message}";
            }

        }

        public string Edit(Car car)
        {
            try
            {
                var findedCar = GetSimple(car.Id);
                if (findedCar == null)
                    throw new Exception("Model tapılmadı!!!");

                _context.Cars.Update(car);
                _context.SaveChanges();
                return "Edited";
            }
            catch (Exception ex)
            {
                return $"Error : {ex.Message}";
            }
        }

        public IEnumerable<Car> GetList()
             => _context.Cars;

        public Car GetSimple(int id)
            => _context.Cars.SingleOrDefault(x => x.Id == id);
    }
}
