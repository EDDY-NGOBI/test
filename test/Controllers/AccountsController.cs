using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace test.Controllers
{
    [ApiController]
    [Route("/Accounts")]
    public class AccountsController : ControllerBase
    {

        
       

        

        // POST: AccountsController/Create
        [HttpPost]
        
        public  string  Login(PostName name)
        {
            return "hello "+ name.Name+"you have connected to the api";
        }
        

    }
}
