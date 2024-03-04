using AtlantidaWebApi.DC;
using AtlantidaWebApi.Models;
using AtlantidaWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtlantidaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransaccionController : ControllerBase   
    {
        private readonly IService_Transaccion _service;

        public TransaccionController(IService_Transaccion service)
        {
            _service = service;
        }

        #region Obteniedo todas las transaciones de una tarjeta
        [HttpGet("{id}")]
        public  IActionResult GetTransacciones(int id)
        {
            try
            {
                var salida =  _service.Transaccion_ALL(id);
                return Ok(salida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Obteniendo los abonos de una tarjeta
        [HttpGet("{id}")]
        public IActionResult GetTransaccionesAbonos(int id)
        {
            try
            {
                var salida = _service.Transaccion_ABONOS(id);
                return Ok(salida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Obteniendo los cargos de una tarjeta
        [HttpGet ("{id}")]
        public IActionResult GetTransaccionesCargos(int id)
        {
            try
            {
                var salida = _service.Transaccion_CARGOS(id);
                return Ok(salida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Agregando una nueva transaccion 
        [HttpPost("{id}")]
        public IActionResult InsertarTransaccion(Transaccion model, int id)
        {
            try
            {
                var salida = _service.Transaccion_INS(model, id);
                return Ok(salida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
