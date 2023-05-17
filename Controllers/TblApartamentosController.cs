using AspNetCoreWebApi.Modelo;
using AspNetCoreWebApi.Datos;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApi.Controllers
{
    [ApiController]
    [Route("api/apartamentos")]
    public class TblApartamentosController
    {
        [HttpGet]
        public async Task <ActionResult<List<TblApartamentosModelo>>> GetApartamentos()
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
    }
}
