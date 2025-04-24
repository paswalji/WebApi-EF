using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using webapiwithentityframework.Models;

namespace webapiwithentityframework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _userContext;
        public UsersController(UserContext userContext)
        {
            _userContext = userContext;
        }
       
        [HttpGet]
        public IActionResult Get([FromQuery] int limit = 10)
        {
            var user = _userContext.Users.Take(limit).ToList();
            return Ok(new { message = "Ok", data = user});
        }


        [HttpPost]
        public IActionResult Post([FromBody] string users)
        {
            if (users == null)
            {
                return BadRequest(new { message = "Enter the User Data."});
            }
            _userContext.Users.Add( new Users { name = users});
            _userContext.SaveChanges();
            return Ok(new { message = "User Add Successfully."});
        }

        [HttpPut]
        public IActionResult Put([FromBody] Users users)
        {
            if (users == null)
            {
                return BadRequest(new { message = "Enter the User Data." });
            }

            var user = _userContext.Users.Where(x=>x.id == users.id).FirstOrDefault();

            if(user == null)
            {
                return BadRequest(new { message = "User not found !" });
            }

            user.name = users.name;
            _userContext.SaveChanges();
            return Ok(new { message = "User update Successfully." });
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] int id )
        {
            
            var user = _userContext.Users.Where(x => x.id == id).FirstOrDefault();

            if (user == null)
            {
                return BadRequest(new { message = "User not found !" });
            }

            _userContext.Users.Remove( user );            
            _userContext.SaveChanges();
            return Ok(new { message = "User update Successfully." });
        }

    }
}
