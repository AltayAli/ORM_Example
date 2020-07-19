using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ORM_Examples.Models;

namespace ORM_Examples.Datas
{
    public class DataContextEntityFramework : DbContext
    {
        private readonly IConfiguration _config;
        public DataContextEntityFramework(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_config["ConnectionString"]);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
