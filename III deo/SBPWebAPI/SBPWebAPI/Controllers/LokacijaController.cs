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
    [ApiController]
    [Route("[controller]")]
    public class LokacijaController : ControllerBase
    {
        #region Grobnica

        [HttpGet]
        [Route("PreuzmiGrobnicuSaBlagom/{bId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetGrobnicaBlago(int bId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiGrobnicuSaBlagom(bId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiGrobnicu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetGrobnica()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveGrobnice());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajGrobnicuSaBlagom/{blagoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddGrobnica([FromRoute(Name = "blagoId")] int blagoId, [FromBody] GrobnicaView g)
        {
            try
            {
                var blago = DataProvider.VratiJednoBlago(blagoId);
                g.Blaga = blago;
                DataProvider.DodajGrobnicuSaBlagom(g);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniGrobnicu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeGrobnica([FromBody] GrobnicaView g)
        {
            try
            {
                DataProvider.AzurirajGrobnicu(g);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiGrobnicu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteGrobnica(int id)
        {
            try
            {
                DataProvider.ObrisiGrobnicu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Grad duhova

        [HttpGet]
        [Route("PreuzmiGradDuhovaSaBlagom/{bId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetGradDuhovaBlago(int bId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiGradDuhovaSaBlagom(bId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiGradoveDuhova")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetGradDuhova()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveGradoveDuhova());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajGradDuhovaSaBlagom/{blagoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddGradDuhova([FromRoute(Name = "blagoId")] int blagoId, [FromBody] GradDuhovaView g)
        {
            try
            {
                var blago = DataProvider.VratiJednoBlago(blagoId);
                g.Blaga = blago;
                DataProvider.DodajGradDuhovaSaBlagom(g);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniGradDuhova")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeGradDuhova([FromBody] GradDuhovaView gd)
        {
            try
            {
                DataProvider.AzurirajGradDuhova(gd);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }



        [HttpDelete]
        [Route("IzbrisiGradDuhova/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteGradDuhova(int id)
        {
            try
            {
                DataProvider.ObrisiGradDuhova(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Pecina

        [HttpGet]
        [Route("PreuzmiPecinuSaBlagom/{bId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPecinaBlago(int bId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiPecinuSaBlagom(bId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiPecine")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPecina()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSvePecine());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajPecinuSaBlagom/{blagoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddPecina([FromRoute(Name = "blagoId")] int blagoId, [FromBody] PecinaView p)
        {
            try
            {
                var blago = DataProvider.VratiJednoBlago(blagoId);
                p.Blaga = blago;
                DataProvider.DodajPecinuSaBlagom(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPut]
        [Route("PromeniPecinu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangePecina([FromBody] PecinaView p)
        {
            try
            {
                DataProvider.AzurirajPecinu(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete]
        [Route("IzbrisiPecinu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeletePecina(int id)
        {
            try
            {
                DataProvider.ObrisiPecinu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Ostrvo

        [HttpGet]
        [Route("PreuzmiOstrvoSaBlagom/{bId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetOstrvoBlago(int bId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiOstrvoSaBlagom(bId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiOstrva")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetOstrvo()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSvaOstrva());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajOstrvoSaBlagom/{blagoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddOstrvo([FromRoute(Name = "blagoId")] int blagoId, [FromBody] OstrvoView o)
        {
            try
            {
                var blago = DataProvider.VratiJednoBlago(blagoId);
                o.Blaga = blago;
                DataProvider.DodajOstrvoSaBlagom(o);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniOstrvo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeOstrvo([FromBody] OstrvoView o)
        {
            try
            {
                DataProvider.AzurirajOstrvo(o);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiOstrvo/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteOstrvo(int id)
        {
            try
            {
                DataProvider.ObrisiOstrvo(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Piramida

        [HttpGet]
        [Route("PreuzmiPiramiduSaBlagom/{bId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPiramidaBlago(int bId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiPiramiduSaBlagom(bId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiPiramide")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPiramida()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSvePiramide());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajPiramiduSaBlagom/{blagoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddPiramida([FromRoute(Name = "blagoId")] int blagoId, [FromBody] PiramidaView p)
        {
            try
            {
                var blago = DataProvider.VratiJednoBlago(blagoId);
                p.Blaga = blago;
                DataProvider.DodajPiramiduSaBlagom(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniPiramidu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangePiramida([FromBody] PiramidaView p)
        {
            try
            {
                DataProvider.AzurirajPiramidu(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiPiramidu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeletePiramida(int id)
        {
            try
            {
                DataProvider.ObrisiPiramidu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Ukleti zamak

        [HttpGet]
        [Route("PreuzmiUkletiZamakSaBlagom/{bId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetUkletiZamakBlago(int bId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiUkletiZamakSaBlagom(bId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiUkleteZamkove")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetUkletiZamak()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveUkleteZamkove());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajUkletiZamakSaBlagom/{blagoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddUkletiZamak([FromRoute(Name = "blagoId")] int blagoId, [FromBody] UkletiZamakView uz)
        {
            try
            {
                var blago = DataProvider.VratiJednoBlago(blagoId);
                uz.Blaga = blago;
                DataProvider.DodajUkletiZamakSaBlagom(uz);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniUkletiZamak")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeUkletiZamak([FromBody] UkletiZamakView uz)
        {
            try
            {
                DataProvider.AzurirajUkletiZamak(uz);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiUkletiZamak/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteUkletiZamak(int id)
        {
            try
            {
                DataProvider.ObrisiUkletiZamak(id);
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
