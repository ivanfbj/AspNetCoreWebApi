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

        public async Task InsertarApartamentos(TblApartamentosModelo parametros)
        {
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("InsertarApartamento", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo",parametros.Codigo);
                    cmd.Parameters.AddWithValue("@Urls",parametros.Urls);
                    cmd.Parameters.AddWithValue("@Area",parametros.Area);
                    cmd.Parameters.AddWithValue("@Habitaciones",parametros.Habitaciones);
                    cmd.Parameters.AddWithValue("@Garaje",parametros.Garaje);
                    cmd.Parameters.AddWithValue("@Ducha",parametros.Ducha);
                    cmd.Parameters.AddWithValue("@Municipio",parametros.Municipio);
                    cmd.Parameters.AddWithValue("@Barrio",parametros.Barrio);
                    cmd.Parameters.AddWithValue("@Precio",parametros.Precio);
                    cmd.Parameters.AddWithValue("@Agencia",parametros.Agencia);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task ActualizarApartamentos(TblApartamentosModelo parametros)
        {
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("ActualizarApartamento", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", parametros.Codigo);
                    //cmd.Parameters.AddWithValue("@Codigo", parametros.Codigo);
                    //cmd.Parameters.AddWithValue("@Urls", parametros.Urls);
                    //cmd.Parameters.AddWithValue("@Area", parametros.Area);
                    //cmd.Parameters.AddWithValue("@Habitaciones", parametros.Habitaciones);
                    //cmd.Parameters.AddWithValue("@Garaje", parametros.Garaje);
                    //cmd.Parameters.AddWithValue("@Ducha", parametros.Ducha);
                    //cmd.Parameters.AddWithValue("@Municipio", parametros.Municipio);
                    //cmd.Parameters.AddWithValue("@Barrio", parametros.Barrio);
                    cmd.Parameters.AddWithValue("@Precio", parametros.Precio);
                    //cmd.Parameters.AddWithValue("@Agencia", parametros.Agencia);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

    }
}
