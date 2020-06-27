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
    [ApiController]
    [Route("[controller]")]
    public class ZastitaController : ControllerBase
    {
        #region Duhovi
        [HttpGet]
        [Route("PreuzmiDuhove")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetDuhove()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveDuhove());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajDuha")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddDuh([FromBody] DuhView d)
        {
            try
            {
                DataProvider.DodajDuha(d);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPut]
        [Route("PromeniDuha")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeDuh([FromBody] DuhView d)
        {
            try
            {
                DataProvider.AzurirajDuha(d);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete]
        [Route("IzbrisiDuha/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteDuh(int id)
        {
            try
            {
                DataProvider.ObrisiDuha(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region Kletva

        [HttpGet]
        [Route("PreuzmiKletve")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetKletve()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveKletve());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajKletvu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddKletva([FromBody] KletvaView k)
        {
            try
            {
                DataProvider.DodajKletvu(k);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniKletvu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeDuh([FromBody] KletvaView k)
        {
            try
            {
                DataProvider.AzurirajKletvu(k);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiKletvu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteKletva(int id)
        {
            try
            {
                DataProvider.ObrisiKletvu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Zmaj

        [HttpGet]
        [Route("PreuzmiZmajeve")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetZmajeve()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveZmajeve());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajZmaja")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddZmaj([FromBody] ZmajView z)
        {
            try
            {
                DataProvider.DodajZmaja(z);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniZmaja")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeZmaj([FromBody] ZmajView z)
        {
            try
            {
                DataProvider.AzurirajZmaja(z);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiZmaja/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteZmaj(int id)
        {
            try
            {
                DataProvider.ObrisiZmaja(id);
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
