using AspNetCoreWebApi.Conexion;
using AspNetCoreWebApi.Modelo;
using System.Data.SqlClient;
using System.Data;
using System.Numerics;
using System.Text.Json;

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
                using (var cmd = new SqlCommand("stpr_MostrarApartamentos", sql))
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
        public async Task InsertarApartamentos(JsonDocument parametros)
        {
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("stpr_InsertarApartamento", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo", parametros.RootElement.GetProperty("Codigo").GetString());
                    cmd.Parameters.AddWithValue("@Urls",parametros.RootElement.GetProperty("Urls").GetString());
                    cmd.Parameters.AddWithValue("@Area",parametros.RootElement.GetProperty("Area").GetString());
                    cmd.Parameters.AddWithValue("@Habitaciones",parametros.RootElement.GetProperty("Habitaciones").GetInt32());
                    cmd.Parameters.AddWithValue("@Garaje",parametros.RootElement.GetProperty("Garaje").GetInt32());
                    cmd.Parameters.AddWithValue("@Ducha",parametros.RootElement.GetProperty("Ducha").GetInt32());
                    cmd.Parameters.AddWithValue("@Municipio",parametros.RootElement.GetProperty("Municipio").GetString());
                    cmd.Parameters.AddWithValue("@Barrio",parametros.RootElement.GetProperty("Barrio").GetString());
                    cmd.Parameters.AddWithValue("@Precio",parametros.RootElement.GetProperty("Precio").GetInt64());
                    cmd.Parameters.AddWithValue("@Agencia",parametros.RootElement.GetProperty("Agencia").GetString());
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task ActualizarApartamentos(TblApartamentosModelo parametros)
        {
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("stpr_ActualizarApartamento", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", parametros.Id);
                    cmd.Parameters.AddWithValue("@Codigo", parametros.Codigo);
                    cmd.Parameters.AddWithValue("@Urls", parametros.Urls);
                    cmd.Parameters.AddWithValue("@Area", parametros.Area);
                    cmd.Parameters.AddWithValue("@Habitaciones", parametros.Habitaciones); 
                    cmd.Parameters.AddWithValue("@Garaje", parametros.Garaje);
                    cmd.Parameters.AddWithValue("@Ducha", parametros.Ducha);
                    cmd.Parameters.AddWithValue("@Municipio", parametros.Municipio);
                    cmd.Parameters.AddWithValue("@Barrio", parametros.Barrio);
                    cmd.Parameters.AddWithValue("@Precio", parametros.Precio);
                    cmd.Parameters.AddWithValue("@Agencia", parametros.Agencia);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task EliminarApartamento(TblApartamentosModelo parametros)
        {
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("stpr_EliminarApartamento", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", parametros.Id);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

    }
}
