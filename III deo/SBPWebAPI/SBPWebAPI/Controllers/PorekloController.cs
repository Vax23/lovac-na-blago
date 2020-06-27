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
    public class PorekloController : ControllerBase
    {

        #region Blago nestalih civilizacija

        [HttpGet]
        [Route("PreuzmiBNC")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetBNC()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveBNC());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajBNC")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddBNC([FromBody] BlagoNestalihCivilizacijaView bnc)
        {
            try
            {
                DataProvider.DodajBNC(bnc);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniBNC")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeBNC([FromBody] BlagoNestalihCivilizacijaView bnc)
        {
            try
            {
                DataProvider.AzurirajBNC(bnc);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiBNC/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteBNC(int id)
        {
            try
            {
                DataProvider.ObrisiBNC(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Blago vitezova Templara

        [HttpGet]
        [Route("PreuzmiBVT")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetBVT()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveBVT());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajBVT")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddBVT([FromBody] BlagoVitezovaTemplaraView bvt)
        {
            try
            {
                DataProvider.DodajBVT(bvt);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        

        [HttpDelete]
        [Route("IzbrisiBVT/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteBVT(int id)
        {
            try
            {
                DataProvider.ObrisiBVT(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Blago nepoznatog porekla

        [HttpGet]
        [Route("PreuzmiBNP")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetBNP()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveBNP());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajBNP")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddBNP([FromBody] BlagoNepoznatogPoreklaView bnp)
        {
            try
            {
                DataProvider.DodajBNP(bnp);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }



        [HttpDelete]
        [Route("IzbrisiBNP/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteBNP(int id)
        {
            try
            {
                DataProvider.ObrisiBNP(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Gusarsko blago

        [HttpGet]
        [Route("PreuzmiGb")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetGb()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveGB());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajGB")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddGB([FromBody] GusarskoBlagoView gb)
        {
            try
            {
                DataProvider.DodajGB(gb);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }



        [HttpDelete]
        [Route("IzbrisiGB/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteGB(int id)
        {
            try
            {
                DataProvider.ObrisiGB(id);
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
