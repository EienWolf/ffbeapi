using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ffbeApi.Implementations;
using ffbeApi.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ffbeApi.Controllers.V1
{
    [Route("api/[controller]")]
    public class ExpeditionsController : Controller
    {
        private readonly FFBEContext _ffbeContext;

        public ExpeditionsController(FFBEContext ffbeContext)
        {
            _ffbeContext = ffbeContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Expeditions = _ffbeContext.Expeditions;
            return new ListObjectResult(Expeditions) { ListName = nameof(Expeditions) };
        }

        [HttpGet("{id:int}")]
        public IActionResult GetByID(int id)
        {
            var unit = _ffbeContext.Expeditions.SingleOrDefault(m => m.Id == id);
            return new OkObjectResult(unit);
        }

        [HttpGet("{Name}")]
        public IActionResult Get(string Name)
        {
            var unit = _ffbeContext.Expeditions
                .SingleOrDefault(m => String.Equals(m.Name, Name, StringComparison.OrdinalIgnoreCase));
            return new OkObjectResult(unit);
        }
    }
}
