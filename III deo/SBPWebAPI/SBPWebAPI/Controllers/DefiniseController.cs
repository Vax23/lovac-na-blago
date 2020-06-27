using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DatabaseAccess;
using DatabaseAccess.DTOs;

namespace SBPWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DefiniseController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiDefinisanja/{idLeg}/{idLok}/{idZas}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetDefinisanje(int idLeg, int idLok, int idZas)
        {
            try
            {
                return new JsonResult(DataProvider.VratiDefinisanja(idLeg, idLok, idZas));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajDefinisanje/{idLeg}/{idLok}/{idZas}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddDefinisanje([FromRoute(Name = "idLeg")] int idLeg, [FromRoute(Name = "idLok")] int idLok, [FromRoute(Name = "idZas")] int idZas, [FromBody] DefiniseView d)
        {
            try
            {
                var leg = DataProvider.VratiJednuLegendu(idLeg);
                d.Legende = leg;
                var lok = DataProvider.VratiJednuPiramidu(idLok);
                d.Lokacije = lok;
                var zas = DataProvider.VratiJednogDuha(idZas);
                d.Zastite = zas;
                DataProvider.DodajDefinisanje(d);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPut]
        [Route("PromeniDefinisanje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeDefinisanje([FromBody] DefiniseView d)
        {
            try
            {
               
                DataProvider.AzurirajDefinisanje(d);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete]
        [Route("IzbrisiDefinisanje/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteDefinisanje(int id)
        {
            try
            {
                DataProvider.ObrisiDefinisanje(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
