using ENSEK.FileHandlers;
using ENSEK.Models;
using Microsoft.AspNetCore.Mvc;

namespace ENSEK.Controllers
{
    [ApiController]
    [Route("/account-uploads")]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "/account-uploads")]
        //public IEnumerable<Account> Post()
        public string Post(IFormFile content)
        {
            AccountFileHandler handler = new AccountFileHandler();
            return handler.HandleFile(content).Result;
        }
    }
}
