using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
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
    public class DataAccessServiceLinqToDb : IDataAccessService
    {
        private readonly DataContextLinqToDatabase _context;
        public DataAccessServiceLinqToDb(IConfiguration config)
        {
            DataConnection.DefaultSettings = new DataContexSetting(config);
            _context = new DataContextLinqToDatabase();
        }
        public string Create(Car car)
        {

            try
            {
                _context.Insert(car);
                return "Created";
            }
            catch (Exception ex)
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

                _context.Delete(car);
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

                _context.Update(car);
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
