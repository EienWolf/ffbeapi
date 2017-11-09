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
    public class SummonBoardsController : Controller
    {
        private readonly FFBEContext _ffbeContext;

        public SummonBoardsController(FFBEContext ffbeContext)
        {
            _ffbeContext = ffbeContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var SummonBoards = _ffbeContext.SummonBoards;
            return new ListObjectResult(SummonBoards) { ListName = nameof(SummonBoards) };
        }

        [HttpGet("{id:int}")]
        public IActionResult GetByID(int id)
        {
            var unit = _ffbeContext.SummonBoards.SingleOrDefault(m => m.Id == id);
            return new OkObjectResult(unit);
        }

        //Ni idea
        //[HttpGet("{Name}")]
        //public IActionResult Get(string Name)
        //{
        //    var unit = _ffbeContext.SummonBoards
        //        .SingleOrDefault(m => String.Equals(m.Name, Name, StringComparison.OrdinalIgnoreCase));
        //    return new OkObjectResult(unit);
        //}
    }
}
