namespace NoSql_Inlamning.Models.Requests
{
    public class ProductUpdateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }  
        public int ArticleNumber { get; set; }
    }
}
