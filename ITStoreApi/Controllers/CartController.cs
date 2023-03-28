using ITStoreApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly SqlDataAccess _db;
        public CartController(SqlDataAccess db)
        {
            _db = db;
        }
        // GET: api/<CartController>
        [HttpGet]
        public Task<List<Cart>> Get()
        {
            string sql = "select * from dbo.Cart2";
            return _db.LoadData<Cart, dynamic>(sql, new { });
        }

        // POST api/<CartController>
        [HttpPost]
        public Task InsertCart(Cart cart)
        {
            string sql = @"insert into dbo.Cart2 (ProductImg, ProductName, ProductPrice, ProductAmount) 
                          values (@ProductImg, @ProductName, @ProductPrice, @ProductAmount);"; 
            return _db.SaveData(sql, cart);
        }

        //// PUT api/<CartController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public Task DeleteCartByID(int id)
        {
            string sql = @"delete from dbo.Cart2
                           where CartID = @CartID";
            return _db.SaveData(sql, new { CartID = id });
        }
    }
}
