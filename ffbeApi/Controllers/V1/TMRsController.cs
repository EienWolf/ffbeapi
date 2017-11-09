using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ffbeApi.Database;
using ffbeApi.Implementations;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using ffbeApi.Database.Views;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ffbeApi.Controllers.V1
{
    [Route("api/[controller]")]
    public class TMRsController : Controller
    {
        private readonly FFBEContext _ffbeContext;

        public TMRsController(FFBEContext ffbeContext)
        {
            _ffbeContext = ffbeContext;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]string locale = "en")
        {
            //var unitsTest = new List<string>() { "A2", "Zidane" };
            var tmrs = _ffbeContext.Units
            //.Where(m => unitsTest.Contains(m.Name))
            .Select(m => new {
                UnitID = m.Id,
                UnitName = m.Name,
                TMRID = m.TmrId,
                TMRType = m.TmrType,
                TMRSubtype = m.TmrType == "EQUIP" ? m.TMEquip.Type.Name : "Materia",
                TMRName = m.TmrType == "EQUIP" ? m.TMEquip.StringNames.ContainsKey(locale) ? m.TMEquip.StringNames[locale] : m.TMEquip.StringNames["en"] 
                        : m.TMMateria.StringNames.ContainsKey(locale) ? m.TMMateria.StringNames[locale] : m.TMMateria.StringNames["en"],
                TMRStats = m.TmrType == "EQUIP" ? JsonConvert.DeserializeObject(m.TMEquip.Stats) : null,
                TMREquipSkills = m.TMEquip.SkillsList,
                TMRMateriaSkills = m.TMMateria.SkillsList,
                TMRSkills = string.IsNullOrWhiteSpace(m.TmrType) ? null :
                    _ffbeContext.Skills
                    .Where(n => m.TmrType == "EQUIP" ? m.TMEquip.SkillsList.SingleOrDefault(o => o == n.Id) != 0
                        : m.TMMateria.SkillsList.SingleOrDefault(o => o == n.Id) != 0)
                    .Select(n => new
                    {
                        ID = n.Id,
                        Name = n.Name,

                    })

            });
            return new ListObjectResult(tmrs) { ListName = nameof(tmrs) };
        }

        [HttpGet("V2")]
        public IActionResult GetV2([FromQuery]string locale = "en")
        {
            //var unitsTest = new List<string>() { "A2", "Zidane" };
            var tmrs = _ffbeContext.TMRs.FromSql<TMRs>("SELECT Units.Id AS UnitId, Units.Name AS UnitName\r\n    , Units.\"TMR_id\" AS TMRID\r\n    , Units.\"TMR_type\" AS TMRType\r\n    , COALESCE(EquipmentType.Name, 'Materia') AS TMRSubType\r\n    , COALESCE(Materias.Name, Equipment.Name) AS TMRName\r\n    , COALESCE(Materias.Strings, Equipment.Strings) AS TMRStrings\r\n    , (SELECT array_to_json(ARRAY_AGG(row_to_json(T))) FROM(\r\n        SELECT Skills.id, Skills.name FROM public.Skills AS Skills\r\n        INNER JOIN regexp_split_to_table(REPLACE(REPLACE(CAST(COALESCE(Materias.Skills, Equipment.Skills) AS VARCHAR), '[', ''), ']', ''), ',') AS X\r\n\r\n        ON CAST(Skills.id AS TEXT) = x \r\n    ) T) AS Skills\r\nFROM public.Units AS Units\r\nLEFT JOIN public.Materias AS Materias\r\nON Units.\"TMR_type\" = 'MATERIA'\r\nAND Units.\"TMR_id\" = Materias.Id\r\nLEFT JOIN public.Equipment AS Equipment\r\nON Units.\"TMR_type\" = 'EQUIP'\r\nAND Units.\"TMR_id\" = Equipment.Id\r\nLEFT JOIN public.Equipment_types AS EquipmentType\r\nON Equipment.\"type_id\" = EquipmentType.id");
            return new ListObjectResult(tmrs) { ListName = nameof(tmrs) };
        }

    }
}
