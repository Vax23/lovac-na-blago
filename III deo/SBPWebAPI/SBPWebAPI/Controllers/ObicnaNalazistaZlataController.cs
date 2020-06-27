using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Routing;

namespace SBPWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ObicnaNalazistaZlataController : ControllerBase
    {
        #region Zlatne zile

        [HttpGet]
        [Route("PreuzmiZlatneZile")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetZlatneZile()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveZlatneZile());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajZlatnuZilu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddZlatnaZila([FromBody] ZlatneZileView zz)
        {
            try
            {
                DataProvider.DodajZlatnuZilu(zz);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniZlatnuZilu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeZlatnaZila([FromBody] ZlatneZileView zz)
        {
            try
            {
                DataProvider.AzurirajZlatnuZilu(zz);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiZlatnuZilu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteZlatnaZila(int id)
        {
            try
            {
                DataProvider.ObrisiZlatnuZilu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Zlatonosne reke

        [HttpGet]
        [Route("PreuzmiZlatonosneReke")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetZlatonosneReke()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveZlatonosneReke());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajZlatonosnuReku")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddZlatonosnaReka([FromBody] ZlatonosneRekeView zr)
        {
            try
            {
                DataProvider.DodajZlatonosnuReku(zr);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniZlatonosnuReku")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeZlatonosnaReka([FromBody] ZlatonosneRekeView zr)
        {
            try
            {
                DataProvider.AzurirajZlatonosnuReku(zr);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiZlatonosnuReku/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteZlatonosnaReka(int id)
        {
            try
            {
                DataProvider.ObrisiZlatonosnuReku(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion
    }
}
