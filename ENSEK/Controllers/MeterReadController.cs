using ENSEK.Models;
using ENSEK.DataAdapters;
using Microsoft.AspNetCore.Mvc;
using ENSEK.FileHandlers;

namespace ENSEK.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeterReadController : ControllerBase
    {

        private readonly ILogger<MeterReadController> _logger;

        public MeterReadController(ILogger<MeterReadController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "/meter-reading-uploads")]
        //public IEnumerable<MeterRead> Post()
        public string Post(IFormFile content)
        {
            MeterReadFileHandler handler = new MeterReadFileHandler();
            return handler.HandleFile(content).Result;
        }
    }
}
