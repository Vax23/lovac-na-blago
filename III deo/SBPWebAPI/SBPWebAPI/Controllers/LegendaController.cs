using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Routing;

namespace SBPWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LegendaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiLegenduSaBlagom/{bId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetLegendaBlago(int bId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiLegenduSaBlagom(bId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiLegende")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetLegenda()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveLegende());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajLegenduSaBlagom/{blagoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddLegenda([FromRoute(Name = "blagoId")] int blagoId, [FromBody] LegendaView l)
        {
            try
            {
                var blago = DataProvider.VratiJednoBlago(blagoId);
                l.Blaga = blago;
                DataProvider.DodajLegenduSaBlagom(l);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniLegendu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeLegenda([FromBody] LegendaView l)
        {
            try
            {
                DataProvider.AzurirajLegendu(l);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiLegendu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteLegenda(int id)
        {
            try
            {
                DataProvider.ObrisiLegendu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
