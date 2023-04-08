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
        [HttpGet("getByID/{id}")]
        public Task<Product> GetProductById(int id)
        {
            string sql = @"select * from dbo.Product2 where ProductId=@Id";
            return _db.LoadSingleData<Product, dynamic>(sql, new { Id = id });
        }

        [HttpGet("search")]
        public Task<List<Product>> SearchProduct(string q)
        {
            string sql = @"select * 
                           from Product2
                            where ProductName like @q or ProductCategory = @q2";
            return _db.LoadData<Product,dynamic>(sql, new { q = $"%{q}%", q2 = q });
        }

        // POST api/<ProductController>
        [HttpPost]
        public Task InsertProduct(Product newProduct)
        {
            string sql = @"insert into dbo.Product2 (ProductImg, ProductName, ProductDesc, ProductPrice, ProductCategory) 
                          values (@Img, @Name, @Desc, @Price, @Category);";
            return _db.SaveData(sql, new { Img = newProduct.ProductImg, Name = newProduct.ProductName, Desc = newProduct.ProductDesc, Price = newProduct.ProductPrice, Category = newProduct.ProductCategory });
        }

        // PUT api/<ProductController>/5
        //TODO: implement update order by id 
        [HttpPut]
        public Task UpdateProduct(Product product)
        {
            string sql = @"update dbo.Product2 set ProductImg=@ProductImg, ProductName=@ProductName, ProductDesc=@ProductDesc, ProductPrice=@ProductPrice, ProductCategory=@ProductCategory where ProductId=@ProductId";
            return _db.SaveData(sql, product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public Task DeleteProduct(int id)
        {
            string sql = @"delete from dbo.Product2 
                          where ProductId = @Id";
            return _db.SaveData(sql, new { Id = id });
        }
    }
}
