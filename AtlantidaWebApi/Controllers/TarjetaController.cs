using AtlantidaWebApi.DC;
using AtlantidaWebApi.Models;
using AtlantidaWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtlantidaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {

        private readonly IService_Tarjeta _service;


        public TarjetaController(IService_Tarjeta service)
        {
            _service = service;
        }

        #region Obteniendo Todas las Trajetas

        [HttpGet]
        public IActionResult GetAll() 
        {
            try
            {
                var salida = _service.Tarjeta_ALL();

                if (salida.Count == 0)
                {
                    return NotFound("Tarjetas no disponibles");
                }
                return Ok(salida);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Obteniendo datos de una tarjeta

        [HttpGet ("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var salida = _service.Tarjeta_FIND(id);
                if (salida == null)
                {
                    return NotFound("Tarjeta no encontrada");
                }
                return Ok(salida);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Agregando nueva tarjeta

        [HttpPost]
        public IActionResult Post(Tarjeta model)
        {
            try
            {
                var salida = _service.Tarjeta_INS(model);
                return Ok(salida);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Actualizando una tarjeta

        [HttpPut]
        public IActionResult Put(Tarjeta model)
        {
            if (model == null || model.Id == 0)
            {
                if(model == null)
                {
                    return BadRequest("Datos invalidos");
                }
                else if (model.Id == 0)
                {
                    return BadRequest("Id de tarjeta Invalido");
                }
            }
            try
            {
                var salida = _service.Tarjeta_UPD(model);
                if (salida == "Id de tarjeta no encontrado")
                {
                    return NotFound("Id de tarjeta no encontrado");
                }

                return Ok(salida);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Eliminando una Tarjeta

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var salida = _service.Tarjeta_DEL(id);
                if (salida == "Tarjeta no encontrada")
                {
                    return NotFound("Tarjeta no encontrada");
                }
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
