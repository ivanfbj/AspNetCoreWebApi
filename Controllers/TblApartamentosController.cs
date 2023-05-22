using AspNetCoreWebApi.Modelo;
using AspNetCoreWebApi.Datos;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApi.Controllers
{
    [ApiController]
    [Route("api/apartamentos")]
    public class TblApartamentosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblApartamentosModelo>>> GetApartamentos()
        {
            var function = new TblApartamentosDatos();
            var lista = await function.MostrarApartamentos();
            return lista;
        }

        [HttpPost]
        public async Task PostApartamento([FromBody] TblApartamentosModelo parametros)
        {
            var function = new TblApartamentosDatos();
            await function.InsertarApartamentos(parametros);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult> PutApartamento(int Id, [FromBody] TblApartamentosModelo parametros)
        {
            var function = new TblApartamentosDatos();
            parametros.Id = Id;
            await function.ActualizarApartamentos(parametros);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteApartamento(int Id)
        {
            var function = new TblApartamentosDatos();
            var parametros = new TblApartamentosModelo();
            parametros.Id = Id;
            await function.EliminarApartamento(parametros);
            return NoContent();
        }
    }
}
