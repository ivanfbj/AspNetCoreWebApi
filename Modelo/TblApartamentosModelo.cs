using System.Numerics;

namespace AspNetCoreWebApi.Modelo
{
    public class TblApartamentosModelo
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Urls { get; set; }
        public string? Area { get; set; }
        public int? Habitaciones { get; set; }
        public int? Garaje { get; set; }
        public int? Ducha { get; set; }
        public string? Municipio { get; set; }
        public string? Barrio { get; set; }
        public Int64? Precio { get; set; }
        public string? Agencia { get; set; }
    }
}
