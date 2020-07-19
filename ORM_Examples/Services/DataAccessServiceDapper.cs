using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ORM_Examples.Interfaces;
using ORM_Examples.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ORM_Examples.Services
{
    public class DataAccessServiceDapper : IDataAccessService
    {
        private readonly IDbConnection _connection;
        public DataAccessServiceDapper(IConfiguration config)
        {
            _connection = new SqlConnection(config["ConnectionString"]);
        }
        public string Create(Car car)
        {
            try
            {
                _connection.Open();
                var result =_connection.Execute(@"INSERT INTO Cars(Make, Model, Version) 
                                                VALUES(@Make, @Model, @Version)", car);
                _connection.Close();
                if(result ==0)
                    throw new Exception("Əməliyyatda səhvlik var!!!");

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
                _connection.Open();
                var result =_connection.Execute(@"DELETE FROM Cars Where Id = @Id", new { Id=id });

                _connection.Close();
                if (result==0)
                    throw new Exception("Model tapılmadı!!!");

                return "Edited";
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
                _connection.Open();
                var result = _connection.Execute(@"UPDATE Cars SET Make = @Make, 
                                    Model=@Model, Version = @Version 
                                     Where Id = @Id",car);
                _connection.Close();
                if (result == 0)
                    throw new Exception("Model tapılmadı!!!");

                return "Edited";
            }
            catch (Exception ex)
            {
                return $"Error : {ex.Message}";
            }
        }

        public IEnumerable<Car> GetList()
        {
            _connection.Open();
            var result = _connection.Query<Car>("SELECT * FROM Cars");
            _connection.Close();
            return result;
        }
        public Car GetSimple(int id)
        {
            _connection.Open();
            var result = _connection
                        .QueryFirstOrDefault<Car>("SELECT * FROM Cars WHERE Id = @Id",
                                    new { Id = id});
            _connection.Close();
            return result;
        }
    }
}
