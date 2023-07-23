using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private static readonly User[] _users = new User[]
        {
            new User { UserId = 1001, Password = "secret" },
            new User { UserId = 1002, Password = "password123" },
            new User { UserId = 1003, Password = "qwerty" },
            new User { UserId = 1004, Password = "letmein" },
            new User { UserId = 1005, Password = "123456" }
        };

        // POST: /Accounts/Login
        [HttpPost("Login")]
        public ActionResult<string> Login(PostData postData)
        {
            int userId = postData.UserId;
            string password = postData.Password;

            // Check if the entered user ID and password are correct
            var matchingUser = _users.FirstOrDefault(u => u.UserId == userId && u.Password == password);
            if (matchingUser != null)
            {
                return Ok($"Hello, {userId}! You have successfully connected to the API.");
            }
            else
            {
                return BadRequest("Invalid credentials. Please try again.");
            }
        }
    }

    public class PostData
    {
        public int UserId { get; set; }
        public string Password { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Password { get; set; }
    }
}
