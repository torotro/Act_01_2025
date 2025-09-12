using facturaApp.data.implementations;
using facturaApp.domain;
using facturaApp.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Drawing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_factura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private ibillServices _service;
        

        public FacturasController() 
        {
           _service= new Billservices();
           
        }
        // GET: api/<FacturasController>
        [HttpGet]
        public IActionResult Get()
        {
           
            try
            {
                return Ok(_service.getBills());
            }
            catch (Exception ex) 
            {
              return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "error,intente de nuevo" });
            }
        }

        // GET api/<FacturasController>/5
        [HttpGet("{id}")]
        public IActionResult Post(int id)
        {

            try
            {
                var bill = _service.getbillbyID(id);
                if (bill == null)
                    return NotFound(new { mensaje = "Factura no encontrada" });

                return Ok(bill);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error, intente de nuevo" });
            }
        }

        // POST api/<FacturasController>
    
        

            [HttpPost]
            public IActionResult Post([FromBody] Bill valor)
            {
            try
            {
                if (valor == null)
                {
                    return BadRequest(new { mensaje = "Factura inválida" });
                }

                
                if (_service.Transaction(valor))
                {
                    return Ok("factura hecha con exito!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,new { mensaje = "No se pudo procesar la factura" });
                }

                
            }
            catch (Exception)
                {
                    return StatusCode(
                        StatusCodes.Status500InternalServerError,
                        new { mensaje = "Error en la transacción" }
                    );
                }
            }

        

       
        
        // PUT api/<FacturasController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put([FromBody] Bill bill)
        //{
        //    try
        //    {
                
                
        //        if )
        //        {
        //            return NotFound(new { mensaje = $"No se encontró la factura con id {} debido a que no existe" });
        //        }

              
        //        return Ok(new { mensaje = $"Factura {} actualizada correctamente" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al intentar actualizar factura" });
        //    }
        //}

        // DELETE api/<FacturasController>/5


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool erase = _service.delete(id);

                if (!erase)
                {
                    return NotFound(new { mensaje = $"No se encontró la factura con id {id}" });
                }

                return Ok(new { mensaje = $"Factura {id} eliminada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,new { mensaje = "Error al eliminar la factura" });
            }
        }
    }
}
