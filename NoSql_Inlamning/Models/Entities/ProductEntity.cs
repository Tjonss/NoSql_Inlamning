using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace NoSql_Inlamning.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        [JsonProperty("id")]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int ArticleNumber { get; set; }
        public string PartitionKey { get; set; } = null!;

    }
}
