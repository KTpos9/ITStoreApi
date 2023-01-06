using ITStoreApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly SqlDataAccess _db;
        public ProductController(SqlDataAccess db)
        {
            _db = db;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public Task<List<Product>> GetProduct()
        {
            string sql = "select * from dbo.Product2";
            return _db.LoadData<Product, dynamic>(sql, new { });
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Task<Product> GetProductById(int Id)
        {
            string sql = @"select * from dbo.Product2 where ProductId=@Id";
            return _db.LoadSingleData<Product, dynamic>(sql, new { Id = Id });
        }

        // POST api/<ProductController>
        [HttpPost]
        public Task InsertProduct(Product newProduct)
        {
            string sql = @"insert into dbo.Product2 (ProductImg, ProductName, ProductDesc, ProductPrice) 
                          values (@Img, @Name, @Desc, @Price);";
            return _db.SaveData(sql, new { Img = newProduct.ProductImg, Name = newProduct.ProductName, Desc = newProduct.ProductDesc, Price = newProduct.ProductPrice });
        }

        // PUT api/<ProductController>/5
        //TODO: implement update order by id 
        [HttpPut("{id}")]
        public Task UpdateProduct(Product product)
        {
            string sql = @"update dbo.Product2 set ProductImg=@ProductImg, ProductName=@ProductName, ProductDesc=@ProductDesc, ProductPrice=@ProductPrice where ProductId=@ProductId";
            return _db.SaveData(sql, product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public Task DeleteProduct(int Id)
        {
            string sql = @"delete from dbo.Product2 
                          where ProductId = @Id";
            return _db.SaveData(sql, new { Id = Id });
        }
    }
}
