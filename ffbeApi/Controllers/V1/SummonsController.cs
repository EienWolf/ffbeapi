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
    public class SummonsController : Controller
    {
        private readonly FFBEContext _ffbeContext;

        public SummonsController(FFBEContext ffbeContext)
        {
            _ffbeContext = ffbeContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Summons = _ffbeContext.Summons;
            return new ListObjectResult(Summons) { ListName = nameof(Summons) };
        }

        [HttpGet("{id:int}")]
        public IActionResult GetByID(int id)
        {
            var unit = _ffbeContext.Summons.SingleOrDefault(m => m.Id == id);
            return new OkObjectResult(unit);
        }

        //En teoria se debe poder filtrar por names
        //[HttpGet("{Name}")]
        //public IActionResult Get(string Name)
        //{
        //    var unit = _ffbeContext.Summons
        //        .SingleOrDefault(m => String.Equals(m.Name, Name, StringComparison.OrdinalIgnoreCase));
        //    return new OkObjectResult(unit);
        //}
    }
}
