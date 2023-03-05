using ITStoreApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly SqlDataAccess _db;
        public OrderController(SqlDataAccess db)
        {
            _db = db;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public Task<List<Order>> GetOrder()
        {
            string sql = "select * from dbo.Order2";
            return _db.LoadData<Order, dynamic>(sql, new { });
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public Task<Order> GetOrderById(int id)
        {
            string sql = @"select * from dbo.Order2 where ProductId=@Id";
            return _db.LoadSingleData<Order, dynamic>(sql, new { Id = id });
        }

        // POST api/<OrderController>
        [HttpPost]
        public Task InsertOrder(Order newOrder)
        {
            string sql = @"insert into dbo.Order2 (OrderDate, ProductName, ProductImg, ProductPrice) 
                          values (@Img, @Name, @Desc, @Price);";
            return _db.SaveData(sql, new { Date = newOrder.OrderDate, Name = newOrder.ProductName, Img = newOrder.ProductImg, Price = newOrder.ProductPrice });
        }

        // PUT api/<OrderController>/5
        //TODO: implement update order by id 
        [HttpPut("{id}")]
        public Task UpdateOrder(Order order)
        {
            string sql = @"update dbo.Order2 set ProductImg=@ProductImg, ProductName=@ProductName, ProductDesc=@ProductDesc, ProductPrice=@ProductPrice where ProductId=@ProductId";
            return _db.SaveData(sql, order);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public Task DeleteProduct(int id)
        {
            string sql = @"delete from dbo.Order2 
                          where OrderID = @Id";
            return _db.SaveData(sql, new { Id = id });
        }
    }
}
