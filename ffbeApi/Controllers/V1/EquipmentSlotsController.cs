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
    public class EquipmentSlotsController : Controller
    {
        private readonly FFBEContext _ffbeContext;

        public EquipmentSlotsController(FFBEContext ffbeContext)
        {
            _ffbeContext = ffbeContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var equipmentSlots = _ffbeContext.EquipmentSlots;
            return new ListObjectResult(equipmentSlots) { ListName = nameof(equipmentSlots) };
        }

        [HttpGet("{id:int}")]
        public IActionResult GetByID(int id)
        {
            var unit = _ffbeContext.EquipmentSlots.SingleOrDefault(m => m.Id == id);
            return new OkObjectResult(unit);
        }

        [HttpGet("{Name}")]
        public IActionResult Get(string Name)
        {
            var unit = _ffbeContext.EquipmentSlots
                .SingleOrDefault(m => String.Equals(m.Name, Name, StringComparison.OrdinalIgnoreCase));
            return new OkObjectResult(unit);
        }
    }
}
