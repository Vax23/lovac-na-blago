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
    public class LovacController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiSveLovce")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetLovac()
        {
            try
            {
                return new JsonResult(DataProvider.VratiLovca());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiLovcaSaBlagom/{bID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetLovacblago(int bID)
        {
            try
            {
                return new JsonResult(DataProvider.VratiLovcaSaBlagom(bID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajLovcaSaBlagom/{blagoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddLovac([FromRoute(Name = "blagoId")] int blagoId, [FromBody] LovacView l)
        {
            try
            {
                var blago = DataProvider.VratiJednoBlago(blagoId);
                l.Blaga = blago;
                DataProvider.DodajLovcaSaBlagom(l);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniLovca")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeLovac([FromBody] LovacView l)
        {
            try
            {
                DataProvider.AzurirajLovca(l);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiLovca/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteLovac(int id)
        {
            try
            {
                DataProvider.ObrisiLovca(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
