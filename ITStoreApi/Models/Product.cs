namespace ITStoreApi.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductImg { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public float ProductPrice { get; set; }
        public string ProductCategory { get; set; }
    }
}
