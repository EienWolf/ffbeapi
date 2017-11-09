using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ffbeApi.Database;
using ffbeApi.Implementations;

namespace ffbeApi.Controllers.V1
{
    [Route("api/[controller]")]
    public class UnitsController : Controller
    {
        private readonly FFBEContext _ffbeContext;

        public UnitsController(FFBEContext ffbeContext)
        {
            _ffbeContext = ffbeContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var units = _ffbeContext.Units;
            return new ListObjectResult(units) { ListName = nameof(units) };
        }

        [HttpGet("{ID:int}")]
        public IActionResult GetByID(int id)
        {
            var unit = _ffbeContext.Units.SingleOrDefault(m => m.Id == id);
            return new OkObjectResult(unit);
        }

        [HttpGet("{Name}")]
        public IActionResult Get(string Name)
        {
            

            var unit = _ffbeContext.Units
                .Select(m => new {
                    Name = m.Name,
                    Skills = m.Skills
                })
                .SingleOrDefault(m => String.Equals(m.Name, Name, StringComparison.OrdinalIgnoreCase));

            var skillsids = unit.Skills.Select(m => m.Id);
            var _Skills = _ffbeContext.Skills.Where(m => skillsids.Contains(m.Id));
            var unite = new {
                Name = unit.Name,
                Skills = _Skills.Select(m => new {
                    m.Name,
                    m.MoveType,
                    Level = unit.Skills.SingleOrDefault(n => n.Id == m.Id).Level,
                    m.Strings
                })
            };
            return new OkObjectResult(unite);
        }

        
    }
}
