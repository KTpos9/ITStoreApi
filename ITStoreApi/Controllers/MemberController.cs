using ITStoreApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly SqlDataAccess _db;
        public MemberController(SqlDataAccess db)
        {
            _db = db;
        }
        // GET: api/<MemberController>
        [HttpGet]
        public Task<List<Member>> GetMember()
        {
            string sql = "select * from dbo.Member2";
            return _db.LoadData<Member, dynamic>(sql, new { });
        }

        // GET api/<MemberController>/5
        [HttpGet("getByID/{id}")]
        public Task<Member> GetMemberById(int Id)
        {
            string sql = @"select * from dbo.Member2 where MemberId=@Id";
            return _db.LoadSingleData<Member, dynamic>(sql, new { Id = Id });
        }

        [HttpGet("getByEmail/{email}")]
        public Task<Member> GetMemberByEmail(string email)
        {
            string sql = "select * from dbo.Member2 where Email=@Email";
            return _db.LoadSingleData<Member, dynamic>(sql, new { Email = email });
        }

        // POST api/<MemberController>
        [HttpPost]
        public Task InsertMember(Member member)
        {
            string sql = @"insert into dbo.Member2 (FirstName, LastName, Email, Password, Role) 
                          values (@FirstName, @LastName, @Email, @Password, @Role);";
            return _db.SaveData(sql, member);
        }

        // PUT api/<MemberController>/5
        [HttpPut("{id}")]
        public Task UpdateMember(Member member)
        {
            string sql = @"update dbo.Member2 set FirstName=@FirstName, LastName=@LastName, Email=@Email, Role=@Role where MemberId=@MemberId";
            return _db.SaveData(sql, member);
        }

        // DELETE api/<MemberController>/5
        [HttpDelete("{id}")]
        public Task DeleteMember(int id)
        {
            string sql = @"delete from dbo.Member2 
                          where MemberId = @Id";
            return _db.SaveData(sql, new { Id = id });
        }
    }
}
