using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace firstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("get")]
        public IActionResult Index()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(3);
            Response.Cookies.Append("key", "value", options);
            return Ok();
        }
        [HttpPost("update")]
        public IActionResult UpdateCookie(string key, string value)
        {
            
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.CreateCookieHeader(key, value);
            Response.Cookies.Append(key, value, cookieOptions);
            return Ok(cookieOptions);
        }
    }
}
