using AspNetCoreWebApi.Conexion;
using AspNetCoreWebApi.Modelo;
using System.Data.SqlClient;
using System.Data;
using System.Numerics;

namespace AspNetCoreWebApi.Datos
{
    public class TblApartamentosDatos
    {
        ConexionBd cn = new ConexionBd();
        public async Task <List<TblApartamentosModelo>> MostrarApartamentos()
        {
            var lista = new List<TblApartamentosModelo>();
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("MostrarApartamentos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var modeloApartamentos = new TblApartamentosModelo();
                            modeloApartamentos.Id = (int)item["Id"];
                            modeloApartamentos.Codigo = (string)item["Codigo"];
                            modeloApartamentos.Urls = (string)item["Urls"];
                            modeloApartamentos.Area = (string)item["Area"];
                            modeloApartamentos.Habitaciones = (int)item["Habitaciones"];
                            modeloApartamentos.Garaje = (int)item["Garaje"];
                            modeloApartamentos.Ducha = (int)item["Ducha"];
                            modeloApartamentos.Municipio = (string)item["Municipio"];
                            modeloApartamentos.Barrio = (string)item["Barrio"];
                            modeloApartamentos.Precio = (Int64)item["Precio"];
                            modeloApartamentos.Agencia = (string)item["Agencia"];

                            lista.Add(modeloApartamentos);
                        }
                    }
                }
                return lista;
            }
        }
    }
}
