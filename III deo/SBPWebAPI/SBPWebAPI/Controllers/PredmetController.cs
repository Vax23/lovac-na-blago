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
    public class PredmetController: ControllerBase
    {
        #region Knjiga

        [HttpGet]
        [Route("PreuzmiKnjiguSaBlagom/{bID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetJednuKnjigu(int bID)
        {
            try
            {
                return new JsonResult(DataProvider.VratiKnjiguSaBlagom(bID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiKnjige")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetKnjigu()
        {
            try
            {
                return new JsonResult(DataProvider.VratiKnjige());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        

        [HttpPost]
        [Route("DodajKnjiguSaBlagom/{blagoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddKnjiga([FromRoute(Name = "blagoId")] int blagoId, [FromBody] KnjigaView k)
        {
            try
            {
                var blago = DataProvider.VratiJednoBlago(blagoId);
                k.Blaga = blago;
                DataProvider.DodajKnjiguSaBlagom(k);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniKnjigu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeKnjiga([FromBody] KnjigaView k)
        {
            try
            {
                DataProvider.AzurirajKnjigu(k);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiKnjigu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteKnjiga(int id)
        {
            try
            {
                DataProvider.ObrisiKnjigu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Krst

        [HttpGet]
        [Route("PreuzmiKrstSaBlagom/{bID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetJedanKrst(int bID)
        {
            try
            {
                return new JsonResult(DataProvider.VratiKrstSaBlagom(bID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiKrstove")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetKrst()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveKrstove());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajKrstSaBlagom/{blagoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddKrst([FromRoute(Name = "blagoId")] int blagoId, [FromBody] KrstView k)
        {
            try
            {
                var blago = DataProvider.VratiJednoBlago(blagoId);
                k.Blaga = blago;
                DataProvider.DodajKrstSaBlagom(k);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniKrst")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeKrst([FromBody] KrstView k)
        {
            try
            {
                DataProvider.AzurirajKrst(k);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiKrst/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteKrst(int id)
        {
            try
            {
                DataProvider.ObrisiKrst(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        #endregion

        #region Lobanja


        [HttpGet]
        [Route("PreuzmiLobanjuSaBlagom/{bID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetJednaLobanja(int bID)
        {
            try
            {
                return new JsonResult(DataProvider.VratiLobanjuSaBlagom(bID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiLobanje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetLobanja()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveLobanje());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajLobanjuSaBlagom/{blagoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddLobanja([FromRoute(Name = "blagoId")] int blagoId, [FromBody] LobanjaView l)
        {
            try
            {
                var blago = DataProvider.VratiJednoBlago(blagoId);
                l.Blaga = blago;
                DataProvider.DodajLobanjuSaBlagom(l);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniLobanju")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeLobanja([FromBody] LobanjaView l)
        {
            try
            {
                DataProvider.AzurirajLobanju(l);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiLobanju/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteLobanja(int id)
        {
            try
            {
                DataProvider.ObrisiLobanju(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Mac

        [HttpGet]
        [Route("PreuzmiMacSaBlagom/{bID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetJedanMac(int bID)
        {
            try
            {
                return new JsonResult(DataProvider.VratiMacSaBlagom(bID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiMaceve")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetMac()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveMaceve());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajMacSaBlagom/{blagoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddMac([FromRoute(Name = "blagoId")] int blagoId, [FromBody] MacView m)
        {
            try
            {
                var blago = DataProvider.VratiJednoBlago(blagoId);
                m.Blaga = blago;
                DataProvider.DodajMacSaBlagom(m);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniMac")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeMac([FromBody] MacView m)
        {
            try
            {
                DataProvider.AzurirajMac(m);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiMac/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteMac(int id)
        {
            try
            {
                DataProvider.ObrisiMac(id);
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
