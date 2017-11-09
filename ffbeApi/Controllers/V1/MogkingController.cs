using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ffbeApi.Database;
using ffbeApi.Implementations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ffbeApi.Controllers.V1
{
    [Route("api/[controller]")]
    public class MogkingController : Controller
    {
        private readonly FFBEContext _ffbeContext;

        public MogkingController(FFBEContext ffbeContext)
        {
            _ffbeContext = ffbeContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Mogking = _ffbeContext.Mogking;
            return new ListObjectResult(Mogking) { ListName = nameof(Mogking) };
        }

        [HttpGet("{id:int}")]
        public IActionResult GetByID(int id)
        {
            var unit = _ffbeContext.Mogking.SingleOrDefault(m => m.Id == id);
            return new OkObjectResult(unit);
        }

        //Se puede filtrar por el currency_item... 
        //[HttpGet("{Name}")]
        //public IActionResult Get(string Name)
        //{
        //    var unit = _ffbeContext.Mogking
        //        .SingleOrDefault(m => String.Equals(m.Name, Name, StringComparison.OrdinalIgnoreCase));
        //    return new OkObjectResult(unit);
        //}
    }
}
