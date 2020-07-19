
using LinqToDB.Mapping;

namespace ORM_Examples.Models
{
    [Table("Cars")]
    public class Car
    {
        [PrimaryKey,Identity]
        public int Id { get; set; }
        [Column(Name ="Make"),NotNull]
        public string Make { get; set; }

        [Column(Name = "Model"), NotNull]
        public string Model { get; set; }

        [Column(Name = "Version"), NotNull]
        public string Version { get; set; }
    }
}
