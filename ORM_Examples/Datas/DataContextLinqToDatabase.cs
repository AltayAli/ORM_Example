using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ORM_Examples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM_Examples.Datas
{
    public class DataContextLinqToDatabase :DataConnection
    {
       public DataContextLinqToDatabase() : base("DataContext") {}

        public ITable<Car> Cars => GetTable<Car>();

        
    }

    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }
    public class DataContexSetting : ILinqToDBSettings
    {
        private readonly IConfiguration _config;
        public DataContexSetting(IConfiguration config)
        {
            _config = config;
        }
        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

        public string DefaultConfiguration => "SqlServer";
        public string DefaultDataProvider => "SqlServer";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "DataContext",
                        ProviderName = "SqlServer",
                        ConnectionString = _config["ConnectionString"]
                    };
            }
        }
    }
}
