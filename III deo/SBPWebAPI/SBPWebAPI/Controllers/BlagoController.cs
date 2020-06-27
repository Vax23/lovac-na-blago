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
    public class BlagoController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiBlagoSaPoreklom/{porekloID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetBlagoPoreklo(int porekloID)
        {
            try
            {
                return new JsonResult(DataProvider.VratiBlagoSaPoreklom(porekloID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiSvaBlaga")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetBlaga()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSvaBlaga());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajBlagoSaPoreklom/{porekloId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddBlago([FromRoute(Name = "porekloId")] int porekloId,[FromBody] BlagoView b)
        {
            try
            {
                var por = DataProvider.VratiJednoBNC(porekloId);
                b.Porekla = por;
                DataProvider.DodajBlagoSaPoreklom(b);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniBlago")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeBlago([FromBody] BlagoView b)
        {
            try
            {
                DataProvider.AzurirajBlago(b);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiBlago/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteBlago(int id)
        {
            try
            {
                DataProvider.ObrisiBlago(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
